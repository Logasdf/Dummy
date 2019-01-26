using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Dummy
{
    class ServerConnection
    {
        public delegate void ReceiveCallback(byte[] buffer, int readBytes);

        bool isEnd;

        private TcpClient socket;
        private NetworkStream nStream;
        private ReceiveCallback receiveCallback;
        const int BUF_SIZE = 4096;
        byte[] buffer;

        private static ServerConnection instance = null;
        public static ServerConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerConnection();
                    instance.isEnd = false;
                    instance.buffer = new byte[BUF_SIZE];
                }
                return instance;
            }
        }

        public async Task CreateConnection(string addr = "127.0.0.1", int port = 9910)
        {
            socket = new TcpClient();
            await socket.ConnectAsync(addr, port);
            nStream = socket.GetStream();
        }

        public void Disconnect()
        {
            isEnd = true;
            if (nStream != null)
                nStream.Close();
            if (socket != null)
                socket.Close();
        }

        public void SetReceiveCallBack(ReceiveCallback cb)
        {
            receiveCallback += cb;
        }

        public async Task SendMessage(byte[] msg, int size)
        {
            if (nStream == null)
                return;

            await nStream.WriteAsync(msg, 0, size);
        }

        public async Task StartRecvThread()
        {  
            //Program.Log("ReadAsync");
            int readBytes = await nStream.ReadAsync(buffer, 0, BUF_SIZE);
            receiveCallback(buffer, readBytes);
            Array.Clear(buffer, 0, BUF_SIZE);
        }

        private ServerConnection() {}
    }
}
