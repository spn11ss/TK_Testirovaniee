using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private double Calculate(double distance, int tickets, double coef)
        {
            return distance * 8 * coef * tickets;
        }

        [TestMethod]
        public void Test_Platzkart_100km_1ticket()
        {
            Assert.AreEqual(800, Calculate(100, 1, 1.0));
        }

        [TestMethod]
        public void Test_Coupe_100km_1ticket()
        {
            Assert.AreEqual(880, Calculate(100, 1, 1.1), 0.001);
        }

        [TestMethod]
        public void Test_SemiLux_100km_1ticket()
        {
            Assert.AreEqual(960, Calculate(100, 1, 1.2), 0.001);
        }

        [TestMethod]
        public void Test_Lux_100km_1ticket()
        {
            Assert.AreEqual(1040, Calculate(100, 1, 1.3), 0.001);
        }

        [TestMethod]
        public void Test_MultipleTickets()
        {
            Assert.AreEqual(2400, Calculate(100, 3, 1.0));
        }

        [TestMethod]
        public void Test_SmallDistance()
        {
            Assert.AreEqual(80, Calculate(10, 1, 1.0));
        }

        [TestMethod]
        public void Test_LargeDistance()
        {
            Assert.AreEqual(80000, Calculate(10000, 1, 1.0));
        }

        [TestMethod]
        public void Test_ZeroDistance()
        {
            Assert.AreEqual(0, Calculate(0, 1, 1.0));
        }

        [TestMethod]
        public void Test_ZeroTickets()
        {
            Assert.AreEqual(0, Calculate(100, 0, 1.0));
        }

        [TestMethod]
        public void Test_MinValues()
        {
            Assert.AreEqual(8, Calculate(1, 1, 1.0));
        }

        [TestMethod]
        public void Test_NegativeDistance()
        {
            double result = Calculate(-100, 1, 1.0);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Test_NegativeTickets()
        {
            double result = Calculate(100, -1, 1.0);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void Test_DoubleDistance()
        {
            Assert.AreEqual(100, Calculate(12.5, 1, 1.0), 0.001);
        }

        [TestMethod]
        public void Test_DoubleWithCoefficient()
        {
            Assert.AreEqual(110, Calculate(12.5, 1, 1.1), 0.001);
        }

        [TestMethod]
        public void Test_Rounding()
        {
            Assert.AreEqual(293.04, Calculate(33.3, 1, 1.1), 0.01);
        }

        [TestMethod]
        public void Test_CoefficientIncrease()
        {
            double platz = Calculate(100, 1, 1.0);
            double lux = Calculate(100, 1, 1.3);

            Assert.IsTrue(lux > platz);
        }

        [TestMethod]
        public void Test_TicketsIncrease()
        {
            double one = Calculate(100, 1, 1.0);
            double two = Calculate(100, 2, 1.0);

            Assert.IsTrue(two > one);
        }
    }
}