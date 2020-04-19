using System;
using System.Collections.Generic;
using System.Text;

namespace WAS
{
    /// <summary>
    /// Board class stores the positions of the wolf and sheep on the board.
    /// </summary>
    class Board
    {
        // Position of the wolf.
        // [x, y]
        int[] wolf;

        // Position of the sheep.
        // [[x0, y0], [x1, y1], ...]
        int[][] sheep;


        /// <summary>
        /// Sets wolf and sheep positions.
        /// </summary>
        public Board()
        {
            // Sets the wolf at the top.
            wolf = new int[2] { 3, 0 };

            // Sets all sheep at the bottom. Each in a certain position.
            sheep = new int[4][] {
                new int[2] { 0, 7 },
                new int[2] { 2, 7 },
                new int[2] { 4, 7 },
                new int[2] { 6, 7 },
            };
        }

        /// <summary>
        /// Checks if the wolf is at the end of the board.
        /// </summary>
        /// <returns>Returns if the y of the wolf's position equals 7, which
        /// means the piece is at the bottom of the board.</returns>
        public bool IsWolfAtBottom()
        {
            // If the y of the wolf is 7, he's at the end.
            return wolf[1] == 7;
        }

        /// <summary>
        /// Checks if the wolf is surrounded.
        /// </summary>
        /// <returns>Returns if there is a sheep and/or a wall around the 
        /// wolf's position, to check if the wolf can move.</returns>
        public bool IsWolfSurrounded()
        {
            // Return if there's a wall or sheep at each corner.
            return IsSheepOrWallAt(wolf[0] - 1, wolf[1] - 1) &&
                   IsSheepOrWallAt(wolf[0] + 1, wolf[1] - 1) &&
                   IsSheepOrWallAt(wolf[0] - 1, wolf[1] + 1) &&
                   IsSheepOrWallAt(wolf[0] + 1, wolf[1] + 1);
        }

        /// <summary>
        /// Checks if a sheep or a wall is at position x, y.
        /// </summary>
        /// <param name="x"> Gets values inferior to 0 and higher or equal 
        /// to 8 </param>
        /// <param name="y"> Gets values inferior to 0 and higher or equal 
        /// to 8 </param>
        /// <returns> Returns 'true' if there is a wall, by checking if x or
        /// y have values under 0 or superior to 8. Else, it will verify if
        /// there is a sheep in there.</returns>
        private bool IsSheepOrWallAt(int x, int y)
        {
            // If x or y are negative or 8+, we're in a wall.
            if (x < 0 || y < 0 || x >= 8 || y >= 8)
            {
                return true;
            }

            // Else check if a sheep is there.
            return IsSheepAt(x, y);
        }

        /// <summary>
        ///  Checks if a sheep is at position x, y.
        /// </summary>
        /// <param name="x">Gets the x of the sheep position.</param>
        /// <param name="y">Gets the y of the sheep position.</param>
        /// <returns>Returns the coordinates of all the sheep
        /// positions.</returns>
        private bool IsSheepAt(int x, int y)
        {
            // Check all the sheep's coordinates.
            return (x == sheep[0][0] && y == sheep[0][1]) ||
                   (x == sheep[1][0] && y == sheep[1][1]) ||
                   (x == sheep[2][0] && y == sheep[2][1]) ||
                   (x == sheep[3][0] && y == sheep[3][1]);
        }

        /// <summary>
        ///  Processes the wolf turn.
        /// </summary>
        public void DoWolfTurn()
        {
            // Print the possible moves.
            DisplayWolfMoves();


            // Loop while we try to get user input.
            while (true)
            {

                Console.WriteLine("\nChoose a possible move.");
                // Read the line the user entered and split it by spaces.
                String[] args = Console.ReadLine().Split(',');

                // If we didn't receive 2 arguments "x,y" warn and retry.
                if (args.Length != 2)
                {
                    Console.WriteLine("Must have 2 arguments'");
                    continue;
                }

                // Try to convert both arguments to x,y.
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

                // And try to move the wolf.
                // `MoveWolf` returns `true` if successful.
                // `-1` because it's 0-based.
                if (MoveWolf(x - 1, y - 1))
                {
                    // Return if we succeeded.
                    return;
                }
                else
                {
                    // Else warn and try again.
                    Console.WriteLine("Can not move there!");
                    continue;
                }
            }
        }

