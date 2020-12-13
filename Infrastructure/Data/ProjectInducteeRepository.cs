using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using RestSharp;

using RestSharp.Serialization.Json;


namespace Infrastructure.Data
{
    public class ProjectInducteeRepository : IProjectInducteeRepository
    {
        RestSharp.Deserializers.IDeserializer deserial = new JsonDeserializer();
        public async Task<List<ProjectInductee>> GetInducteesAsync()
        {
            var client = new RestClient("https://ifs-app:48080/int/ifsapplications/projection/v1/SignInOutApp.svc/ProjectInducteeSet");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer eyJraWQiOiItODMyMTEzMjcwMzM0MzU1ODg0NiIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiJJRlNBUFAiLCJhdWQiOiIgN2M3YTMxODktMTZlZS00NzBmLThlZDAtMWE5ZmFiNDgwNTU2XG4iLCJ1bmlxdWVfbmFtZSI6IklGU0FQUCIsImF6cCI6IiA3YzdhMzE4OS0xNmVlLTQ3MGYtOGVkMC0xYTlmYWI0ODA1NTZcbiIsImlzcyI6Imh0dHBzOlwvXC9pZnMtYXBwOjQ4MDgwXC9vcGVuaWQtY29ubmVjdC1wcm92aWRlciIsImV4cCI6MTYwNzg1MTg0OCwiaWF0IjoxNjA3ODQ4MjQ4fQ.h7eKy5agL5mZy6ewlvv3P-efpbkGPgMYTCgJOGLxbir3JKlADzmPaHZiu3TcoGSmFO-NWtj7wD0Vn4g7xrwNhZU6JjTXnL-e07rNTATTuQG91JI8fmqe_U0O6LO0F5e6EswBq7TOLb397oAvU6QNltbUI6l4FgGHgvR64nPVSkfjANYQWdSP-jJnUPXJmEm2raa2wjN7GUr4CMGypBbWQrbbxgUZgTP3CKWvGsFaHrTwI1kffmwlCIs9yFZ72x7b8LyzKjvbWg7sQBWqqsgUM-7yBzpvSwhE5Gr4BdJw3NxdQC38GX2lkX6cVvVqlI_kgnXlUjFFE5vJ5_EOcIF1sQ");
            request.AddHeader("Cookie", "JSESSIONID=y-pbOeQAFiPUh5MHI541qKUBh-s90wWIZ_oFL-hGFuCXnRVndFXT!-1859474060; _WL_AUTHCOOKIE_JSESSIONID=Ms1dcOf7bGhWu3akqzXJ");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var inducteeResponse = deserial.Deserialize<ProjectInducteeResponse>(response);
            var inductees = inducteeResponse.value;
            Console.WriteLine(response.Content);


            return inductees.ToList();
        }

        public Task<ProjectInductee> GetInducteesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
