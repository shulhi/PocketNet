using Newtonsoft.Json;
using PocketNet.PocketNet.HttpHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PocketNet.PocketNet.Models;

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
        }

        public async Task<PocketObject> GetPocketObjectAsync()
        {
            var requestUrl = MakeRequestUri("v3/get");

            var request = new HttpRequest(HttpMethod.Post, requestUrl)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(new
                            {
                                consumer_key = _consumerKey,
                                access_token = _accessToken,
                                state = "unread",
                                sort = "newest"
                            }),
                        Encoding.UTF8, "application/json")
                };

            return await SendAsync<PocketObject>(request);
        }

        public async Task<List<Article>> GetAllUnreadAsync()
        {
            var requestUrl = MakeRequestUri("v3/get");

            var request = new HttpRequest(HttpMethod.Post, requestUrl);
            
            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    state = "unread",
                    sort = "newest"
                });

            var po = await SendAsync<PocketObject>(request);
            
            return po.List.Values.ToList();
        }

        public async Task<List<Article>> GetFavoriteAsync()
        {
            var requestUrl = MakeRequestUri("v3/get");

            var request = new HttpRequest(HttpMethod.Post, requestUrl);

            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    favorite = 1,
                    sort = "newest"
                });

            var po = await SendAsync<PocketObject>(request);

            return po.List.Values.ToList();
        }

        public async Task<List<Article>> GetArchivedAsync()
        {
            var requestUrl = MakeRequestUri("v3/get");

            var request = new HttpRequest(HttpMethod.Post, requestUrl);

            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    state = "archive",
                    sort = "newest"
                });

            var po = await SendAsync<PocketObject>(request);

            return po.List.Values.ToList();
        }
    }
}