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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void CreateServerButton_Click(object sender, EventArgs e)
        {
            CreateServerForm CreateForm = new CreateServerForm();
            
            CreateForm.Show();

            Hide();
            
        }

        private void FindServerButton_Click(object sender, EventArgs e)
        {
            SearchForm ff = new SearchForm();
            ff.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
