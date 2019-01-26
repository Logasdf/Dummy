using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using Google.Protobuf.Packet.Room;

namespace Dummy
{
    class Program
    {
        static ServerConnection servConn = ServerConnection.Instance;
        static RoomContext roomContext = RoomContext.GetInstance();
        static PacketManager packetManager = PacketManager.Instance;
        static bool isHost = false;
        static bool isEnter = false;
        static int port = 0;
        static string limit = "";
        static string addr = "";
        static string roomName = "";
        static string strInPipeHandle = "";
        static string strOutPipeHandle = "";
        static AnonymousPipeClientStream inPipe = null;
        static AnonymousPipeClientStream outPipe = null;

        static StreamReader sr = null;
        static StreamWriter sw = null;

        public static void PopMessage(object obj, Type type)
        {
            if (type.Name == MessageTypeStrings.DATA)
            {
                Data data = (Data)obj;
                string contentType = data.DataMap[MessageTypeStrings.CONTENT_TYPE];

                switch (contentType)
                {
                    case MessageTypeStrings.ASSIGN_USERNAME:
                        //Log(data.DataMap[MessageTypeStrings.USERNAME]);
                        roomContext.SetUsername(data.DataMap[MessageTypeStrings.USERNAME]);
                        if(isHost)
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
                
                if(isHost)
                {
                    Log("ROOM_CREATE_SUCCESS");
                    sw.WriteLine("ROOM_CREATE_SUCESS");
                    outPipe.WaitForPipeDrain();

                    // Controller로부터 Start 신호 받기
                    string rtn = sr.ReadLine();
                    if (rtn == "GAME_START")
                    {
                        Log("Receive Start Signal From Controller!");
                        Data request = new Data();
                        request.DataMap.Add(MessageTypeStrings.CONTENT_TYPE, MessageTypeStrings.START_GAME);
                        request.DataMap.Add(MessageTypeStrings.ROOMID, roomContext.RoomId.ToString());
                        packetManager.PackMessage(protoObj: request);
                    }
                }
                else
                {
                    if (!isEnter)
                    {
                        isEnter = true;
                        packetManager.PackMessage(MessageType.READY_EVENT);
                    }
                    else
                    {
                        sw.WriteLine("READY");
                        outPipe.WaitForPipeDrain();
                    }
                }

            }
            else if(type.Name == MessageTypeStrings.INT32)
            {
                int messageType = (int)obj;
                if (messageType == MessageType.START_GAME)
                {
                    Log("Game Start Signal from Server");
                    //Dummy Data 송신

                }
            }
        }

        public static void Log(string message)
        {
            Console.WriteLine(string.Format("[Client:{0}] {1}", roomContext.GetMyUsername(), message));
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
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
            }

            Log(string.Format("{0}/{1}/{2}/{3}", strOutPipeHandle, strInPipeHandle, addr, port));

            sr = new StreamReader(inPipe);
            sw = new StreamWriter(outPipe);
            sw.AutoFlush = true;

            servConn.CreateConnection(addr, port);
            packetManager.SetHandleMessage(PopMessage);

            while(true)
            {
                Task rtn = servConn.StartRecvThread();
                rtn.Wait();
            }
        }
    }
}
