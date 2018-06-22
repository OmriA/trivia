using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TriviaClient
{
    public class Client
    {
        private TcpClient Sock;

        public Client(TcpClient sock) => Sock = sock;

        public void SendMessage(string msg) => Sock.GetStream().Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);

        public string GetMessage()
        {
            byte[] buffer = new byte[2048];
            Sock.GetStream().Read(buffer, 0, buffer.Length);
            return Encoding.Default.GetString(buffer);
        }
    }
}
