using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_v_1._0
{
    public partial class SearchForm : Form
    {
        IPEndPoint addressIp = new IPEndPoint(IPAddress.Any, 1111);
        static UdpClient searchServer;
        List<string> serversList = new List<string>();
        string[] serverData = new string[1];
        int tick = 0;
        Thread finder;

        public SearchForm()
        {
            InitializeComponent();
            searchServer = new UdpClient(addressIp);

        }

        public void Recv(IAsyncResult res)
        {
            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = searchServer.EndReceive(res, ref remote);
            //odebrane dane dodac do tabeli
            string rec = Encoding.ASCII.GetString(data);
            if(String.IsNullOrEmpty(serversList.Where(a=>a==rec).FirstOrDefault()))
            {
                serversList.Add(rec);
            }
            searchServer.BeginReceive(Recv, null);

        }

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            tick = 0;
            finder = new Thread(ReciveDataLoop);
            timer1.Interval = 1000;
            timer1.Start();
            finder.Start();
            SearchButton.Enabled = false;

        }
        private void AddFindServerToList(List<string> data)
        {
            ServerList.Items.Clear();
            foreach (var item in data)
            {
                var row = new ListViewItem(item.Split(';'));
                ServerList.Items.Add(row);
            }
            
        }
        void ReciveDataLoop()
        {
            searchServer.EnableBroadcast = true;
            searchServer.BeginReceive(new AsyncCallback(Recv), null);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(tick<2)
            {
                tick++;
            }
            else
            {
                finder.Abort();
                SearchButton.Enabled = true;
                AddFindServerToList(serversList);
                timer1.Enabled = false;
            }
        }

        private void ServerList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(ServerList.Items.Count!=0)
            {
                Debug.WriteLine(ServerList.SelectedItems[0].SubItems[2].Text);
                VariableClass.OpPlayer.Name = ServerList.SelectedItems[0].SubItems[2].Text;
                VariableClass.OpPlayer.Ip = new IPEndPoint(IPAddress.Parse(ServerList.SelectedItems[0].SubItems[1].Text), VariableClass.Port);
                VariableClass.Client = new TcpClient();
                VariableClass.Client.Connect(VariableClass.OpPlayer.Ip);
                GameForm gf = new GameForm();
                gf.Show();
                this.Hide();
            }
        }

        private void ServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ServerList.SelectedItems.Count>0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}