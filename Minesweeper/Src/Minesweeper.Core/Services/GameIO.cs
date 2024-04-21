using Minesweeper.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Services
{
    public class GameIO : IGameIO
    {



        public string ReadInput()
        {
            var keyInfo = Console.ReadKey(intercept: true); // 'intercept: true' prevents the key from displaying
            return keyInfo.KeyChar.ToString();
        }

        public void WriteMessage(string message, ConsoleColor? color = null)
        {
            var previousColor = Console.ForegroundColor;

            // If a color is provided, change the foreground color; otherwise, keep the default
            if (color.HasValue)
            {
                Console.ForegroundColor = color.Value;
            }

            Console.WriteLine(message);

            // Reset the color to the previous one
            Console.ForegroundColor = previousColor;
        }


    }
}
