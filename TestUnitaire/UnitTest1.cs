using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        System.DateTime date = DateTime.Now;

        public int getMonth()
        {
            return date.Month;
        }

        public int getLastMonth()
        {
            if (date.Month - 1 != 0)
            {
                return date.Month - 1;
            }
            else
            {
                return 12;
            }
        }

        public int getDay()
        {
            return date.Day;
        }

        public int getYear()
        {
            if (getLastMonth() != 12)
            {
                return date.Year;
            }
            else
            {
                return date.Year - 1;
            }

        }

        [TestMethod]
        public void TestGetDay()
        {
            Assert.AreEqual(28, getDay());
        }

        [TestMethod]
        public void TestGetMonth()
        {
            Assert.AreEqual(3, getMonth());
        }

        [TestMethod]
        public void TestGetLastMonth()
        {
            Assert.AreEqual(2, getLastMonth());
        }

        [TestMethod]
        public void TestGetYear()
        {
            Assert.AreEqual(2019, getYear());
        }

        [TestMethod]
        public void TestMois()
        {
            Assert.AreEqual("201902", getYear().ToString() + getLastMonth().ToString("00"));
        }
    }
}
