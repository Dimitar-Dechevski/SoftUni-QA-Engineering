using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingWorkshop
{
    public static class GlobalConstants
    {
        public const string baseUrl = "http://localhost:5000/api";

        public static string GetAuthenticationToken(string email, string password)
        {
            var client = new RestClient(baseUrl);
            var resource = "";

            if (email.Equals("admin@gmail.com"))
            {
                resource = "/user/admin-login";
            }
            else if (email.Equals("johndoe@example.com"))
            {
                resource = "/user/login";
            }

            var request = new RestRequest(resource, Method.Post);
            request.AddJsonBody(new { email, password });
            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Assert.Fail($"Authentication failed with status code: {response.StatusCode}, content: {response.Content}");
            }

            var content = JObject.Parse(response.Content);
            return content["token"]?.ToString();
        }
    }
}
