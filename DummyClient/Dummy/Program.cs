using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Google.Protobuf.Packet.Room;
using Google.Protobuf.State;

namespace Dummy
{
    class Program
    {
        static ServerConnection servConn = ServerConnection.Instance;
        static RoomContext roomContext = RoomContext.GetInstance();
        static PacketManager packetManager = PacketManager.Instance;
        static DummyFactory factory;

        static bool isHost = false;
        static bool created = false;
        static int enter = 0;
        static int port = 0;
        static string limit = "";
        static string addr = "";
        static string roomName = "";
        static string strInPipeHandle = "";
        static string strOutPipeHandle = "";
        static AnonymousPipeClientStream inPipe = null;
        static AnonymousPipeClientStream outPipe = null;
        static Timer timer;

        static int roomId;
        static string clntName;

        static StreamReader sr = null;
        static StreamWriter sw = null;

        public static void Log(string message)
        {
            Console.WriteLine(string.Format("[Client:{0}] {1}", roomContext.GetMyUsername(), message));
        }

        static void TimerEvent(object sender, ElapsedEventArgs e)
        {
            WorldState dummy = factory.CreateDummy(roomId, clntName);
            packetManager.PackMessage(protoObj: dummy);
        }

        static void Main(string[] args)
        {
            factory = new DummyFactory();
            timer = new Timer();
            timer.Interval = 15.5;
            timer.Elapsed += new ElapsedEventHandler(TimerEvent);

            strOutPipeHandle = args[0];
            strInPipeHandle = args[1];

            outPipe =
                new AnonymousPipeClientStream(PipeDirection.Out, strOutPipeHandle);
            inPipe =
                new AnonymousPipeClientStream(PipeDirection.In, strInPipeHandle);

            addr = args[2];
            port = Convert.ToInt32(args[3]);
            roomName = args[4];

            if (args.Length > 5)
            {
                isHost = true;
                limit = args[5];
            }

            sr = new StreamReader(inPipe);
            sw = new StreamWriter(outPipe);

            packetManager.SetHandleMessage(PopMessage);
            Task conn = servConn.CreateConnection(addr, port);
            conn.Wait();

            while (true)
            {
                Task recv = servConn.StartRecvThread();
                recv.Wait();
            }
        }

        public static void PopMessage(object obj, Type type)
        {
            if (type.Name == MessageTypeStrings.DATA)
            {
                Data data = (Data)obj;
                string contentType = data.DataMap[MessageTypeStrings.CONTENT_TYPE];

                switch (contentType)
                {
                    case MessageTypeStrings.ASSIGN_USERNAME:
                        roomContext.SetUsername(data.DataMap[MessageTypeStrings.USERNAME]);
                        clntName = roomContext.GetMyUsername();
                        if (isHost)
                        {
                            // Server에게 방생성 요청
                            Data temp = new Data();
                            temp.DataMap[MessageTypeStrings.CONTENT_TYPE] = MessageTypeStrings.CREATE_ROOM;
                            temp.DataMap[MessageTypeStrings.ROOMNAME] = roomName;
                            temp.DataMap[MessageTypeStrings.LIMIT] = limit;
                            temp.DataMap[MessageTypeStrings.USERNAME] = roomContext.GetMyUsername();
                            packetManager.PackMessage(protoObj: temp);
                        }
                        else
                        {
                            // Host가 아니라면, 방에 Enter
                            Data temp = new Data();
                            temp.DataMap[MessageTypeStrings.CONTENT_TYPE] = MessageTypeStrings.ENTER_ROOM;
                            temp.DataMap[MessageTypeStrings.ROOMNAME] = roomName;
                            temp.DataMap[MessageTypeStrings.USERNAME] = roomContext.GetMyUsername();
                            packetManager.PackMessage(protoObj: temp);
                        }
                        break;
                }
            }
            else if (type.Name == MessageTypeStrings.ROOMINFO)
            {
                // Accept Create/Enter Room
                RoomInfo room = (RoomInfo)obj;
                roomContext.SetRoomInfo(room);
                roomId = roomContext.RoomId;

                if (isHost)
                {
                    if (created)
                        return;

                    created = true;
                    sw.AutoFlush = true;
                    sw.WriteLine("ROOM_CREATE_SUCCESS");
                    outPipe.WaitForPipeDrain();

                    // Controller로부터 Start 신호 받기
                    string rtn = sr.ReadLine();
                    if (rtn == "GAME_START")
                    {
                        Log("Get Start Signal from controller");
                        Data request = new Data();
                        request.DataMap.Add(MessageTypeStrings.CONTENT_TYPE, MessageTypeStrings.START_GAME);
                        request.DataMap.Add(MessageTypeStrings.ROOMID, roomContext.RoomId.ToString());
                        packetManager.PackMessage(protoObj: request);
                    }
                }
                else
                {
                    if (enter == 0)
                    {
                        Log("Ready_EVENT");
                        enter++;
                        packetManager.PackMessage(MessageType.READY_EVENT);
                    }
                    else if(enter == 1)
                    {
                        Log("Ready");
                        enter++;
                        sw.AutoFlush = true;
                        sw.WriteLine("READY");
                        outPipe.WaitForPipeDrain();
                    }
                }

            }
            else if (type.Name == MessageTypeStrings.INT32)
            {
                int messageType = (int)obj;
                if (messageType == MessageType.START_GAME)
                {
                    Log("GAME_START!");
                    sw.WriteLine("START");
                    //Dummy Data 송신
                    timer.Start();
                }
            }
            else if(type.Name == MessageTypeStrings.WORLDSTATE)
            {
                //Nothing;
                //Log(DummyFactory.ToString((WorldState)obj));
            }
        }
    }
}
