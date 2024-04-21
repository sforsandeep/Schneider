using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Enums
{
    public enum GameStatus
    {
        NotStarted = 0,
        Started = 1,
        Won = 2,
        LifeOver = 3,
        Break = 4
    }
}
