using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;

namespace Dummy
{
    class PacketManager
    {
        public delegate void HandleMessage(object obj, Type type);
        private HandleMessage handleMessage;

        private const int BUF_SIZE = 4096;
        private ServerConnection connection = null;
        private CodedOutputStream cos;
        private byte[] sendBuffer;

        private static PacketManager instance = null;
        public static PacketManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PacketManager();
                    instance.connection = ServerConnection.Instance;
                    instance.connection.SetReceiveCallBack(instance.UnpackProcess);
                }
                return instance;
            }
        }

        private PacketManager() { }

        public void SetHandleMessage(HandleMessage hm)
        {
            this.handleMessage = hm;
        }

        private void ClearBuffer()
        {
            Array.Clear(sendBuffer, 0, sendBuffer.Length);
        }

        public void PackMessage(int type = -1, IMessage protoObj = null)
        {
            ClearBuffer();
            cos = new CodedOutputStream(sendBuffer);

            if (protoObj == null)
            {
                cos.WriteFixed32((uint)type);
                cos.WriteFixed32(0);
            }
            else
            {
                SerializeMessageBody(cos, protoObj);
            }
            connection.SendMessage(sendBuffer, (int)cos.Position);
        }

        private void SerializeMessageBody(CodedOutputStream cos, IMessage protoObj)
        {
            int type = MessageType.typeTable[protoObj.GetType()];
            int byteLength = protoObj.CalculateSize();

            cos.WriteFixed32((uint)type);
            cos.WriteFixed32((uint)byteLength);
            protoObj.WriteTo(cos);
        }

        private void UnpackProcess(byte[] buffer, int readBytes)
        {
            bool hasBody, hasMore = true;
            int type, length, start = 0;

            while (hasMore)
            {
                type = length = 0;
                hasBody = UnpackHeader(buffer, start, ref type, ref length);
                start += 8;
                if (hasBody)
                {
                    UnpackMessage(buffer, start, type, length);
                    start += length;
                }

                hasMore = (readBytes > start) ? true : false;
            }
        }

        private bool UnpackHeader(byte[] buffer, int start, ref int type, ref int length)
        {
            CodedInputStream cis = new CodedInputStream(buffer, start, 8);
            type = (int)cis.ReadFixed32();
            length = (int)cis.ReadFixed32();

            if (length != 0)
                return true;

            handleMessage(type, typeof(int));
            return false;
        }

        private void UnpackMessage(byte[] buffer, int start, int type, int length)
        {
            if (!MessageType.invTypeTable.ContainsKey(type))
            {
                return;
            }

            object body = null;
            try
            {
                body = DeserializeMessageBody(buffer, start, length, MessageType.invTypeTable[type]);
                handleMessage(body, MessageType.invTypeTable[type]);
            }
            catch (KeyNotFoundException knfe)
            {
                return;
            }
        }

        private object DeserializeMessageBody(byte[] buffer, int start, int length, Type type)
        {
            if (length < 0 || start + length > buffer.Length)
            {
                //Debug.Log(string.Format("Out of Range, length: {0}, start: {1}, buffer: {2}",
                //    length, start, buffer.Length));
                return null;
            }

            object obj = Activator.CreateInstance(type);
            try
            {
                CodedInputStream cis = new CodedInputStream(buffer, start, length);
                MethodInfo parseMethod = type.GetMethod("MergeFrom", new Type[] { typeof(CodedInputStream) });
                parseMethod.Invoke(obj, new object[] { cis });
                return obj;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
