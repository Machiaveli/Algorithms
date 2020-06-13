using Algorithms.Graphs;
using NUnit.Framework;

namespace AlgorithmTests
{
    public class DijkstraTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FindsShortestPathFromSource()
        {
            //Arrange            
            /**
             * Create the below matrix
             * [-1][20][-1][60][-1][-1][90][-1]
             * [-1][-1][-1][-1][-1][10][-1][-1]
             * [-1][-1][-1][10][-1][50][-1][20]
             * [-1][-1][10][-1][-1][-1][20][-1]
             * [-1][50][-1][-1][-1][-1][30][-1]
             * [-1][-1][10][40][-1][-1][-1][-1]
             * [20][-1][-1][-1][-1][-1][-1][-1]
             * [-1][-1][-1][-1][-1][-1][-1][-1]
             * **/
            int[][] m = Matrix.Create(8, 8);
            m[0][1] = 20;
            m[0][1] = 20;
            m[0][3] = 60;
            m[0][3] = 90;
            m[1][5] = 10;
            m[2][3] = 10;
            m[2][5] = 50;
            m[2][7] = 20;
            m[3][2] = 10;
            m[3][6] = 20;
            m[4][1] = 50;
            m[4][6] = 30;
            m[5][2] = 10;
            m[5][3] = 40;
            m[6][0] = 20;

            int[] expectedOutput = new int[8];
            expectedOutput[0] = -1;
            expectedOutput[1] = 20;
            expectedOutput[2] = 40;
            expectedOutput[3] = 50;
            expectedOutput[4] = -1;
            expectedOutput[5] = 30;
            expectedOutput[6] = 70;
            expectedOutput[7] = 60;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void FindsShortestPathFromSourceWhenSourcesHasEdgeToItself()
        {
            //Arrange            
            /**
             * Create the below matrix
             * [5][20][-1][60][-1][-1][90][-1]
             * [-1][-1][-1][-1][-1][10][-1][-1]
             * [-1][-1][-1][10][-1][50][-1][20]
             * [-1][-1][10][-1][-1][-1][20][-1]
             * [-1][50][-1][-1][-1][-1][30][-1]
             * [-1][-1][10][40][-1][-1][-1][-1]
             * [20][-1][-1][-1][-1][-1][-1][-1]
             * [-1][-1][-1][-1][-1][-1][-1][-1]
             * **/
            int[][] m = Matrix.Create(8, 8);
            m[0][0] = 5;
            m[0][1] = 20;
            m[0][1] = 20;
            m[0][3] = 60;
            m[0][3] = 90;
            m[1][5] = 10;
            m[2][3] = 10;
            m[2][5] = 50;
            m[2][7] = 20;
            m[3][2] = 10;
            m[3][6] = 20;
            m[4][1] = 50;
            m[4][6] = 30;
            m[5][2] = 10;
            m[5][3] = 40;
            m[6][0] = 20;

            int[] expectedOutput = new int[8];
            expectedOutput[0] = 5;
            expectedOutput[1] = 20;
            expectedOutput[2] = 40;
            expectedOutput[3] = 50;
            expectedOutput[4] = -1;
            expectedOutput[5] = 30;
            expectedOutput[6] = 70;
            expectedOutput[7] = 60;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void FindsShortestPathFromSourceWhenSourceWithComplexPath()
        {
            //Arrange            
            /**
             * Create the below matrix
             * [5][20][-1][60][-1][-1][90][-1]
             * [-1][-1][-1][-1][-1][10][-1][-1]
             * [-1][-1][-1][10][-1][50][-1][20]
             * [-1][-1][10][-1][-1][-1][20][-1]
             * [-1][50][-1][-1][-1][-1][30][-1]
             * [-1][-1][10][40][-1][-1][-1][-1]
             * [20][-1][-1][-1][-1][-1][-1][-1]
             * [-1][-1][-1][-1][-1][-1][-1][-1]
             * **/
            int[][] m = Matrix.Create(16, 16);
            m[0][1] = 30;
            m[0][2] = 1;
            m[0][3] = 1;                      
            m[1][4] = 10;
            m[2][1] = 20;
            m[2][3] = 2;
            m[2][4] = 30;
            m[2][5] = 40;
            m[3][7] = 2;
            m[4][5] = 8;
            m[4][8] = 12;
            m[4][11] = 50;
            m[5][6] = 3;
            m[5][10] = 100;
            m[6][11] = 1;
            m[7][5] = 2;
            m[8][1] = 10;
            m[8][9] = 10;
            m[9][8] = 30;
            m[9][13] = 2;
            m[10][12] = 1;
            m[10][13] = 100;
            m[11][7] = 12;
            m[11][14] = 1;
            m[12][9] = 2;
            m[13][15] = 2;
            m[14][10] = 1;
            m[15][0] = 5;
            m[15][14] = 40;

            int[] expectedOutput = new int[8];
            expectedOutput[0] = 5;
            expectedOutput[1] = 20;
            expectedOutput[2] = 40;
            expectedOutput[3] = 50;
            expectedOutput[4] = -1;
            expectedOutput[5] = 30;
            expectedOutput[6] = 70;
            expectedOutput[7] = 60;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}