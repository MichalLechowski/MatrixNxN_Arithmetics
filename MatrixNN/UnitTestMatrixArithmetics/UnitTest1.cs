using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace UnitTestMatrixArithmetics
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void Add_OK()
        {
            //arrange
            int[,] testTab1 = new int[,]
            {
                {0, 2, 2, 2, 4},
                {1, 1, 2, 3, 3},
                {1, 1, 2, 3, 3},
                {1, 3, 5, 3, 3},
                {4, 5, 5, 5, 4}
            };

            int[,] testTab2 = new int[,]
            {
                {0, 1, 2, 3},
                {1, 1, 2, 3},
                {2, 2, 2, 3},
                {3, 3, 3, 3},
            };

            int[,] testTab3 = new int[,]
            {
                {1, 2, 3},
                {1, 2, 3},
                {2, 2, 3},
            };

            int[,] expectedOutput1 = new int[,] { { 8, 20 }, { 12, 4 } };
            int[,] expectedOutput2 = new int[,] { { 3, 6 }, { 6, 3 } };
            int[,] expectedOutput3 = new int[,] { { 2, 2 }, { 3, 1 } };

            //act
            int[,] temp1 = MatrixArithmetics.Add(testTab1);
            int[,] temp2 = MatrixArithmetics.Add(testTab2);
            int[,] temp3 = MatrixArithmetics.Add(testTab3);

            //assert
            Assert.AreEqual(expectedOutput1[0,0], temp1[0,0]);
            Assert.AreEqual(expectedOutput1[1,1], temp1[1,1]);
            Assert.AreEqual(expectedOutput1[0,1], temp1[0,1]);
            Assert.AreEqual(expectedOutput1[1,0], temp1[1,0]);

            Assert.AreEqual(expectedOutput2[0, 0], temp2[0, 0]);
            Assert.AreEqual(expectedOutput2[1, 1], temp2[1, 1]);
            Assert.AreEqual(expectedOutput2[0, 1], temp2[0, 1]);
            Assert.AreEqual(expectedOutput2[1, 0], temp2[1, 0]);

            Assert.AreEqual(expectedOutput3[0, 0], temp3[0, 0]);
            Assert.AreEqual(expectedOutput3[1, 1], temp3[1, 1]);
            Assert.AreEqual(expectedOutput3[0, 1], temp3[0, 1]);
            Assert.AreEqual(expectedOutput3[1, 0], temp3[1, 0]);

        }
    }
}
