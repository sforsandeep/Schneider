using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Models
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        public int MineCount { get; private set; }  // Adding this property
        private bool[,] Mines;

        public Board(int width, int height, int mines)
        {
            Width = width;
            Height = height;
            MineCount = mines;
            Mines = new bool[width, height];
            RandomizeMines(mines);
        }

        //there wont be any mines in 0,0 since player start from there
        private void RandomizeMines(int mines)
        {
            Random rnd = new Random();
            int placedMines = 0; // Keep track of how many mines we have placed

            while (placedMines < mines)
            {
                int x = rnd.Next(Width);
                int y = rnd.Next(Height);

                // If it's the starting cell or there's already a mine, skip this iteration
                if ((x == 0 && y == 0) || Mines[x, y])
                {
                    continue;
                }

                // Place the mine and increment the count
                Mines[x, y] = true;
                placedMines++;
            }
        }


        public bool CheckForMine(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException("Attempted to check a mine outside the boundaries of the board.");

            return Mines[x, y];
        }
    }
}
