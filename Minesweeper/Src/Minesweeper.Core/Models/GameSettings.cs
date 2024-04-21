using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Models
{
    public class GameSettings
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public int Mines { get; set; }
        public int Lives { get; set; }
    }
}
