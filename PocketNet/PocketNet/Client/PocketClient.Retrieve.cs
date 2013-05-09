using System;
using PocketNet.PocketNet.HttpHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<ItemRetrievedWrapper> GetAllUnreadAsync(int numberOfItems = 30, int offSet = 0, int sinceInUnixTime = 0)
        {
            return await GetValuesAsync<ItemRetrievedWrapper>("v3/get", new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    state = "unread",
                    sort = "newest",
                    since = sinceInUnixTime,
                    count = numberOfItems,
                    offset = offSet
                });
        }

        public async Task<ItemRetrievedWrapper> GetFavoriteAsync(int numberOfItems = 30, int offSet = 0, int sinceInUnixTime = 0)
        {
            return await GetValuesAsync<ItemRetrievedWrapper>("v3/get", new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    favorite = 1,
                    sort = "newest",
                    since = sinceInUnixTime,
                    count = numberOfItems,
                    offset = offSet
                });
        }

        public async Task<ItemRetrievedWrapper> GetArchivedAsync(int numberOfItems = 30, int offSet = 0, int sinceInUnixTime = 0)
        {
            return await GetValuesAsync<ItemRetrievedWrapper>("v3/get", new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    state = "archive",
                    sort = "newest",
                    since = sinceInUnixTime,
                    count = numberOfItems,
                    offset = offSet
                });
        }

        public async Task<ItemRetrievedWrapper> SearchTitleOrUrlAsync(string term)
        {
            if(string.IsNullOrEmpty(term))
                throw new ArgumentNullException("term");

            return await GetValuesAsync<ItemRetrievedWrapper>("v3/get", new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    state = "archive",
                    sort = "newest",
                    search = term
                });
        }

        private async Task<T> GetValuesAsync<T>(string resourceUri, object parametersAsAnonymousObject) where T : class
        {
            var requestUrl = MakeRequestUri(resourceUri);

            var request = new HttpRequest(HttpMethod.Post, requestUrl);
            request.AddBody(parametersAsAnonymousObject);

            return await SendAsync<T>(request);
        }
    }
}