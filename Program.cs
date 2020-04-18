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

            // Display the board
            board.Display();


        }
    }
}