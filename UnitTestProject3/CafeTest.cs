using KomodoCafeee;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject3
{
    [TestClass]
    public class CafeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MenuItem item = new MenuItem();
            item.MealDescription = ("2 patty burger with bacon, lettuce, ketchup, cheese, and mayo");

            string expected = ("2 patty burger with bacon, lettuce, ketchup, cheese, and mayo");
            string actual = item.MealDescription;

            Assert.AreEqual(expected, actual);
        }

        public void TestMethod2()
        {
            MenuItem item = new MenuItem();
            item.MealNumber = ("2");

            string expected = ("2");
            string actual = item.MealNumber;

            Assert.AreEqual(expected, actual);
        }
    }
}
