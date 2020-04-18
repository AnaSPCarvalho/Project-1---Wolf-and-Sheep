﻿using System;
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

        // Verifies if the sheep is at a certain position x,y
        private bool IsSheepAt(int x, int y)
        {
            // Verifies all the sheep coordinates.
            return (x == sheep[0][0] && y == sheep[0][1]) ||
                   (x == sheep[1][0] && y == sheep[1][1]) ||
                   (x == sheep[2][0] && y == sheep[2][1]) ||
                   (x == sheep[3][0] && y == sheep[3][1]);
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

        // Show all the moves that are possible possible for the sheep
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
            if (CanMoveSheep(idx, sheep[idx][0] - 1, sheep[idx][1] + 1))
            {
                Console.WriteLine("{0}, {1}", sheep[idx][0] - 1 + 1,
                    sheep[idx][1] + 1 + 1);
            }
            if (CanMoveSheep(idx, sheep[idx][0] + 1, sheep[idx][1] + 1))
            {
                Console.WriteLine("{0}, {1}", sheep[idx][0] + 1 + 1,
                    sheep[idx][1] + 1 + 1);
            }
        }

        /// Verifies if the sheep can move to x, y
		private bool CanMoveSheep(int idx, int x, int y)
        {
            // If idx isn't 0, 1, 2 or 3, return false
            if (idx < 0 || idx >= 4)
            {
                return false;
            }

            // if x or y aren't in 0..7, return false
            if (x < 0 || x >= 8 || y < 0 || y >= 8)
            {
                return false;
            }

            // If x or y aren't exactly 1 apart, return false
            if (Math.Abs(sheep[idx][0] - x) != 1 || Math.Abs(sheep[idx][1]
                - y) != 1)
            {
                return false;
            }

            // If the position has a sheep or the wolf, return false
            if (IsSheepAt(x, y) || wolf[0] == x && wolf[1] == y)
            {
                return false;
            }

            // Else it can move
            return true;
        }

        public bool MoveSheep(int idx, int x, int y)
        {
            // If it can move there, do it and return true
            if (CanMoveSheep(idx, x, y))
            {
                sheep[idx][0] = x;
                sheep[idx][1] = y;
                return true;
            }

            // Else return false
            return false;
        }

        // Prints the board
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
