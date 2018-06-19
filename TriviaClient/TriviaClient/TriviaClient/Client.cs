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
        private Queue<string> RecievedMessages;

        public Client(TcpClient sock) => Sock = sock;

        public void SendMessage(string msg) => Sock.GetStream().Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length + 1);

        public string GetMessage() => 
    }
}
