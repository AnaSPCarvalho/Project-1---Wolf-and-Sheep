using System;

namespace WAS
{
    class Program
    {
        /// Entry function
        static void Main()
        {
            // Set console to accept 'utf-8'
            // For certain characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Create a new board for the whole game
            Board board = new Board();

            // If the current turn is the Wolf's
            bool isWolfTurn = true;

			while (true)
			{

                //Check if the game is over
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

                // Display the board
                board.Display();

				// Check the turn
				if (isWolfTurn)
				{
					Console.WriteLine("Wolf, move!");
					board.DoWolfTurn();
				}

				else
				{
					Console.WriteLine("Sheep, move!");
					board.DoSheepTurn();
				}

				// And set the turn as the other one
				isWolfTurn = !isWolfTurn;
			}

			// Wait for newkey
			Console.WriteLine("Press enter to exit!");
			Console.ReadLine();
		}
    }
}