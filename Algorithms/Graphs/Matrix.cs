using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Graphs
{
    public static class Matrix
    {
        public static int[][] Create(int rows, int cols)
        {
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
                matrix[i] = Enumerable.Repeat(-1, cols).ToArray();
                

            return matrix;
        }
    }
}
