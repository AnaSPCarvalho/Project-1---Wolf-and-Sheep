using System;
using System.Collections.Generic;
using System.Text;

namespace WAS
{
    // Board class, stores the positions of the Wolf and Sheep on the board
    class Board
    {
        // Position of the Wolf (X, Y)
        int[] wolf;

        // Position of the Sheep (X[0], Y[0]; X[1], Y[1]; ...)
        int[][] sheep;

        // Set initial positions of Wolf and Sheep
        public Board()
        {
            // Set the Wolf at the top
            wolf = new int[2] { 3, 0 };

            // Set all Sheep at the bottom
            sheep = new int[4][]
            {
                    new int[2] { 0, 7 },
                    new int[2] { 2, 7 },
                    new int[2] { 4, 7 },
                    new int[2] { 6, 7 },
            };
        }

        /// Checks if the wolf is at the bottom
        public bool IsWolfAtBottom()
        {
            // If the y of the wolf is 7, he's at the end
            return wolf[1] == 7;
        }

        /// Checks if the wolf is surrounded
        public bool IsWolfSurrounded()
        {
            // Return if there's a wall or sheep at each corner
            return IsSheepOrWallAt(wolf[0] - 1, wolf[1] - 1) &&
                   IsSheepOrWallAt(wolf[0] + 1, wolf[1] - 1) &&
                   IsSheepOrWallAt(wolf[0] - 1, wolf[1] + 1) &&
                   IsSheepOrWallAt(wolf[0] + 1, wolf[1] + 1);
        }

        /// Checks if a sheep or a wall is at position x, y
        private bool IsSheepOrWallAt(int x, int y)
        {
            // If x or y are negative or 8+, we're in a wall
            if (x < 0 || y < 0 || x >= 8 || y >= 8)
            {
                return true;
            }

            // Else check if a sheep is there
            return IsSheepAt(x, y);
        }

        // Verifies if the sheep is at a certain position x,y
        private bool IsSheepAt(int x, int y)
        {
            // Verifies all the sheep coordinates.
            return (x == sheep[0][0] && y == sheep[0][1]) ||
                   (x == sheep[1][0] && y == sheep[1][1]) ||
                   (x == sheep[2][0] && y == sheep[2][1]) ||
                   (x == sheep[3][0] && y == sheep[3][1]);
        }

        // Wolf's turn
        public void DoWolfTurn()
        {
            DisplayWolfMoves();


            // Get user input
            while (true)
            {

                Console.WriteLine("Usage: '<x> <y>'");
                String[] args = Console.ReadLine().Split();

                // If we didn't receive 2 arguments "x y" warn and retry
                if (args.Length != 2)
                {
                    Console.WriteLine("Must have 2 arguments'");
                    continue;
                }

                // Convert both arguments to x, y
                int x, y;
                if (!int.TryParse(args[0], out x))
                {
                    Console.WriteLine("x must be int!");
                    continue;
                }

                if (!int.TryParse(args[1], out y))
                {
                    Console.WriteLine("y must be int!");
                    continue;
                }

                // Move the Wolf
                if (MoveWolf(x - 1, y - 1))
                {
                    return;
                }
                else
                {
                    // Try again
                    Console.WriteLine("Can not move there!");
                    continue;
                }
            }
        }

        // Shows all the moves that are possible for the wolf piece.
        private void DisplayWolfMoves()
        {
            Console.WriteLine("Possible wolf moves:");
            if (CanMoveWolf(wolf[0] - 1, wolf[1] - 1))
            {
                Console.WriteLine("{0}, {1}", wolf[0] - 1 + 1, wolf[1] - 1 + 1);
            }
            if (CanMoveWolf(wolf[0] + 1, wolf[1] - 1))
            {
                Console.WriteLine("{0}, {1}", wolf[0] + 1 + 1, wolf[1] - 1 + 1);
            }
            if (CanMoveWolf(wolf[0] - 1, wolf[1] + 1))
            {
                Console.WriteLine("{0}, {1}", wolf[0] - 1 + 1, wolf[1] + 1 + 1);
            }
            if (CanMoveWolf(wolf[0] + 1, wolf[1] + 1))
            {
                Console.WriteLine("{0}, {1}", wolf[0] + 1 + 1, wolf[1] + 1 + 1);
            }
        }

        /// Verifies if the wolf can move to `x, y`
		private bool CanMoveWolf(int x, int y)
        {
            // if x or y aren't in 0..7, return false
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
            {
                return false;
            }

            // If x or y aren't exactly 1 apart, return false
            if (Math.Abs(wolf[0] - x) != 1 || Math.Abs(wolf[1] - y) != 1)
            {
                return false;
            }

            // If the position has a sheep, return false
            if (IsSheepAt(x, y))
            {
                return false;
            }

            // Else it can move
            return true;
        }

