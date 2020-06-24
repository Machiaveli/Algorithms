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
            expectedOutput[0] = 0;
            expectedOutput[1] = 20;
            expectedOutput[2] = 40;
            expectedOutput[3] = 50;
            expectedOutput[4] = -1;
            expectedOutput[5] = 30;
            expectedOutput[6] = 70;
            expectedOutput[7] = 60;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PathLengths;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void FindsShortestPathRouteFromSource()
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
            expectedOutput[0] = 0;
            expectedOutput[1] = 0;
            expectedOutput[2] = 5;
            expectedOutput[3] = 2;
            expectedOutput[4] = 0;
            expectedOutput[5] = 1;
            expectedOutput[6] = 3;
            expectedOutput[7] = 2;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PreviousNodes;

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
            expectedOutput[0] = 0;
            expectedOutput[1] = 20;
            expectedOutput[2] = 40;
            expectedOutput[3] = 50;
            expectedOutput[4] = -1;
            expectedOutput[5] = 30;
            expectedOutput[6] = 70;
            expectedOutput[7] = 60;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PathLengths;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void FindsShortestPathFromSourceWhenSourceWithComplexPath()
        {
            //Arrange    
            /**
            Create the below matrix
            [ -1][ 30][  1][  1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1][ 10][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1]
            [ -1][ 20][ -1][  2][ 30][ 40][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][ -1][ -1][  2][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][  8][ -1][ -1][ 12][ -1][ -1][ 50][ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][ -1][  3][ -1][ -1][ -1][100][ -1][ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][  1][ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][  2][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1]
            [ -1][ 10][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ 10][ -1][ -1][ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ 30][ -1][ -1][ -1][ -1][ 2 ][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][  1][100][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][ -1][ -1][ 12][ -1][ -1][ -1][ -1][ -1][ -1][  1][ -1]
            [ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][  2][ -1][ -1][ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][  2]
            [ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][  1][ -1][ -1][ -1][ -1][ -1]
            [  5][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ -1][ 40][ -1]
            **/
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

            int[] expectedOutput = new int[16];
            expectedOutput[0] = 0;
            expectedOutput[1] = 21;
            expectedOutput[2] = 1;
            expectedOutput[3] = 1;
            expectedOutput[4] = 31;
            expectedOutput[5] = 5;
            expectedOutput[6] = 8;
            expectedOutput[7] = 3;
            expectedOutput[8] = 43;
            expectedOutput[9] = 14;
            expectedOutput[10] = 11;
            expectedOutput[11] = 9;
            expectedOutput[12] = 12;
            expectedOutput[13] = 16;
            expectedOutput[14] = 10;
            expectedOutput[15] = 18;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PathLengths;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void EmptyMatrixHasNoPaths()
        {
            //Arrange    
            /**
            Create the below matrix
            [ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1]
            [ -1][ -1][ -1][ -1]
            **/
            int[][] m = Matrix.Create(4, 4);            

            int[] expectedOutput = new int[4];
            expectedOutput[0] = 0; //start node is 0 distance from self
            expectedOutput[1] = -1;
            expectedOutput[2] = -1;
            expectedOutput[3] = -1;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PathLengths;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void FindsShortestPathFromMiddleNode()
        {
            //Arrange    
            /**
            Create the below matrix
            [-1][-1][-1][ 5][-1]
            [ 3][-1][-1][-1][-1]
            [ 2][-1][-1][-1][-1]
            [10][ 3][ 3][-1][ 3]
            [ 5][-1][-1][-1][-1]
            **/
            int[][] m = Matrix.Create(5, 5);
            m[0][4] = 5;
            m[1][0] = 3;
            m[2][0] = 2;
            m[3][0] = 10;
            m[3][1] = 3;
            m[3][2] = 3;
            m[3][4] = 3;
            m[4][0] = 5;

            int[] expectedOutput = new int[5];
            expectedOutput[0] = 5;
            expectedOutput[1] = 3;
            expectedOutput[2] = 3;
            expectedOutput[3] = 0;
            expectedOutput[4] = 3;

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 3, 3).PathLengths;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void SourceNodeIsZeroDistanceFromSelf()
        {
            //Arrange    
            /**
            Create the below matrix
            [-1][10][ 3][-1]
            [20][-1][-1][15]
            [-1][-1][-1][ 5]
            [ 1][-1][-1][-1]            
            **/
            int[][] m = Matrix.Create(4, 4);
            m[0][1] = 10;
            m[0][2] = 3;
            m[1][0] = 20;
            m[1][3] = 15;
            m[2][3] = 5;
            m[3][0] = 1;

            int expectedOutput = 0;

            //Act
            int actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PathLengths[0];

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void NoErrorOnSingleNodeStructure()
        {
            //Arrange    
            /**
            Create the below matrix
            [-1]          
            **/
            int[][] m = Matrix.Create(1, 1);

            int[] expectedOutput = new int[1] { 0 };

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PathLengths;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void AlgorithmExitsWithCyclicGraph()
        {
            //Arrange    
            /**
            Create the below matrix
            [-1][10]
            [ 5][-1]         
            **/
            int[][] m = Matrix.Create(2, 2);
            m[0][1] = 10;
            m[1][0] = 5;

            int[] expectedOutput = new int[2] { 0, 10 };

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PathLengths;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [Test]
        public void AlgorithmExitsWithEmptyGraph()
        {
            //Arrange    
            /**
            Create the below matrix
            [-1][-1]
            [-1][-1]         
            **/
            int[][] m = Matrix.Create(2, 2);

            int[] expectedOutput = new int[2] { 0, -1 };

            //Act
            int[] actualOutput = Dijkstra.FindShortestPaths(m, 0, 0).PathLengths;

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);

        }
    }
}