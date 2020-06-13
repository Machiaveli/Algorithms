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
            int numberOfVertices = matrix.Length;
            bool[] visitedVertices = new bool[numberOfVertices];            
            int[] results = new int[numberOfVertices];            

            for (int j = 0; j <= numberOfVertices - 1; j++)            
                results[j] = matrix[sourceRow][j];            

            //No need to visit the source node 
            //unless it has an edge to itself
            if (matrix[sourceRow][sourceCol] == -1)
                visitedVertices[sourceCol] = true;
            
            for (int i = 2; i <= numberOfVertices; i++)
            {
                int min_index = GetIndexOfLowestWeightVertex(results, visitedVertices);

                if (min_index == -1) 
                    continue;

                visitedVertices[min_index] = true;

                for (int c = 0; c < results.Length; c++)
                {
                    if (!visitedVertices[c] && matrix[min_index][c] != -1 && (results[c] > results[min_index] + matrix[min_index][c] || results[c] == -1))                    
                        results[c] = results[min_index] + matrix[min_index][c];                    
                }
            }

            return results;
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
