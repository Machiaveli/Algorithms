
using System.Data;

namespace Algorithms.Graphs
{
    public static class Dijkstra
    {
        /// <summary>
        /// Finds the shortest path between the source node 
        /// and all other nodes in the graph
        /// </summary>
        /// <param name="matrix">The adjacency matrix describing our graph</param>
        /// <param name="sourceRow">The row index of our source node</param>
        /// <param name="sourceCol">The column index of our source node</param>
        /// <returns></returns>
        public static DijkstraResult FindShortestPaths(int[][] matrix, int sourceRow, int sourceCol)
        {
            int numberOfVertices = matrix.Length;
            bool[] visitedVertices = new bool[numberOfVertices];            
            int[] shortestPaths = new int[numberOfVertices];                                //The shortest distance between the source node and the specified node.
            int[] previousNodes = new int[numberOfVertices];                                //Previously visited shortest distance node to reach the vertex            

            for (int j = 0; j <= numberOfVertices - 1; j++)
            {
                shortestPaths[j] = matrix[sourceRow][j];                                    //Set the distance from source to each neighbhour
                previousNodes[j] = sourceCol;                                               //Initialise each previous to -1
            }

            shortestPaths[sourceCol] = 0;                                                   //Source is always 0 distance from self
            
            for (int i = 2; i <= numberOfVertices; i++)
            {
                int min_index = GetIndexOfLowestWeightVertex(shortestPaths, visitedVertices);     //Could replace this with a Min priority Queue

                if (min_index == -1)                                                        //No valid min index found.
                    continue;

                visitedVertices[min_index] = true;                                          //Mark current min_index as having been visited
                
                for (int c = 0; c < shortestPaths.Length; c++)
                {
                    if (matrix[min_index][c] != -1 &&                                       //There is a valid path AND
                        (shortestPaths[c] == -1 ||                                          //We do not yet have a minumum weighet path for this vertex OR
                        shortestPaths[c] > shortestPaths[min_index] + matrix[min_index][c]) //We have found a shorter minimum weighet path
                        )
                    {
                        shortestPaths[c] = shortestPaths[min_index] + matrix[min_index][c]; //Update our shortest path
                        previousNodes[c] = min_index;                                       //Set the previous node
                    }
                }
            }

            return new DijkstraResult(shortestPaths, previousNodes);            
        }

        //Greater efficiency could be gained by replacing this method with a minimum priority queue.
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

    //TODO: Replace once a proper structure has been created for representing the graphs.
    public class DijkstraResult
    {
        public int[] PathLengths { get; }

        public int[] PreviousNodes { get; }

        public DijkstraResult(int[] pathLengths, int[] previousNodes)
        {
            PathLengths = pathLengths;
            PreviousNodes = previousNodes;
        }
    }
}
