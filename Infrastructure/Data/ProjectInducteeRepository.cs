using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;
using RestSharp;

using RestSharp.Serialization.Json;


namespace Infrastructure.Data
{
    public class ProjectInducteeRepository : IProjectInducteeRepository
    {
        //private readonly string token =
        //    "eyJraWQiOiItODMyMTEzMjcwMzM0MzU1ODg0NiIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiJJRlNBUFAiLCJhdWQiOiI3YzdhMzE4OS0xNmVlLTQ3MGYtOGVkMC0xYTlmYWI0ODA1NTYiLCJ1bmlxdWVfbmFtZSI6IklGU0FQUCIsImF6cCI6IjdjN2EzMTg5LTE2ZWUtNDcwZi04ZWQwLTFhOWZhYjQ4MDU1NiIsImlzcyI6Imh0dHBzOlwvXC9pZnMtYXBwOjQ4MDgwXC9vcGVuaWQtY29ubmVjdC1wcm92aWRlciIsImV4cCI6MTYwODcwMDY2MiwiaWF0IjoxNjA4Njk3MDYyfQ.K9VMP8Q7XVmtwH-Ju8fhAn9iKjR3jIUhpGx_WPHh3SwIORkIYjMMcra9KGxADmYjUTRhClqXaOlqmAxYGABtRYcxwstYL_-h37RkHmKJyH51jhGMX7ASnoZppQdpT1eYaj4OrXJRWktCHwxMEsFuMspyqC4X2tMEOuJkG8o0BLPWW5mSSx3w2x04IMgH6bVcGMhUCCM7Z7MBtYR8rQszBqKehWFwduJX9oFScP5UAmu1vAL8bJD10Db9Fq5H8y-1z18G6LKBYjcvAqLKfVY93o6GPjNUiQv_C-cQegSrXh8RSN4vZuhfnJEzexxu1d0w7h3DoY9C2kBfz4oBZfiEUg";

        //private readonly string _jessionIdCookie = "_Whw70n9HSrmeA4e69KtWrQDgRdfmYxbJ8qlurnx4rIBGV2gAi6k!-341755578";
        //private readonly string _wlAuthCookieJSessionIdCookie = "FrRqcPtj3RY9nMbFyD02";

        //RestSharp.Deserializers.IDeserializer deserial = new JsonDeserializer();
        public async Task<List<ProjectInductee>> GetInducteesAsync(string url,string token)
        {
            var client = new RestClient($"{url}/ProjectInducteeSet");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            //request.AddHeader("Cookie", $"JSESSIONID={_jessionIdCookie}; _WL_AUTHCOOKIE_JSESSIONID={_wlAuthCookieJSessionIdCookie}");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //var inducteeBaseResponse = deserial.Deserialize<ProjectInducteeResponse>(response);
            var inducteeBaseResponse = JsonConvert.DeserializeObject<ProjectInducteeResponse>(response.Content);
            var inductees = inducteeBaseResponse.value;
            Console.WriteLine(response.Content);


            return inductees.ToList();
        }

        public async Task<ProjectInductee> GetInducteesByIdAsync(string url, string id, string token)
        {
            var client = new RestClient($"{url}/ProjectInducteeSet(Objkey='{id}')");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            //request.AddHeader("Cookie", "JSESSIONID=Crtj6RFzkkVh9QKfn-P7qYoZ8cgP9dluJJ1KQSWV5lAUGubKpiy0!-1859474060; _WL_AUTHCOOKIE_JSESSIONID=2iFgPZqZZMPktwZFisHN");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //var inductee = deserial.Deserialize<ProjectInductee>(response);
            var inductee = JsonConvert.DeserializeObject<ProjectInductee>(response.Content);

            Console.WriteLine(response.Content);

            return inductee;
        }

        public async Task<ProjectInductee> CreateInductee(string url, ProjectInductee inductee, string token)
        {
            var client = new RestClient($"{url}/ProjectInducteeSet");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Prefer", "<string>");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            //request.AddHeader("Cookie", "JSESSIONID=Crtj6RFzkkVh9QKfn-P7qYoZ8cgP9dluJJ1KQSWV5lAUGubKpiy0!-1859474060; _WL_AUTHCOOKIE_JSESSIONID=2iFgPZqZZMPktwZFisHN");
            request.AddParameter("application/json", inductee, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return inductee;

        }
    }
}
