using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Klarna.Payments.Entities
{
    public class Session
    {
        [JsonProperty(PropertyName = "client_token")]
        public string ClientToken;
        [JsonProperty(PropertyName = "session_id")]
        public string SessionId;
    }
}
