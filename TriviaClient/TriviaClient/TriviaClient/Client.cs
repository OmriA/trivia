﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace TriviaClient
{
    public class Client
    {
        private TcpClient Sock;
        private Dictionary<char, char> dict = new Dictionary<char, char>();
        public Client(TcpClient sock)
        {
            Sock = sock;
            string line = "";
            System.IO.StreamReader f = new System.IO.StreamReader(@"C:\Users\magshimim\Documents\GitHub\trivia\encDic.txt");
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while ((line = f.ReadLine()) != null)
            {
                dict.Add(line[0], line[2]);
            }
        }



        public void SendMessage(string msg)
        {
            int i = 0;
            char value = '0';
            //encode
            StringBuilder sb = new StringBuilder(msg.Length);
            for (i = 0; i < msg.Length; i++)
            {
                value = dict[msg[i]];
                sb.Append(value);
            }
            Sock.GetStream().Write(Encoding.ASCII.GetBytes(sb.ToString()), 0, sb.ToString().Length);
        }

        public string GetMessage()
        {
            char key = '0';
            var buffer = new byte[4096];
            var msgLen = Sock.GetStream().Read(buffer, 0, buffer.Length);
            string msg = Encoding.Default.GetString(buffer, 0, msgLen);
            //decode
            StringBuilder sb = new StringBuilder(msgLen);
            for (int i = 0; i < msg.Length; i++)
            {
                foreach (KeyValuePair<char, char> entry in dict)
                {
                    if (entry.Value == msg[i])
                    {
                        key = entry.Key;
                    }
                    sb.Append(key);
                }
            }
            return sb.ToString();
        }
    }
}
