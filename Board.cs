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
	}
}
