using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDExampleLibrary;

namespace TDDExampleTests
{
    [TestClass]
    public class TestRunner
    {
        public object CustomerList { get; private set; }

        [TestMethod]
        public void AddItem_CoffeeReturnValue()
        {
            var bill = new CustomerList();
            bill.Add("coffee");
            Assert.AreEqual("1.00", bill.GetBill());
        }

        [TestMethod]
        public void AddItem_CoffeeNoReturnValue()
        {
            var bill = new CustomerList();
            bill.Add("coffeeeeeeeee");
            Assert.AreNotEqual("1.00", bill.GetBill());
        }

        [TestMethod]
        public void AddItem_MenuListReturnValue()
        {
            var bill = new CustomerList();
            bill.Add("coffee");
            bill.Add("cola");
            bill.Add("cheese sandwich");
            Assert.AreEqual("3.50", bill.GetBill());
        }

        [TestMethod]
        public void AddItem_ServiceChargeColdFood()
        {
            var bill = new CustomerList();
            bill.Add("coffee");
            bill.Add("cola");
            bill.Add("cheese sandwich");

            Assert.AreEqual("0.20", bill.GetServiceCost());
        }

        [TestMethod]
        public void AddItem_NoServiceCharge()
        {
            var bill = new CustomerList();
            bill.Add("coffee");
            bill.Add("cola");

            Assert.AreEqual("0.00", bill.GetServiceCost());
        }

        [TestMethod]
        public void AddItem_ServiceChargeHotFood()
        {
            var bill = new CustomerList();
            bill.Add("coffee");
            bill.Add("cola");
            bill.Add("steak sandwich");

            Assert.AreEqual("0.90", bill.GetServiceCost());
        }

        [TestMethod]
        public void AddItem_ServiceChargeHotFoodOverMaxCharge()
        {
            var bill = new CustomerList();
            bill.Add("coffee");
            bill.Add("cola");

            for (int x = 0; x < 100; x++)
            {
                bill.Add("steak sandwich");
            }

            Assert.AreEqual("20.00", bill.GetServiceCost());
        }

    }
}
