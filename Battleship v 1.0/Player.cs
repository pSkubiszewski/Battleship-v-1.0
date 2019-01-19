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
    [Serializable]
    public class Player
    {
        public string Name { get; set; }
        public IPEndPoint Ip{ get; set; }
        public Cell[,] Board { get; set; }
        public bool Ready { get; set; }
        
        public Player()
        {
            Name = "";
            Ready = false;
            Board = new Cell[10, 10];
        }
        
    }
}
