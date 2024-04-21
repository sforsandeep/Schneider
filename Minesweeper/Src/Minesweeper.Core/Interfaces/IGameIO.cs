using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Interfaces
{
    public interface IGameIO
    {
        void WriteMessage(string message, ConsoleColor? color = null);
        string ReadInput();
    }
}
