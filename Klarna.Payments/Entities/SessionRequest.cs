using System.Collections.Generic;
using Klarna.Entities;
using Newtonsoft.Json;

namespace Klarna.Payments.Entities
{
    public class SessionRequest
    {
        [JsonProperty(PropertyName = "order_tax_amount")]
        public int OrderTaxAmount { get; }
        [JsonProperty(PropertyName = "order_amount")]
        public int OrderAmount { get; }
        [JsonProperty(PropertyName = "locale")]
        public string Locale;
        [JsonProperty(PropertyName = "purchase_country")]
        public string PurchaseCountry { get; }
        [JsonProperty(PropertyName = "purchase_currency")]
        public string PurchaseCurrency { get; }
        [JsonProperty(PropertyName = "order_lines")]
        public List<PaymentsOrderLine> OrderLines { get; }

        public SessionRequest(List<PaymentsOrderLine> orderlines,string locale,string purchaseCountry,string purchaseCurrency)
        {
            OrderTaxAmount = 0;
            OrderAmount = 0;
            Locale = locale;
            PurchaseCountry = purchaseCountry;
            PurchaseCurrency = purchaseCurrency;
            foreach (PaymentsOrderLine line in orderlines)
            {
                OrderAmount += line.TotalAmount;
                OrderTaxAmount += line.TotalTaxAmount;
            }
            OrderLines = orderlines;
        }
    }
}
