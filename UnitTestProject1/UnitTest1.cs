using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void GetQuant_Pord3Mat1_Return2271()
        {
            //Arrange
            int productType = 1, materialType = 1, count = 7, expected = 2271;
            float width = 14, dlina = 21;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        
        [TestMethod()]
        public void GetQuant_Pord1Mat1_Return9()
        {
            //Arrange
            int productType = 1, materialType = 1, count = 1, expected = 9;
            float width = 2, dlina = 4;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_Pord2Mat1_Return2608()
        {
            //Arrange
            int productType = 2, materialType = 1, count = 10, expected = 2608;
            float width = 13, dlina = 8;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_Pord1Mat2_Return6399()
        {
            //Arrange
            int productType = 3, materialType = 2, count = 15, expected = 6400;
            float width = 10, dlina = 5;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_Pord2Mat2_Return608()
        {
            //Arrange
            int productType = 1, materialType = 1, count = 27, expected = 3218;
            float width = 18, dlina = 6;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_Pord3Mat2_Return3796()
        {
            //Arrange
            int productType = 2, materialType = 2, count = 15, expected = 3796;
            float width = 20, dlina = 5;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_Rand1_Return398()
        {
            //Arrange
            int productType = 3, materialType = 1, count = 3, expected = 5936;
            float width = 13, dlina = 18;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_Rand2_Return161()
        {
            //Arrange
            int productType = 2, materialType = 2, count = 4, expected = 1640;
            float width = 9, dlina = 18;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_Rand3_Return2809()
        {
            //Arrange
            int productType = 1, materialType = 1, count = 20, expected = 2648;
            float width = 60, dlina = 2;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_Rand4_Return2345()
        {
            //Arrange
            int productType = 1, materialType = 1, count = 18, expected = 2026;
            float width = 6, dlina = 17;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void GetQuant_HardBignumbers1_Return2246740()
        {
            //Arrange
            int productType = 2, materialType = 1, count = 560, expected = 2246741;
            float width = 80, dlina = 20;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetQuant_HardBignumbers2_Return387182()
        {
            //Arrange
            int productType = 1, materialType = 2, count = 270, expected = 387183;
            float width = 23, dlina = 56;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        //-88
        [TestMethod()]
        public void GetQuant_HardBelowZero1_Return88()
        {
            //Arrange
            int productType = 1, materialType = 1, count = 4, expected = -1;
            float width = -2, dlina = 10;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        //-506
        [TestMethod()]
        public void GetQuant_HardBelowZero2_ReturnError()
        {
            //Arrange
            int productType = 2, materialType = 2, count = -10, expected = -1;
            float width = -5, dlina = -4;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        //0
        [TestMethod()]
        public void GetQuant_HardMoreDecimal_Return0()
        {
            //Arrange
            int productType = 3, materialType = 1, count = 5, expected = -1;
            float width = -5, dlina = 0;

            //Act
            int actual = TestFunc.GetQuantityForProduct(productType, materialType, count, width, dlina);

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
