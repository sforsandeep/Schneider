using Minesweeper.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void Player_MovesWithinBoundaries()
        {
            // Arrange
            var player = new Player(3, 8, 8);

            // Act
            player.Move('R'); // Move right

            // Assert
            Assert.Equal(1, player.X); 
        }

        [Fact]
        public void Player_MoveOutOfBounds()
        {
            // Arrange
            var player = new Player(3, 8, 8);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => player.Move('U')); // Move up from (0,0)
        }
    }
}
