using Minesweeper.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tests
{
    public class BoardTest
    {
        [Fact]
        public void Board_CreatesCorrectNumberOfMines()
        {
            var board = new Board(10, 10, 20);
            int mineCount = 0;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (board.CheckForMine(x, y))
                        mineCount++;
                }
            }
            Assert.Equal(20, mineCount);
        }

        [Theory]
        [InlineData(-1, 5)]
        [InlineData(10, 0)]
        [InlineData(0, -1)]
        [InlineData(5, 10)]
        public void Board_PlayerReachOutOfBounds(int x, int y)
        {
            var board = new Board(10, 10, 10);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => board.CheckForMine(x, y));
        }
    }
}