        // Tries to move the wolf to a position.		
        public bool MoveWolf(int x, int y)
        {
            // If it can move there, do it and return true
            if (CanMoveWolf(x, y))
            {
                wolf[0] = x;
                wolf[1] = y;
                return true;
            }

            // Else return false
            return false;
        }

        // Sheeps turn
		public void DoSheepTurn()
        {
            Console.WriteLine("Select a sheep!");

            // Get user input
            while (true)
            {

                Console.WriteLine("Usage: '<idx>'");
                // Convert it to an int
                int idx;

                if (!int.TryParse(Console.ReadLine(), out idx))
                {
                    Console.WriteLine("idx must be int!");
                    continue;
                }

                // Then try to do the Sheep's turn
                if (DoSingularSheepTurn(idx - 1))
                {
                    return;
                }

                else
                {
                    Console.WriteLine("Select another sheep!");
                    continue;
                }
            }
        }

        // Processes a single Sheep's turn
        private bool DoSingularSheepTurn(int idx)
        {
            // If `idx` isn't 0, 1, 2, 3, return false
            if (idx < 0 || idx >= 4) { return false; }

            DisplaySheepMoves(idx);


            // Get user input
            while (true)
            {

                Console.WriteLine("Usage: '<x> <y>'");

                String[] args = Console.ReadLine().Split();

                // If we received 1 argument and it's 'q' or 'Q', exit and rety
                if (args.Length == 1 && (args[0] == "q" || args[0] == "Q"))
                {
                    return false;
                }

                // If we didn't receive 2 arguments "x y" warn and retry
                if (args.Length != 2)
                {
                    Console.WriteLine("Must have 2 arguments'");
                    continue;
                }

                // Try to convert both arguments to ints
                int x, y;
                if (!int.TryParse(args[0], out x))
                {
                    Console.WriteLine("x must be int!");
                    continue;
                }

                if (!int.TryParse(args[1], out y))
                {
                    Console.WriteLine("y must be int!");
                    continue;
                }

                // And try to move the Sheep
                if (MoveSheep(idx, x - 1, y - 1))
                {
                    return true;
                }
                else
                {
                    // Try again
                    Console.WriteLine("Can not move there!");
                    continue;
                }
            }
        }

        // Show all the moves that are possible for the Sheep
        private void DisplaySheepMoves(int idx)
        {
            Console.WriteLine("Possible sheep {0} moves:", idx + 1);
            if (CanMoveSheep(idx, sheep[idx][0] - 1, sheep[idx][1] - 1))
            {
                Console.WriteLine("{0}, {1}", sheep[idx][0] - 1 + 1,
                    sheep[idx][1] - 1 + 1);
            }

            if (CanMoveSheep(idx, sheep[idx][0] + 1, sheep[idx][1] - 1))
            {
                Console.WriteLine("{0}, {1}", sheep[idx][0] + 1 + 1,
                    sheep[idx][1] - 1 + 1);
            }

        }

        // Checks if the Sheep can move to x, y
		private bool CanMoveSheep(int idx, int x, int y)
        {
            // If idx isn't 0, 1, 2 or 3
            if (idx < 0 || idx >= 4)
            {
                return false;
            }

            // if x or y aren't in 0..7
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
            {
                return false;
            }

            // If x or y aren't exactly 1 apart
            if (Math.Abs(sheep[idx][0] - x) != 1 || Math.Abs(sheep[idx][1]
                - y) != 1)
            {
                return false;
            }

            // If the position has a Sheep or the Wolf
            if (IsSheepAt(x, y) || wolf[0] == x && wolf[1] == y)
            {
                return false;
            }

            // Can move
            return true;
        }

        public bool MoveSheep(int idx, int x, int y)
        {

            if (CanMoveSheep(idx, x, y))
            {
                sheep[idx][0] = x;
                sheep[idx][1] = y;
                return true;
            }

            return false;
        }

        // Prints the board
        public void Display()
        {

            //Write instructions.
            Console.WriteLine("Wolf and Sheep\n\n*Instructions*\n" + "This " +
                "is a Player vs Player game.\n" + "One player will play as " +
                "the Wolf, while the other will play as the Sheep. \nThe " +
                "Wolf moves diagonally forward and backwards. \nThe Sheep " +
                "only moves diagonally forward.\nThe Wolf wins the game when" +
                " he gets to one of the sheep original houses.\nThe Sheep " +
                "wins the game when they block the Wolf so that it cannot " +
                "move.\nThe Wolf is represented with a W. The sheep are " +
                "represented with a number form 1 to 4.\nYou can only move " +
                "one sheep per turn.\n If you decide to change the sheep you" +
                " want to move, press q or Q, to select other sheep.\nThe " +
                "Wolf always moves first!\n\n");

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
