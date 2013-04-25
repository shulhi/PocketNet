using Newtonsoft.Json;
using PocketNet.PocketNet.HttpHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Client
{
    public partial class PocketClient
    {
        private readonly string _consumerKey;
        private readonly string _accessToken;

        private readonly HttpClient _httpClient;

        public PocketClient(string consumerKey, string accessToken)
        {
            _consumerKey = consumerKey;
            _accessToken = accessToken;
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "PocketNet");
        }

        public void GetAllItems()
        {
            var requestUrl = MakeRequestUri("v3/get");
            var request = new HttpRequest(HttpMethod.Post, requestUrl);

            // Pass request to SendAsync
        }

        private async Task<T> SendAsync<T>(HttpRequest request) where T : class
        {
            HttpResponseMessage response;

            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (Exception e)
            {
                // TODO: Do error checking here
                throw;
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
