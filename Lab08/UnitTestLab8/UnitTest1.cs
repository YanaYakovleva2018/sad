using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab08;

namespace UnitTestLab8
{
    /// <summary>
    /// Основной класс содержащий модульные тесты
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Метод тестирующий метод Add()
        /// </summary>
        [TestMethod]
        public void TestMethod_Add()
        {
            double exp = 100.5;
            Calc Device = new Calc();
            Device.st_op1 = "50";
            Device.st_op2 = "50.5";
            Device.Add();
            Assert.AreEqual(exp, Device.result);

        }
        /// <summary>
        /// Метод тестирующий метод Sub()
        /// </summary>
        [TestMethod]
        public void TestMethod_Sub()
        {
            double exp = -0.5;
            Calc Device = new Calc();
            Device.st_op1 = "10";
            Device.st_op2 = "10.5";
            Device.Sub();
            Assert.AreEqual(exp, Device.result);

        }
        /// <summary>
        /// Метод тестирующий метод Mul()
        /// </summary>
        [TestMethod]
        public void TestMethod_Mul()
        {
            double exp = 108.9;
            Calc Device = new Calc();
            Device.st_op1 = "3.3";
            Device.st_op2 = "33";
            Device.Mul();
            Assert.AreEqual(exp, Device.result);

        }
        /// <summary>
        /// Метод тестирующий метод Div()
        /// </summary>
        [TestMethod]
        public void TestMethod_Div()
        {
            double exp = 7;
            Calc Device = new Calc();
            Device.st_op1 = "35";
            Device.st_op2 = "5";
            Device.Div();
            Assert.AreEqual(exp, Device.result);

        }
        /// <summary>
        /// Метод тестирующий метод SquareRoot()
        /// </summary>
        [TestMethod]
        public void TestMethod_Root()
        {
            double exp = 16;
            Calc Device = new Calc();
            Device.st_op1 = "256";
            Device.SquareRoot();
            Assert.AreEqual(exp, Device.result);

        }
        /// <summary>
        /// Метод тестирующий метод Cosinus()
        /// </summary>
        [TestMethod]
        public void TestMethod_Cos()
        {
            double exp = 0.54030;
            Calc Device = new Calc();
            Device.st_op1 = "1";
            Device.Cosinus();
            Assert.AreEqual(exp, Device.result);

        }
        /// <summary>
        /// Метод тестирующий метод Reverse()
        /// </summary>
        [TestMethod]
        public void TestMethod_Rev()
        {
            double exp = 0.2;
            Calc Device = new Calc();
            Device.st_op1 = "5";
            Device.Reverse();
            Assert.AreEqual(exp, Device.result);

        }

    }
}
