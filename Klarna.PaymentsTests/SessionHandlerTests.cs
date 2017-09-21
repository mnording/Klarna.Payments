using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Klarna.Entities;
using Klarna.Payments;
using Klarna.Payments.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Klarna.PaymentsTests
{
    [TestClass]
    public class SessionHandlerTests
    {
        [TestMethod]
        public void MustBeAbleToCreateSession()
        {

            var s = GetSession();
            Assert.IsNotNull(s.ClientToken);
            Assert.AreNotEqual("",s.ClientToken);
        }

        [TestMethod]
        public void MustBeAbleToUpdateSession()
        {
            var s = GetSession();
            var handler = GetHandler();
            var orderLine = new PaymentsOrderLine("newOrderLine", 2, 1000, 2500);
            SessionRequest req = new SessionRequest(new List<PaymentsOrderLine> { orderLine }, "sv-se", "SE", "SEK");
            handler.UpdateSession(req, s.SessionId);
        }
        private SessionHandler GetHandler()
        {
            MerchantConfig c = new MerchantConfig("K500746", "fia'w2ahSheahahc", Server.Playground);
            SessionHandler handler = new SessionHandler(c);
            return handler;
        }
        private Session GetSession()
        {
            SessionHandler handler = GetHandler();
            var orderLine = new PaymentsOrderLine("test", 2, 1000, 2500);
            SessionRequest req = new SessionRequest(new List<PaymentsOrderLine> { orderLine }, "sv-se", "SE", "SEK");
            var s = handler.CreateSession(req);
            return s;
        }
    }
}
