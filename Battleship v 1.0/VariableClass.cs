using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_v_1._0
{
    public static class VariableClass
    {
        public static int Port{
            get { return 1111; }
            
        }
        public static int Port2
        {
            get { return 1112; }

        }
        #region PlayerOP
        public static Player OpPlayer { get; set; }
        public static TcpClient Client { get; set; }
        #endregion
        #region My
        public static Player MePlayer { get; set; }
        public static bool MyMove = false;
        public static int BattleCount { get; set; }
        public static bool CanPlay { get; set; }
        #endregion
        public static bool GameReady=false;
        public static TcpListener Listener { get; set; }
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static byte[] ReceiveAll(this Socket socket)
        {
            var buffer = new List<byte>();

            while (socket.Available > 0)
            {
                var currByte = new Byte[1];
                var byteCounter = socket.Receive(currByte, currByte.Length, SocketFlags.None);

                if (byteCounter.Equals(1))
                {
                    buffer.Add(currByte[0]);
                }
            }

            return buffer.ToArray();
        }
    }
}
