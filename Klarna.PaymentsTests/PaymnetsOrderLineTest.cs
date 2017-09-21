using System;
using Klarna.Entities;
using Klarna.Payments.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Klarna.PaymentsTests
{
    [TestClass]
    public class PaymnetsOrderLineTest
    {
        [TestMethod]
        public void MustCalculateCorrectTotalTaxAmount()
        {
            PaymentsOrderLine o = new PaymentsOrderLine("test", 2, 10000, 2500);
            Assert.AreEqual(4000, o.TotalTaxAmount);
        }
        [TestMethod]
        public void MustBeAbleToEditAmounts()
        {
            var t = new PaymentsOrderLine("test", 2, 10000, 100);
            t.TotalTaxAmount = 1;
            t.TotalAmount = 1;
            t.TotalDiscountAmount = 1;
            Assert.AreEqual(t.TotalTaxAmount, 1);
        }
        [TestMethod]
        public void MustGetIntBackFromAmounts()
        {
            var t = new PaymentsOrderLine("test", 2, 10000, 100);
            var i = 0;
            i = t.TotalTaxAmount;
            Assert.AreEqual(t.TotalTaxAmount, 198);
        }
    }
}
