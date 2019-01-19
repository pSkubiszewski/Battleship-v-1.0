using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_v_1._0
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            VariableClass.MePlayer = new Player();
            VariableClass.OpPlayer = new Player();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if(NickNameTBox.Text.Length>0)
            {
                VariableClass.MePlayer.Name = NickNameTBox.Text;
                MenuForm mf = new MenuForm();
                mf.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Podaj swój Nick");
            }
        }
    }
}
