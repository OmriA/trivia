using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
namespace TriviaClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TcpClient client = new TcpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8820);
            bool flag = false, flagConnected = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (flag != true)
            {
                try
                {
                    client.Connect(serverEndPoint);
                }
                catch
                {
                    if (!(MessageBox.Show("You do not have a server running\n\nOk - try again.\nCancel - close client.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                    {
                        flag = true;
                    }
                }
                
            }
            while (flagConnected == true)
            {
                if (client.Connected)
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                Application.Run(new Title());
            }
        }
    }
}
