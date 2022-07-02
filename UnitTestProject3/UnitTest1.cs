using Microsoft.VisualStudio.TestTools.UnitTesting;
using NN_TelekomPP.Forms;
using System;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test1_2_2_4()
        {

           double a = 2;
           double b = 2;
           double expected = 4;

            CalculetionForm c = new CalculetionForm();
           double act = c.summ2(a, b);
           Assert.AreEqual(expected, act);
        }
        [TestMethod]
        public void test1_3_2_10()
        {

            double a = 3;
            double b = 2;
            double expected = 10;

            CalculetionForm c = new CalculetionForm();
            double act = c.summ2(a, b);
            Assert.AreEqual(expected, act);
        }
        [TestMethod]
        public void test1_10_10_20()
        {

            double a = 10;
            double b = 10;
            double expected = 20;

            CalculetionForm c = new CalculetionForm();
            double act = c.summ2(a, b);
            Assert.AreEqual(expected, act);
        }
        [TestMethod]
        public void test1_11_11_30()
        {

            double a = 11;
            double b = 11;
            double expected = 30;

            CalculetionForm c = new CalculetionForm();
            double act = c.summ2(a, b);
            Assert.AreEqual(expected, act);
        }
    }
}

