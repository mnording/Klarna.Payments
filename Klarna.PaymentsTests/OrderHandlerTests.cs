using System;
using System.Collections.Generic;
using Klarna.Entities;
using Klarna.Exception;
using Klarna.Payments;
using Klarna.Payments.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Klarna.PaymentsTests
{
    [TestClass]
    public class OrderHandlerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ApiException))]
        public void MustBeAbleToReachCreateOrder()
        {
            MerchantConfig config = new MerchantConfig("K500746", "fia'w2ahSheahahc", Server.Playground);
            OrderHandler oh = new OrderHandler(config);
            MerchantUrls urls = new MerchantUrls();
            var lines = new List<PaymentsOrderLine> {new PaymentsOrderLine("test", 1, 1000, 2500)};
            PaymentsOrder o = new PaymentsOrder(lines, urls);
            oh.CreateOrder("3eaeb557-5e30-47f8-b840-b8d987f5945d", o);
        }

    }
}