        /// <summary>
        ///  Displays all moves possible by the wolf.
        /// </summary>
        private void DisplayWolfMoves()
        {
            Console.WriteLine("Possible wolf moves:");
            if (CanMoveWolf(wolf[0] - 1, wolf[1] - 1))
            {
                Console.WriteLine("{0},{1}", wolf[0] - 1 + 1, wolf[1] - 1 + 1);
            }
            if (CanMoveWolf(wolf[0] + 1, wolf[1] - 1))
            {
                Console.WriteLine("{0},{1}", wolf[0] + 1 + 1, wolf[1] - 1 + 1);
            }
            if (CanMoveWolf(wolf[0] - 1, wolf[1] + 1))
            {
                Console.WriteLine("{0},{1}", wolf[0] - 1 + 1, wolf[1] + 1 + 1);
            }
            if (CanMoveWolf(wolf[0] + 1, wolf[1] + 1))
            {
                Console.WriteLine("{0},{1}", wolf[0] + 1 + 1, wolf[1] + 1 + 1);
            }
        }

        /// <summary>
        ///  Checks if the wolf can move to `x, y`.
        /// </summary>
        /// <param name="x"> Gets values inferior to 0 and higher or equal 
        /// to 8</param>
        /// <param name="y"> Gets values inferior to 0 and higher or equal 
        /// to 8</param>
        /// <returns>Returns 'false' if the coordinates are not correct.
        /// Returns 'false' if there is a sheep at the position.
        /// Returns 'false' if the values of x and y are not betwen 0 and 7.
        /// Returns 'true' if the wolf piece can move.</returns>
        private bool CanMoveWolf(int x, int y)
        {
            // if x or y aren't in 0..7, return false.
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
            {
                return false;
            }

            // If x or y aren't exactly 1 apart, return false.
            if (Math.Abs(wolf[0] - x) != 1 || Math.Abs(wolf[1] - y) != 1)
            {
                return false;
            }

            // If the position has a sheep, return false.
            if (IsSheepAt(x, y))
            {
                return false;
            }

            // Else it can move.
            return true;
        }

        /// <summary>
        /// Tries to move the wolf to a position.
        /// </summary>
        /// <param name="x">Receives a value to move wolf to that position.
        /// </param>
        /// <param name="y">Receives a value to move wolf to that position.
        /// </param>
        /// <returns>/// Returns 'true' if the wolf piece can move to that
        /// position, else returns 'false'.</returns>
        public bool MoveWolf(int x, int y)
        {
            // If it can move there, do it and return true.
            if (CanMoveWolf(x, y))
            {
                wolf[0] = x;
                wolf[1] = y;
                return true;
            }

            // Else return false.
            return false;
        }

