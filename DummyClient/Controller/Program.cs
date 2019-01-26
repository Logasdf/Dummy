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
        static void Main(string[] args)
        {
            TestRoom test = new TestRoom();
            test.StartTestRoom();
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
            public StreamWriter SW { get { return sw; } set { sw = value; sw.AutoFlush = true; } }
            private StreamReader sr;
            public StreamReader SR { get { return sr; } set { sr = value; } }

            public string ReadLine()
            {
                return sr.ReadLine();
            }

            public void WriteLine(string message)
            {
                sw.WriteLine(message);
                outPipe.WaitForPipeDrain();
            }
        }

        static string dummyFileName = @"C:\Users\home\Desktop\dummy\DummyClient\Dummy\bin\Debug\Dummy.exe";
        static int roomCnt = 0;

        string addr;
        int port;

        string roomName;
        string args;
        int readyCnt;
        int clntCnt;
        int limit;

        ProcessContext host;
        ProcessContext[] clients;

        public TestRoom(string addr = "127.0.0.1", int port = 9910, int limit = 8) 
            : this(addr, port, string.Format("Room#{0}", roomCnt++), limit) { }


        public TestRoom(string addr, int port, string roomName, int limit)
        {
            this.addr = addr;
            this.port = port;
            this.roomName = roomName;
            this.limit = limit;
            args = string.Format("{0} {1}", roomName, limit);
            clients = new ProcessContext[limit];
        }

        public void StartTestRoom()
        {
            Log("Process Start!!");

            readyCnt = clntCnt = 0;
            host = clients[clntCnt++] = CreateProcess(true, args);

            Log("Host is Created!");

            //Host Process로부터 방을 성공적으로 생성했다는 신호를 받을 경우 진행.
            //string rtn = host.ReadLine();
            //if (rtn == "ROOM_CREATE_SUCESS")
            //{
            //    Log("Room Create Success!!");
            //}
            //else
            //{
            //    Log("Room Create Failed!!");
            //}

            //for (int i = 1; i < limit; ++i)
            //{
            //    clntCnt++;
            //    clients[i] = CreateProcess(false);
            //    Log(string.Format("Clnt#{0} is Created!", clntCnt));
            //    rtn = clients[i].ReadLine();
            //    if (rtn == "READY")
            //    {
            //        Log(string.Format("Clnt#{0} is Ready!", clntCnt));
            //        readyCnt++;
            //    }
            //}

            //if (readyCnt == limit - 1)
            //{
            //    host.WriteLine("GAME_START");
            //}
            //else
            //{
            //    Log("All client are not ready...");
            //}

            //Log("GameStart!");
            Console.ReadLine();
        }

        private void Log(string message, bool newLine = true)
        {
            if(newLine)
                Console.WriteLine(string.Format("[Controller:Case#{0}] {1}", roomCnt, message));
            else
                Console.Write(string.Format("[Controller:Case#{0}] {1}", roomCnt, message));
        }

        private ProcessContext CreateProcess(bool isHost, string args = "")
        {
            try
            {
                ProcessContext pc = new ProcessContext();
                ProcessStartInfo psInfo = new ProcessStartInfo();

                psInfo.FileName = dummyFileName;
                psInfo.CreateNoWindow = false;
                psInfo.UseShellExecute = false; // true일 경우, Client Process에 넘긴 Pipe에 문제가 생김.
                //psInfo.RedirectStandardInput = false;
                //psInfo.RedirectStandardOutput = false;
                //psInfo.RedirectStandardError = false;

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
                if(isHost)
                {
                    sb.Append(' ');
                    sb.Append(args);
                }
                psInfo.Arguments = sb.ToString();
                Log(psInfo.Arguments);

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
