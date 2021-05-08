using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;
using TakeTeste.Models;

namespace TakeTeste.Service
{
    public class ServiceRepository : Service
    {
        public List<Take> GetAll()
        {
            List<Take> myDeserializedClass = new List<Take>();
            try
            {
                var client = new RestClient(BaseApiUrl);
                client.Authenticator = new HttpBasicAuthenticator(UserName, PassWord);

                var request = new RestRequest("", DataFormat.Json);

                var response = client.Get(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    myDeserializedClass = JsonConvert.DeserializeObject<List<Take>>(response.Content);

                    return myDeserializedClass;
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }


            return myDeserializedClass;

        }

    }
}
