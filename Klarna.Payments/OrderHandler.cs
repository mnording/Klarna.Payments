using System;
using Klarna.Entities;
using Klarna.Helpers;
using Klarna.Payments.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Klarna.Payments
{
    public class OrderHandler
    {
        private JsonRequest Json;
        private string auth;
        public OrderHandler(MerchantConfig config)
        {
            var dig = new DigestCreator();
            
            Json = new JsonRequest();
            auth = dig.CreateDigest(config.merchantId, config.sharedSecret);
        }
        public void CreateOrder(string authorization, PaymentsOrder order)
        {
            var ob = ConvertObjectToString(order);
            Json.CreateRequest(auth, new Uri("https://api.playground.klarna.com/credit/v1/authorizations/"+ authorization + "/order"), "POST", ob, "Mnording Klarna Payments SDK");
        }
        private string ConvertObjectToString(PaymentsOrder req)
        {
            JsonSerializer jsonWriter = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            JObject ob = JObject.FromObject(req, jsonWriter);
            return ob.ToString();
        }
    }
}
