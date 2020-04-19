using System;

namespace WAS
{
    /// <summary>
    /// Main class for the whole program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry function.
        /// </summary>
        /// <param name="args">explicar para que serve este parametro</param>
        static void Main(string[] args)
        {
            // Set console to accept 'utf-8' which will allow us
            //to put different characters, like the full bar.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Create a new board for the whole game.
            Board board = new Board();

            // If the current turn is the wolf's.
            bool isWolfTurn = true;

            // While the wolf isn't at the bottom and the sheep
            // don't have the wolf surrounded, the game will continue.
            while (true)
            {
                if (board.IsWolfAtBottom())
                {
                    board.Display();

                    Console.WriteLine("\nWOLF WON!!");
                    break;
                }

                else if (board.IsWolfSurrounded())
                {
                    board.Display();

                    Console.WriteLine("\nSHEEP WON!");
                    break;
                }

                // Display the board.
                board.Display();

                // Check the turn.
                if (isWolfTurn)
                {
                    Console.WriteLine("Wolf, move!\n");
                    board.DoWolfTurn();
                    board.DoWolfTurn();
                }
                else
                {
                    Console.WriteLine("Sheep, move!\n");
                    board.DoSheepTurn();
                }

                // And set the turn as the other one.
                isWolfTurn = !isWolfTurn;
            }

            // Wait for newkey.
            Console.WriteLine("Press enter to exit!");
            Console.ReadLine();
        }
    }
}