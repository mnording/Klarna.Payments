﻿using System;
using System.IO;
using System.Net;
using Klarna.Entities;
using Klarna.Exception;
using Klarna.Helpers;
using Klarna.Payments.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Klarna.Payments
{
    public class SessionHandler
    {
        readonly JsonRequest _json;
        private string auth;
        public SessionHandler(MerchantConfig config)
        {
            _json = new JsonRequest();
            var digest = new DigestCreator();
            auth = digest.CreateDigest(config.merchantId, config.sharedSecret);
        }
        public Session CreateSession(SessionRequest req)
        {
            var body = ConvertObjectToString(req);
            
            var response = _json.CreateRequest(auth,new Uri("https://api.playground.klarna.com/credit/v1/sessions"),"POST", body, "Mnording Klarna Payments SDK");
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd(); // do something fun...
                var jsreader = new JsonTextReader(new StringReader(result));
                var details = new JsonSerializer().Deserialize<Session>(jsreader);
                return details;

            }
        }
        public void UpdateSession(SessionRequest s,string sessionId)
        {
            var body = ConvertObjectToString(s);

            var response = _json.CreateRequest(auth, new Uri("https://api.playground.klarna.com/credit/v1/sessions/"+ sessionId), "POST", body, "Mnording Klarna Payments SDK");
            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                throw new ConnectionException("Could not update session");
            }
        }

       private string ConvertObjectToString(SessionRequest req)
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