        /// <summary>
        ///  Processes the sheep turn.
        /// </summary>
        public void DoSheepTurn()
        {
            // Loop while we try to get user input.
            while (true)
            {

                Console.WriteLine("Select the number of a sheep.");
                // Read the line and try to convert it to an int.
                int idx;
                if (!int.TryParse(Console.ReadLine(), out idx))
                {
                    Console.WriteLine("Number must be int!");
                    continue;
                }

                // Then try to do the sheep's turn, if it returns true
                // it succeded, else we retry.
                // `-1` because 0-based.
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

        /// <summary>
        /// Processes a single sheep's turn.
        /// if the player wants to choose another sheep       
        /// </summary>
        /// <param name="idx">Receives values betwen 0 and 3.</param>
        /// <returns> Returns ' false' if idx is inferior to 0 or superior
        /// and equal to 4, else returns 'true'.</returns>
        private bool DoSingularSheepTurn(int idx)
        {
            // If `idx` isn't 0, 1, 2, 3, return false.
            if (idx < 0 || idx >= 4) { return false; }

            // Display sheep moves.
            DisplaySheepMoves(idx);


            // Loop while we try to get user input.
            while (true)
            {

                Console.WriteLine("\nChoose a possible move.");
                // Read the line the user entered and split it by spaces.
                String[] args = Console.ReadLine().Split(',');

                // If we received 1 argument and it's 'q' or 'Q', exit and rety.
                if (args.Length == 1 && (args[0] == "q" || args[0] == "Q"))
                {
                    return false;
                }

                // If we didn't receive 2 arguments "x y" warn and retry.
                if (args.Length != 2)
                {
                    Console.WriteLine("Must have 2 arguments'");
                    continue;
                }

                // Try to convert both arguments to ints.
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

                // And try to move the sheep.
                // `MoveSheep` returns `true` if successful.
                // `-1` because it's 0-based.
                if (MoveSheep(idx, x - 1, y - 1))
                {
                    // Return if we succeeded.
                    return true;
                }
                else
                {
                    // Else warn and try again.
                    Console.WriteLine("Can not move there!");
                    continue;
                }
            }
        }

        /// <summary>
        /// Displays all moves possible by the `idx`of the sheep.
        /// </summary>
        /// <param name="idx">Receives the value of the actual sheep position,
        /// to show the possible moves.</param>
        private void DisplaySheepMoves(int idx)
        {
            Console.WriteLine("Possible sheep {0} moves:", idx + 1);
            if (CanMoveSheep(idx, sheep[idx][0] - 1, sheep[idx][1] - 1))
            {
                Console.WriteLine("{0},{1}", sheep[idx][0] - 1 + 1,
                    sheep[idx][1] - 1 + 1);
            }
            if (CanMoveSheep(idx, sheep[idx][0] + 1, sheep[idx][1] - 1))
            {
                Console.WriteLine("{0},{1}", sheep[idx][0] + 1 + 1,
                    sheep[idx][1] - 1 + 1);
            }

        }

        /// <summary>
        /// Checks if the `idx`th sheep can move to x, y.
        /// </summary>
        /// <param name="idx">Receives value to move a specific sheep.</param>
        /// <param name="x">Receives value to move sheep to that position.
        /// </param>
        /// <param name="y">Receives value to move sheep to that position.
        /// </param>
        /// <returns>Returns 'false' if idx isn't between 0 and 3.
        /// Returns 'false' if x and y aren't between 0 and 7.
        /// Returns 'false' if y is superior to the idx of the sheep.
        /// Returns 'false' if x and y aren't exactly 1 value apart.
        /// Returns 'false' if the position has a sheep or the wolf.
        /// Else it returns 'true' and the sheep can move.</returns>
        private bool CanMoveSheep(int idx, int x, int y)
        {
            // If idx isn't 0, 1, 2 or 3, return false.
            if (idx < 0 || idx >= 4)
            {
                return false;
            }

            // if x or y aren't in 0..7, return false.
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
            {
                return false;
            }

            if (y > sheep[idx][1])
            {
                return false;
            }
            // If x or y aren't exactly 1 apart, return false.
            if (Math.Abs(sheep[idx][0] - x) != 1 ||
                Math.Abs(sheep[idx][1] - y) != 1)
            {
                return false;
            }

            // If the position has a sheep or the wolf, return false.
            if (IsSheepAt(x, y) || wolf[0] == x && wolf[1] == y)
            {
                return false;
            }

            // Else it can move.
            return true;
        }
        /// <summary>
        /// Moves the sheep to x,y.
        /// </summary>
        /// <param name="idx">explicar para que serve este parametro</param>
        /// <param name="x">explicar para que serve este parametro</param>
        /// <param name="y">explicar para que serve este parametro</param>
        /// <returns>Returns 'true' if the sheep can move to the x, y position.
        /// Else it returns 'false'.</returns>
        public bool MoveSheep(int idx, int x, int y)
        {
            // If it can move there, do it and return true.
            if (CanMoveSheep(idx, x, y))
            {
                sheep[idx][0] = x;
                sheep[idx][1] = y;
                return true;
            }

            // Else return false.
            return false;
        }

        /// <summary>
        /// Prints the board.
        /// </summary>
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

            // Write all xs.
            Console.Write("    ");
            for (int x = 0; x < 8; x++)
            {
                Console.Write(x + 1);
                Console.Write("  ");
            }
            Console.WriteLine();

            // Write the top line of the board box.
            Console.WriteLine(" ┌─────────────────────────┐");

            // Write all lines of the board.
            for (int y = 0; y < 8; y++)
            {
                // Write the current y.
                Console.Write(y + 1);

                // Write the left column.
                Console.Write("│");
                Console.Write("│");

                // Write all columns.
                for (int x = 0; x < 8; x++)
                {
                    // If this is a wolf, write a 'W'
                    if (wolf[0] == x && wolf[1] == y)
                    {
                        Console.Write(" W ");
                    }

                    // Else if this is a sheep, write it's number.
                    else if (sheep[0][0] == x && sheep[0][1] == y)
                    {
                        Console.Write(" 1 ");
                    }
                    else if (sheep[1][0] == x && sheep[1][1] == y)
                    {
                        Console.Write(" 2 ");
                    }
                    else if (sheep[2][0] == x && sheep[2][1] == y)
                    {
                        Console.Write(" 3 ");
                    }
                    else if (sheep[3][0] == x && sheep[3][1] == y)
                    {
                        Console.Write(" 4 ");
                    }

                    // Else if it's a non-moveable space, draw a block.
                    else if ((x % 2 == 0 && y % 2 == 0) ||
                              (x % 2 == 1 && y % 2 == 1))
                    {
                        Console.Write("███");
                    }

                    // Else it's empty, write a ' ' (space).
                    else
                    {
                        Console.Write("   ");
                    }
                }

                // Write the right column.
                Console.WriteLine("│");

            }

            // Write the bottom line of the board box.
            Console.WriteLine(" └─────────────────────────┘");
        }
    }
}
