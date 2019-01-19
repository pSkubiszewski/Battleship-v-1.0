using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_v_1._0
{
    [Serializable]
    public class Cell
    {
        public Button Button { get; set; }
        public State BattleState { get; set; }
        public bool CanClick { get; set; }
        public Cell()
            {
            Button = new Button
            {
                BackColor = Color.AntiqueWhite
            };
            Button.Click += new EventHandler(Click);
            BattleState = new State();
            CanClick = true;
            }
        private void Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(VariableClass.GameReady && CanClick)
            {
                if (VariableClass.MyMove)
                {
                    byte[] a = Encoding.ASCII.GetBytes(Button.Tag.ToString());
                    VariableClass.Client.Client.Send(a);
                    CanClick = false;
                }
            }
            if(button.BackColor==Color.AntiqueWhite && !VariableClass.MePlayer.Ready &&CanClick)
            {
                button.BackColor = Color.Black;
                BattleState = State.Battle;
                VariableClass.BattleCount++;

                
            }
            else
            {
                button.BackColor = Color.AntiqueWhite;
                BattleState = State.Empty;
                VariableClass.BattleCount--;
            }
        }
    }


    public enum State
    {
        Empty,
        Battle,
        Hit
    }
}
