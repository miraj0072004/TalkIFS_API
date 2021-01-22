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
    public class ProjectAttendanceRepository: IProjectAttendanceRepository
    {
        //private readonly string token =
        //    "eyJraWQiOiItODMyMTEzMjcwMzM0MzU1ODg0NiIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiJJRlNBUFAiLCJhdWQiOiIgN2M3YTMxODktMTZlZS00NzBmLThlZDAtMWE5ZmFiNDgwNTU2IiwidW5pcXVlX25hbWUiOiJJRlNBUFAiLCJhenAiOiIgN2M3YTMxODktMTZlZS00NzBmLThlZDAtMWE5ZmFiNDgwNTU2IiwiaXNzIjoiaHR0cHM6XC9cL2lmcy1hcHA6NDgwODBcL29wZW5pZC1jb25uZWN0LXByb3ZpZGVyIiwiZXhwIjoxNjA4MjE1OTczLCJpYXQiOjE2MDgyMTIzNzN9.s9ENozDQQYHGvwi7tpkXDP3Lk35kg8OdDhgkeMwrqH-CU5VXf2wFfoGxtjP80Ckoq9O2_UTP_AR4kFd37xhcWIMBMp3ACqCe9l2sfVtzR5-g6YRHuKBYb9o8Dgrw1Dcxb9tVv-FsZfNQCHAI3wpyTQz7z9bIkqUqbUloz9PWp0R-oRsVajuoWZjAvxJcTW7wv-lJXvptPVsBWeT2B4pkrpy9A1In-euRu_OGAqqj6SXK2ZcYXEAGEUiNXL4EZ0BHM9m55x1E2BcrIo1KF_4EPtvTH3qN8nFUE5PzpeDMfaCSHz7xWIH8G6oDlzrt6rvymiCJdIRFyFLgbmFZ4nTtKw";

        //private readonly string _jessionIdCookie = "_Whw70n9HSrmeA4e69KtWrQDgRdfmYxbJ8qlurnx4rIBGV2gAi6k!-341755578";
        //private readonly string _wlAuthCookieJSessionIdCookie = "FrRqcPtj3RY9nMbFyD02";

        //RestSharp.Deserializers.IDeserializer deserial = new JsonDeserializer();
        public async Task<List<ProjectAttendance>> GetAttendancesAsync(string url, string token, string inducteeName=null)
        {
            var urlToUse = inducteeName == null
                ? $"{url}/ProjectAttendanceSet"
                : $"{url}/ProjectAttendanceSet?$filter=Cf_Name eq '{inducteeName}'";

            // var urlToUse = inducteeName == null
            //     ? $"{url}/ProjectAttendanceSet"
            //     : $"{url}/ProjectAttendanceSet(Objkey='{inducteeName}')";
            var client = new RestClient(urlToUse);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            //request.AddHeader("Cookie", $"JSESSIONID={_jessionIdCookie}; _WL_AUTHCOOKIE_JSESSIONID={_wlAuthCookieJSessionIdCookie}");
            IRestResponse response = client.Execute(request);
            //var attendanceBaseResponse = deserial.Deserialize<ProjectAttendanceResponse>(response);
            // var attendanceBaseResponse = JsonConvert.DeserializeObject<ProjectAttendanceResponse>(response.Content);
            // var attendances = attendanceBaseResponse.value;

            var attendanceBaseResponse = JsonConvert.DeserializeObject<ProjectAttendanceResponse>(response.Content);
            var attendances = attendanceBaseResponse.value;
            


            return attendances.ToList();
        }

        public async Task<ProjectAttendance> CreateAttendanceAsync(string url, string token, ProjectAttendance projectAttendance)
        {
            var client = new RestClient($"{url}/ProjectAttendanceSet");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Prefer", "<string>");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");

            //request.AddParameter("application/json", $"{\"Cf_Name":{},"Cf_Sign_In_Time": {},"Cf_Status": {}},"Cf_Terminal": {}}", ParameterType.RequestBody);

            //var tempTime = projectAttendance.Cf_Sign_In_Time.ToString("s");

            request.AddParameter("application/json", $"{{\n    \"Cf_Name\": \"{projectAttendance.Cf_Name}\","
                                                     + $"\n    \"Cf_Sign_In_Time\": \"{projectAttendance.Cf_Sign_In_Time.ToString("s")}\","
                                                     + $"\n    \"Cf_Status\": \"{projectAttendance.Cf_Status}\","
                                                     + $"\n    \"Cf_Terminal\": \"{projectAttendance.Cf_Terminal}\"\n}}",
                                                    ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //var newAttendanceResponse = deserial.Deserialize<ProjectAttendance>(response);
            var newAttendanceResponse = JsonConvert.DeserializeObject<ProjectAttendance>(response.Content);
            Console.WriteLine(response.Content);

            return newAttendanceResponse;
        }

        public async Task<ProjectAttendance> UpdateAttendanceAsync(string url, string token, ProjectAttendance projectAttendance)
        {
            var urlToUse = $"{url}/ProjectAttendanceSet(Objkey='{projectAttendance.Objkey}')";
            var client = new RestClient(urlToUse);
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("If-Match", $"{projectAttendance.ETag}");
            request.AddHeader("Prefer", "<string>");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {token}");
            // var signOutTime = projectAttendance.Cf_Sign_Out_Time == null? "":projectAttendance.Cf_Sign_Out_Time.ToString("s");
            
            //When the sign out time is customizable
            // request.AddParameter("application/json", $"{{\n    \"Cf_Sign_Out_Time\": \"{projectAttendance.Cf_Sign_Out_Time?.ToString("s")}\","
            //                                          + $"\n    \"Cf_Status\": \"{projectAttendance.Cf_Status}\","
            //                                          + $"\n    \"Cf_Terminal\": \"{projectAttendance.Cf_Terminal}\"\n}}",
            //     ParameterType.RequestBody);

            //When the sign out time is the current time of calling this method
            // var statusToUpdate = projectAttendance.Cf_Status == "CfEnum_SIGNED_OUT"?"CfEnum_SIGNED_IN":"CfEnum_SIGNED_OUT";
            if (projectAttendance.Cf_Status == "CfEnum_SIGNED_OUT")
            {
                request.AddParameter("application/json", $"{{\n    \"Cf_Sign_Out_Time\": \"{projectAttendance.Cf_Sign_Out_Time?.ToString("s")}\","
                                                     + $"\n    \"Cf_Status\": \"{projectAttendance.Cf_Status}\","
                                                     + $"\n    \"Cf_Terminal\": \"{projectAttendance.Cf_Terminal}\"\n}}",
                ParameterType.RequestBody);
            }else
            {
                request.AddParameter("application/json", $"{{\n    \"Cf_Sign_In_Time\": \"{projectAttendance.Cf_Sign_In_Time.ToString("s")}\","
                                                     + $"\n    \"Cf_Status\": \"{projectAttendance.Cf_Status}\","
                                                    //  + $"\n    \"Cf_Sign_Out_Time\": \"{DateTime.}\","
                                                     + $"\n    \"Cf_Terminal\": \"{projectAttendance.Cf_Terminal}\"\n}}",
                ParameterType.RequestBody);
            }
            


            //request.AddParameter("application/json", $"{\n    \"Cf_Status\": \"{projectAttendance.Cf_Status}\"," +
            //                                                    "\n    \"Cf_Sign_Out_Time\": \"2020-12-25T06:30:00Z\",\n    \"Cf_Terminal\": \"Miraj1\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var updatedAttendanceResponse = JsonConvert.DeserializeObject<ProjectAttendance>(response.Content);
            Console.WriteLine(response.Content);

            return updatedAttendanceResponse;
        }

        //public async Task<List<ProjectAttendance>> GetAttendenceByInducteeAsync(string url, string token, string inducteeName)
        //{
        //    var urlToUse = inducteeName == null
        //        ? $"{url}/ProjectAttendenceSet"
        //        : $"{url}/ProjectAttendenceSet?$filter=Cf_Name eq {inducteeName}";
        //    var client = new RestClient(urlToUse);
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.GET);
        //    request.AddHeader("Authorization", $"Bearer {token}");
        //    //request.AddHeader("Cookie", "JSESSIONID=Crtj6RFzkkVh9QKfn-P7qYoZ8cgP9dluJJ1KQSWV5lAUGubKpiy0!-1859474060; _WL_AUTHCOOKIE_JSESSIONID=2iFgPZqZZMPktwZFisHN");
        //    request.AddParameter("text/plain", "", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    var attendances = deserial.Deserialize<List<ProjectAttendance>>(response);

        //    Console.WriteLine(response.Content);

        //    return attendances;
        //}
    }
}
