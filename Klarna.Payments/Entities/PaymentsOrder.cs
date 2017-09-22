using System.Collections.Generic;
using Klarna.Entities;
using Newtonsoft.Json;

namespace Klarna.Payments.Entities
{
    public class PaymentsOrder:Order
    {
        [JsonProperty(PropertyName = "order_lines")]
        public List<PaymentsOrderLine> OrderLines;

        public PaymentsOrder(List<PaymentsOrderLine> cart, MerchantUrls urls) : base(urls)
        {
            OrderLines = cart;
        }
    }
}
