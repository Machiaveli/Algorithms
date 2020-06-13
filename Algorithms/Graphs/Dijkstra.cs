using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Algorithms.Graphs
{
    public static class Dijkstra
    {
        public static int[] FindShortestPaths(int[][] matrix, int sourceRow, int sourceCol)
        {
            bool[] S = new bool[matrix.Length];
            int N = matrix.Length;
            int[] W = new int[matrix.Length];

            for (int j = 0; j <= N - 1; j++)
            {
                W[j] = matrix[sourceRow][j];
            }

            //No need to visit the source node 
            //unless it has an edge to itself
            if (matrix[sourceRow][sourceCol] == -1)
                S[sourceCol] = true;
            
            for (int i = 2; i <= N; i++)
            {
                int min_index = GetIndexOfLowestWeightVertex(W, S);

                if (min_index == -1) 
                    continue;

                S[min_index] = true;

                for (int c = 0; c < W.Length; c++)
                {
                    if (!S[c] && matrix[min_index][c] != -1 && (W[c] > W[min_index] + matrix[min_index][c] || W[c] == -1))
                    {
                        W[c] = W[min_index] + matrix[min_index][c];
                    }
                }
            }

            return W;
        }

        private static int GetIndexOfLowestWeightVertex(int[] searchSet, bool[] exclusions)
        {
            if (searchSet is null || searchSet.Length == 0)
                return -1;            

            int lowestValue = int.MaxValue;
            int index = -1;

            for (int i = 1; i < searchSet.Length; i++)
            {
                if (searchSet[i] != -1 && searchSet[i] < lowestValue && !exclusions[i])
                {
                    lowestValue = searchSet[i];
                    index = i;
                }
            }

            return index;
        }
    }
}
