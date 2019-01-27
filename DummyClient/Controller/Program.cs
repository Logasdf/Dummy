using System;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using System.Text;
using System.Security.Principal;

namespace Controller
{
    class Program
    {
        //static private readonly string IP = "127.0.0.1";
        static private readonly string IP = "210.178.233.151";
        static private readonly string PORT = "9910";
        static private readonly string LIMIT = "8";

        static void Main(string[] args)
        {
            string ip;
            string port;
            string limit;
            while(true)
            {
                Console.WriteLine("IP를 입력하세요: (Default=127.0.0.1)");
                ip = Console.ReadLine();
                Console.WriteLine("Port를 입력하세요: (Default=9910)");
                port = Console.ReadLine();
                Console.WriteLine("방 인원수를 입력하세요: (Defulat=8)");
                limit = Console.ReadLine();

                if (ip == "")
                    ip = IP;
                if (port == "")
                    port = PORT;
                if (limit == "")
                    limit = LIMIT;

                TestRoom test = new TestRoom(ip, Convert.ToInt32(port), Convert.ToInt32(limit));
                test.StartTestRoom();

                Console.WriteLine("방을 더 생성하려면 Enter를 누르세요.");
                Console.ReadLine();
            }
        }
    }

    class TestRoom
    {
        class ProcessContext
        {
            private Process proc;
            public Process Proc { get { return proc; } set { proc = value; } }
            private PipeStream inPipe;
            public PipeStream InPipe { get { return inPipe; } set { inPipe = value; } }
            private PipeStream outPipe;
            public PipeStream OutPipe { get { return outPipe; } set { outPipe = value; } }
            private StreamWriter sw;
            public StreamWriter SW { get { return sw; } set { sw = value; } }
            private StreamReader sr;
            public StreamReader SR { get { return sr; } set { sr = value; } }

            public string ReadLine()
            {
                return sr.ReadLine();
            }

            public void WriteLine(string message)
            {
                sw.AutoFlush = true;
                sw.WriteLine(message);
                outPipe.WaitForPipeDrain();
            }
        }

        static string dummyFileName = @"C:\Users\home\Desktop\dummy\DummyClient\Dummy\bin\Debug\Dummy.exe";
        static int roomCnt = 0;

        string addr;
        int port;

        string roomName;
        int readyCnt;
        int clntCnt;
        int limit;

        ProcessContext host;
        ProcessContext[] clients;

        public TestRoom(string addr, int port, int limit) 
            : this(addr, port, string.Format("Room#{0}", roomCnt++), limit) { }


        public TestRoom(string addr, int port, string roomName, int limit)
        {
            this.addr = addr;
            this.port = port;
            this.roomName = roomName;
            this.limit = limit;
            clients = new ProcessContext[limit];
        }

        public void StartTestRoom()
        {
            string msg;
            Log("Process Start!!");

            readyCnt = clntCnt = 0;
            host = clients[clntCnt++] = CreateProcess(true);

            msg = host.ReadLine();
            if (msg == "ROOM_CREATE_SUCCESS")
            {
                Log("Room Create Success!!");
            }
            else
            {
                Log("Room Create Failed!!");
            }

            for (int i = 1; i < limit; ++i)
            {
                clntCnt++;
                clients[i] = CreateProcess(false);
                msg = clients[i].ReadLine();
                if (msg == "READY")
                {
                    readyCnt++;
                }
            }

            if (readyCnt == limit - 1)
            {
                //Log("Game Start!");
                host.WriteLine("GAME_START");
            }

            for(int i = 0; i < limit; ++i)
            {
                clients[i].ReadLine();
            }

            Log("Process End!!");
        }

        private void Log(string message, bool newLine = true)
        {
            if(newLine)
                Console.WriteLine(string.Format("[Controller:Case#{0}] {1}", roomCnt, message));
            else
                Console.Write(string.Format("[Controller:Case#{0}] {1}", roomCnt, message));
        }

        private ProcessContext CreateProcess(bool isHost)
        {
            try
            {
                ProcessContext pc = new ProcessContext();
                ProcessStartInfo psInfo = new ProcessStartInfo();

                psInfo.FileName = dummyFileName;
                psInfo.CreateNoWindow = false;
                // true일 경우, Client Process에 넘긴 Pipe에 문제가 생김.
                // 정확히 말하면, Pipe Handle이 상속되지 않는다.
                psInfo.UseShellExecute = false; 

                pc.InPipe
                    = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable);
                pc.OutPipe
                    = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);

                StringBuilder sb = new StringBuilder(
                    ((AnonymousPipeServerStream)pc.InPipe).GetClientHandleAsString());
                sb.Append(' ');
                sb.Append(((AnonymousPipeServerStream)pc.OutPipe).GetClientHandleAsString());
                sb.Append(' ');
                sb.Append(addr);
                sb.Append(' ');
                sb.Append(port);
                sb.Append(' ');
                sb.Append(roomName);
                if(isHost)
                {
                    sb.Append(' ');
                    sb.Append(limit);
                }
                psInfo.Arguments = sb.ToString();
                //Log(psInfo.Arguments);

                pc.Proc = Process.Start(psInfo);
                ((AnonymousPipeServerStream)pc.InPipe).DisposeLocalCopyOfClientHandle();
                ((AnonymousPipeServerStream)pc.OutPipe).DisposeLocalCopyOfClientHandle();
                pc.SW = new StreamWriter(pc.OutPipe);
                pc.SR = new StreamReader(pc.InPipe);

                return pc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
