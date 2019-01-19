using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_v_1._0
{
    public partial class CreateServerForm : Form
    {
        public CreateServerForm()
        {
            
            InitializeComponent();
        }
        private static ManualResetEvent mre = new ManualResetEvent(false);
        IPEndPoint ipAddress = new IPEndPoint(IPAddress.Broadcast, VariableClass.Port);
        IPAddress ip = VariableClass.GetLocalIPAddress();
        UdpClient broadcastServer = new UdpClient();
        byte[] sendBuffer;
        Thread Brodcast,ClientConnect;
        int count = 0;
        bool clientConnected = false;

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                VariableClass.Listener = new TcpListener(IPAddress.Any, VariableClass.Port);
                sendBuffer = Encoding.ASCII.GetBytes(textBox1.Text+";"+ip.ToString()+";"+VariableClass.MePlayer.Name);
                button1.Enabled = false;
                Brodcast = new Thread(StartBroadcast);
                ClientConnect = new Thread(Listen);
                Brodcast.Start();
                ClientConnect.Start();
                timer_1.Interval = 1000;
                timer_1.Start();

            }

        }

        void StartBroadcast()
        {
            broadcastServer = new UdpClient()
            {
                EnableBroadcast = true
            };
            for (count = 0; count < 20; count++)
            {
                try
                {
                    broadcastServer.Send(sendBuffer, sendBuffer.Length, ipAddress);
                    Thread.Sleep(1000);
                }
                catch { }
            }
        }
        void Listen()
        {
            VariableClass.Client = new TcpClient();
            VariableClass.Listener.Start();
            while (count<20)
            {
                if(VariableClass.Listener.Pending())
                {
                    VariableClass.Client = VariableClass.Listener.AcceptTcpClient();
                    VariableClass.OpPlayer.Ip = (IPEndPoint)(VariableClass.Client.Client.RemoteEndPoint);
                    clientConnected = true;
                }
            }
            
            VariableClass.Listener.Stop();
            
        }
        private void CreateServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Timer_1_Tick(object sender, EventArgs e)
        {
            if(count<20)
            {
                if(clientConnected)
                {
                    Brodcast.Abort();
                    GameForm gf = new GameForm();
                    gf.Show();
                    Hide();
                    timer_1.Stop();
                }
            }
            else
            {
                Brodcast.Abort();
                VariableClass.Listener.Stop();
                ClientConnect.Join();
                button1.Enabled = true;
                label2.Text = "Nikt się nie połączył.";
                timer_1.Stop();
            }
        }
    }
}
