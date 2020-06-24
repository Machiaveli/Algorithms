using Algorithms.Graphs;
using NUnit.Framework;

namespace AlgorithmTests
{
    public class MatrixTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create5By5Matrix()
        {
            //Arrange
            int rows = 5;
            int cols = 5;

            //Act
            int[][] m = Matrix.Create(rows, cols);


            //Assert
            Assert.AreEqual(rows, m.Length);

            for (int i = 0; i < m.Length; i++)
                Assert.AreEqual(cols, m[i].Length);
        }

        [Test]
        public void Create5By10Matrix()
        {
            //Arrange
            int rows = 5;
            int cols = 10;

            //Act
            int[][] m = Matrix.Create(rows, cols);


            //Assert
            Assert.AreEqual(rows, m.Length);

            for (int i = 0; i < m.Length; i++)
                Assert.AreEqual(cols, m[i].Length);
        }

        [Test]
        public void Create0By0Matrix()
        {
            //Arrange
            int rows = 0;
            int cols = 0;

            //Act
            int[][] m = Matrix.Create(rows, cols);


            //Assert
            Assert.AreEqual(rows, m.Length);

            for (int i = 0; i < m.Length; i++)
                Assert.AreEqual(cols, m[i].Length);
        }

        [Test]
        public void CreateMatrixInitializesAllVerticesToNegativeOne()
        {
            //Arrange
            int rows = 10;
            int cols = 10;

            //Act
            int[][] m = Matrix.Create(rows, cols);


            //Assert
            Assert.AreEqual(rows, m.Length);

            for (int i = 0; i < m.Length; i++)
                for (int x = 0; x < m[i].Length; x++)
                    Assert.AreEqual(-1, m[i][x]);
        }
    }
}