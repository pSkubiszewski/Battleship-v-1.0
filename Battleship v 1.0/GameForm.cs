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
    public partial class GameForm : Form
    {
        public Thread WaitForOpReady;
        public GameForm()
        {
            InitializeComponent();
            VariableClass.BattleCount = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Cell Cell = new Cell();
                    Cell.Button.Location=new Point(40 * i, 40 * j);
                    Cell.BattleState = State.Empty;
                    Cell.Button.Size = new Size(40, 40);
                    Cell.Button.Tag = i+";"+j;
                    VariableClass.MePlayer.Board[i, j] = Cell;
                    MyPanel.Controls.Add(VariableClass.MePlayer.Board[i, j].Button);
                }
            }
            MyLabel.Text = VariableClass.MePlayer.Name;
            OpLabel.Text = VariableClass.OpPlayer.Name;
            WaitForOpReady = new Thread(GameLoop);
            WaitForOpReady.Start();

        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (VariableClass.BattleCount == 24)
            {
                VariableClass.MePlayer.Ready = true;
                SendMessageToOp("ready");
                button1.Enabled = false;
                MyPanel.Enabled = false; //sprawdzic czy dziala
                if(VariableClass.OpPlayer.Ready)
                {
                    InfoLabel.Text = "Ruch przeciwnika";
                    VariableClass.GameReady = true;
                    VariableClass.MyMove = false;
                    GenerateOpBoard();
                }
                else
                {
                    InfoLabel.Text = "Przeciwnik nie jest jeszcze gotowy";
                    VariableClass.MyMove = true;
                }
            }

        }

        private void GameLoop()
        {
            VariableClass.CanPlay = true;
            while (true)
            {
                if(VariableClass.BattleCount==0 && VariableClass.GameReady && VariableClass.OpPlayer.Ready)
                {
                    MessageBox.Show("Przegrałeś :(");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                    this.Close();

                }

                byte[] data;
                    try
                    {
                    data = VariableClass.ReceiveAll(VariableClass.Client.Client);
                    }
                    catch
                    {
                        continue;
                    }
                    if(data==null)
                    {
                        continue;
                    }
                    string ret = Encoding.ASCII.GetString(data);
                    Debug.WriteLine(ret);
                    if(ret.CompareTo("ready")==0 && VariableClass.MePlayer.Ready)
                    {
                        VariableClass.GameReady = true;
                        Debug.WriteLine("Prawda ret==ready");
                        InfoLabel.Invoke(new Action(() => InfoLabel.Text = "Gra się rozpoczeła"));
                        GenerateOpBoard();
                        VariableClass.OpPlayer.Ready = true;
                        VariableClass.MyMove = true;
                        InfoLabel.Invoke(new Action(() => InfoLabel.Text = "Twój ruch"));

                        continue;
                    }
                    else
                    {
                        if(ret.CompareTo("ready")==0 && !VariableClass.MePlayer.Ready)
                        {
                            VariableClass.OpPlayer.Ready = true;
                            VariableClass.MyMove = false;
                            if (InfoLabel.InvokeRequired)
                            {
                                InfoLabel.Invoke(new Action(() => InfoLabel.Text = "Przeciwnik jest juz gotowy"));
                            }
                            else
                            {
                                InfoLabel.Text = "Przeciwnik jest juz gotowy";
                            }
                            continue;
                        }

                    }
                    
                    string[] rearray = ret.Split(';');
                    if(rearray.Length==2)
                    {

                        SendCordInfo(rearray);
                        continue;
                    }
                    if(rearray.Length==3)
                    {
                        if (rearray[2].CompareTo("hit")==0)
                        {
                            VariableClass.OpPlayer.Board[Int32.Parse(rearray[0]), Int32.Parse(rearray[1])].BattleState = State.Hit;
                            VariableClass.OpPlayer.Board[Int32.Parse(rearray[0]), Int32.Parse(rearray[1])].Button.BackColor = Color.Red;
                        }
                        if(rearray[2].CompareTo("fail")==0)
                        {
                            VariableClass.OpPlayer.Board[Int32.Parse(rearray[0]), Int32.Parse(rearray[1])].BattleState = State.Empty;
                            VariableClass.OpPlayer.Board[Int32.Parse(rearray[0]), Int32.Parse(rearray[1])].Button.BackColor = Color.Blue;
                            VariableClass.MyMove = false;
                            InfoLabel.Invoke(new Action(() => InfoLabel.Text = "Ruch przeciwnika"));
                        }
                    }

                
            }
        }
        /// <summary>
        /// Wysyłanie odpowiedzi po strzale przeciwnika
        /// </summary>
        /// <param name="cord"></param>
        void SendCordInfo(string[] cord)
        {
            switch(VariableClass.MePlayer.Board[Int32.Parse(cord[0]), Int32.Parse(cord[1])].BattleState)
            {
                case State.Battle:
                    VariableClass.MePlayer.Board[Int32.Parse(cord[0]), Int32.Parse(cord[1])].BattleState = State.Hit;
                    VariableClass.MePlayer.Board[Int32.Parse(cord[0]), Int32.Parse(cord[1])].Button.BackColor = Color.Red;
                    SendMessageToOp(cord[0] + ";" + cord[1] + ";hit");
                    VariableClass.BattleCount--;
                    return;
                case State.Empty:
                    VariableClass.MePlayer.Board[Int32.Parse(cord[0]), Int32.Parse(cord[1])].Button.BackColor = Color.Blue;
                    SendMessageToOp(cord[0] + ";" + cord[1] + ";fail");
                    VariableClass.MyMove = true;
                    InfoLabel.Invoke(new Action(() => InfoLabel.Text = "Twój ruch"));

                    return;
            }

        }
        void SendMessageToOp(string message)
        {
            byte[] a = Encoding.ASCII.GetBytes(message);
            VariableClass.Client.Client.Send(a);
        }
        void GenerateOpBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Cell cell = new Cell();
                    cell.Button.Location = new Point(i * 40, j * 40);
                    cell.Button.Size = new Size(40, 40);
                    cell.BattleState = State.Empty;
                    cell.Button.Tag = i + ";" + j;
                    VariableClass.OpPlayer.Board[i, j] = cell;
                    if (InfoLabel.InvokeRequired)
                    {
                        OpPanel.Invoke(new Action(() => OpPanel.Controls.Add(VariableClass.OpPlayer.Board[i, j].Button)));
                    }
                    else
                    {
                        OpPanel.Controls.Add(VariableClass.OpPlayer.Board[i, j].Button);
                    }


                }
            }
        }

    }
}
