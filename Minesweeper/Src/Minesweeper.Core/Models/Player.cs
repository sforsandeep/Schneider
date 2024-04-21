using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Models
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Lives { get; private set; }
        public int Moves { get; private set; }

        private readonly int initialLives;
        private readonly int boardWidth;
        private readonly int boardHeight;

        public Player(int initialLives, int boardWidth, int boardHeight)
        {
            this.initialLives = initialLives;
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            Reset();
        }

        public void Move(char direction)
        {
            int newX = X, newY = Y;
            direction = char.ToUpper(direction);
            switch (direction)
            {
                case 'U': newY--; break;
                case 'D': newY++; break;
                case 'L': newX--; break;
                case 'R': newX++; break;
                default:
                    throw new ArgumentException("Invalid move direction. Use 'U', 'D', 'L', or 'R'.", nameof(direction));
            }
            if (newX >= 0 && newX < boardWidth && newY >= 0 && newY < boardHeight)
            {
                X = newX;
                Y = newY;
                Moves++;
            }
            else
            {
                throw new InvalidOperationException("Move is out of board boundaries.");
            }
        }

        public void HitMine()
        {
            Lives--;
        }

        /// <summary>
        /// Resets the player's position, lives, and move count.
        /// </summary>
        public void Reset()
        {
            X = 0;
            Y = 0;
            Lives = initialLives;
            Moves = 0;
        }
    }
}
