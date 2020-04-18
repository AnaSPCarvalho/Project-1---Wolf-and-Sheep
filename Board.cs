using System;
using System.Collections.Generic;
using System.Text;

namespace WAS
{
	/// Board class, stores the positions of the Wolf and Sheep on the board
	class Board
	{
		/// Position of the Wolf (X, Y)
		int[] wolf;
		
		/// Position of the Sheep (X[0], Y[0]; X[1], Y[1]; ...)
		int[][] sheep;
		
		/// Set initial positions of Wolf and Sheep
		public Board()
		{
			// Set the Wolf at the top
			wolf =  new int[2] { 3, 0 };
			
			// Set all Sheep at the bottom
			sheep = new int[4][] 
			{
					new int[2] { 0, 7 },
					new int[2] { 2, 7 },
					new int[2] { 4, 7 },
					new int[2] { 6, 7 },
			};
		}

        /// Prints the board
		public void Display()
        {
            // Write all xs
            Console.Write("  ");
            for (int x = 0; x < 8; x++)
            {
                Console.Write(x + 1);
            }
            Console.WriteLine();

            // Write the top line of the board box
            Console.WriteLine(" ┌────────┐");

            // Write all ines of the board
            for (int y = 0; y < 8; y++)
            {
                // Write the current y
                Console.Write(y + 1);

                // Write the left column
                Console.Write("│");

                // Write all columns
                for (int x = 0; x < 8; x++)
                {
                    // If this is a wolf, write a '#'
                    if (wolf[0] == x && wolf[1] == y)
                    {
                        Console.Write("º");
                    }

                    // Else if this is a sheep, write it's number
                    else if (sheep[0][0] == x && sheep[0][1] == y)
                    {
                        Console.Write("1");
                    }
                    else if (sheep[1][0] == x && sheep[1][1] == y)
                    {
                        Console.Write("2");
                    }
                    else if (sheep[2][0] == x && sheep[2][1] == y)
                    {
                        Console.Write("3");
                    }
                    else if (sheep[3][0] == x && sheep[3][1] == y)
                    {
                        Console.Write("4");
                    }

                    // Else if it's a non-moveable space, draw a block
                    else if ((x % 2 == 0 && y % 2 == 0) ||
                              (x % 2 == 1 && y % 2 == 1))
                    {
                        Console.Write("█");
                    }

                    // Else it's empty, write a ' ' (space)
                    else
                    {
                        Console.Write(" ");
                    }
                }

                // Write the right column
                Console.WriteLine("│");
            }

            // Write the bottom line of the board box
            Console.WriteLine(" └────────┘");
        }
    }
}
