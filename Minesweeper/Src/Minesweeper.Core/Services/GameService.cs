using Minesweeper.Core.Enums;
using Minesweeper.Core.Interfaces;
using Minesweeper.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Services
{
    /// <summary>
    /// Manages the game logic for Minesweeper.
    /// </summary>
    public class GameService
    {
        private readonly Board board;
        private readonly Player player;
        private readonly IGameIO gameIO;
        private bool gameOver = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="GameService"/> class.
        /// </summary>
        /// <param name="boardWidth">Width of the game board.</param>
        /// <param name="boardHeight">Height of the game board.</param>
        /// <param name="mines">Number of mines on the board.</param>
        /// <param name="lives">Number of lives the player has.</param>
        /// <param name="gameIO">The input/output service for the game.</param>
        /// <exception cref="ArgumentNullException">Thrown if gameIO is null.</exception>

        public GameService(int boardWidth, int boardHeight, int mines, int lives, IGameIO gameIO)
        {
            this.gameIO = gameIO ?? throw new ArgumentNullException(nameof(gameIO));

            board = new Board(boardWidth, boardHeight, mines);
            player = new Player(lives, boardWidth, boardHeight);
        }
        public bool IsGameOver => gameOver;

        public int PlayerLives => player.Lives; // Expose the number of lives left


        // Public method to start the game logic
        public void Start()
        {
            gameIO.WriteMessage("Welcome to Minesweeper!");
            DisplayBoardInfo();

            string playAgain;
            do
            {
                gameIO.WriteMessage("*****************");
                gameIO.WriteMessage("Your first position A1");
                gameIO.WriteMessage("*****************");
                
                GameStatus gameStatus = PlayGame();
   


                playAgain = gameIO.ReadInput().Trim().ToLower();
            } while (playAgain == "y");
        }

        private void DisplayBoardInfo()
        {

            gameIO.WriteMessage($"Board size: {board.Width}x{board.Height} with {board.MineCount} mines.");
            gameIO.WriteMessage("Move with U (up), D (down), L (left), R (right). X to Break");
        }

        /// <summary>
        /// Runs a single game session until the player wins, loses, or exits.
        /// </summary>
        /// <returns>The status of the game after the session ends.</returns>
        private GameStatus PlayGame()
        {

            player.Reset();
            GameStatus status = GameStatus.Started;
            while (player.Lives > 0 && !gameOver)
            {
                //gameIO.WriteMessage($"Your move (Lives: {player.Lives}, Moves: {player.Moves}): ");
                var moveInput = gameIO.ReadInput();

                if (string.IsNullOrEmpty(moveInput) || moveInput.Length != 1)
                {
                    gameIO.WriteMessage("Invalid input, please enter a single character for direction (U, D, L, R).");
                    continue;
                }

                char move = moveInput[0];
                if (char.ToUpper(move) == 'X')
                {
                    status = GameStatus.Break;
                    break;
                }
                try
                {
                    player.Move(move);
                    char m = char.ToUpper(moveInput[0]);
                    DisplayPosition(m);

                    if (board.CheckForMine(player.X, player.Y))
                    {
                        gameIO.WriteMessage("Boom! You hit a mine.", ConsoleColor.Red);
                        player.HitMine();

                        if (player.Lives <= 0)
                        {
                            gameIO.WriteMessage("Game over! You've run out of lives.", ConsoleColor.Red);
                            status = GameStatus.LifeOver;
                        }
                    }

                    if (CheckWon(player.X, player.Y))
                    {
                        gameIO.WriteMessage("Great! You have done it.", ConsoleColor.Green);
                        status = GameStatus.Won;
                        break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    gameIO.WriteMessage(ex.Message, ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    gameIO.WriteMessage($"An error occurred: {ex.Message}", ConsoleColor.Red);
                }
            }

            return status;
        }
        /// <summary>
        /// Checks if the player has won the game by reaching the bottom row or right column.
        /// </summary>
        /// <param name="x">The current X position of the player.</param>
        /// <param name="y">The current Y position of the player.</param>
        /// <returns>true if the player has won; otherwise, false.</returns>
        private bool CheckWon(int x, int y)
        {
            if (x == board.Width - 1 || y == board.Height - 1) // when extreme bottom row or extreme right row
            {

                gameIO.WriteMessage($"You won in {player.Moves} moves!", ConsoleColor.Green);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void DisplayPosition(char move)
        {
            // Convert column number to a letter (assuming 'A' corresponds to 0)
            char columnLetter = (char)('A' + player.X);
            // Row number is simply Y + 1
            int rowNumber = player.Y + 1;

            string position = $"{columnLetter}{rowNumber}";
            string lastMove = move != default(char) ? $"Last Move: {move}, " : string.Empty;

            gameIO.WriteMessage($"{lastMove}You are At {position}");
        }
    }
}
