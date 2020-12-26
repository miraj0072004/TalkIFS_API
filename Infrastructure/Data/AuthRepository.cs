using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using Core.Entities;
using RestSharp;
using RestSharp.Serialization.Json;

namespace Infrastructure.Data
{
    public class AuthRepository : IAuthRepository
    {
        RestSharp.Deserializers.IDeserializer deserial = new JsonDeserializer();
        private string _ifsBaseUrl;

        public AuthRepository()
        {
            _ifsBaseUrl = ConfigurationManager.AppSettings.Get("ifsBaseUrl");
        }

        public AuthInfo Login(string url,string username, string password)
        {
            var client = new RestClient($"{url}/openid-connect-provider/idp/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("resource", "7c7a3189-16ee-470f-8ed0-1a9fab480556");
            request.AddParameter("scope", "openid");
            request.AddParameter("response_type", "id_token token");
            request.AddParameter("client_id", "7c7a3189-16ee-470f-8ed0-1a9fab480556");
            request.AddParameter("client_secret", "hj5NQo7OJPgoCXOSZZcAz2U1KdK57exU");
            IRestResponse response = client.Execute(request);

            var authInfo = deserial.Deserialize<AuthInfo>(response);
            
            Console.WriteLine(response.Content);

            return authInfo;
        }
    }
}
