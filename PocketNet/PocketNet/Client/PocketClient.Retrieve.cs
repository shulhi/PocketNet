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

        /// <summary>
        /// Retrieve all unread items
        /// </summary>
        /// <param name="sinceInUnixTime">To retrieve the item since when (optional). Value must be in Unix Time. Will retrieve all available items if value is not specified.</param>
        /// <returns>List of item retrieved</returns>
        public async Task<List<ItemRetrieved>> GetAllUnreadAsync(int sinceInUnixTime = 0)
        {
            var requestUrl = MakeRequestUri("v3/get");

            var request = new HttpRequest(HttpMethod.Post, requestUrl);
            
            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    state = "unread",
                    sort = "newest",
                    since = sinceInUnixTime
                });

            var response = await SendAsync<ItemRetrievedWrapper>(request);
            
            return response.List.Values.ToList();
        }

        /// <summary>
        /// Retrieve all favorite items
        /// </summary>
        /// <param name="sinceInUnixTime">To retrieve the item since when (optional). Value must be in Unix Time. Will retrieve all available items if value is not specified.</param>
        /// <returns>List of item retrieved</returns>
        public async Task<List<ItemRetrieved>> GetFavoriteAsync(int sinceInUnixTime = 0)
        {
            var requestUrl = MakeRequestUri("v3/get");

            var request = new HttpRequest(HttpMethod.Post, requestUrl);

            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    favorite = 1,
                    sort = "newest",
                    since = sinceInUnixTime
                });

            var response = await SendAsync<ItemRetrievedWrapper>(request);

            return response.List.Values.ToList();
        }

        /// <summary>
        /// Retrieve all archived items
        /// </summary>
        /// <param name="sinceInUnixTime">To retrieve the item since when (optional). Value must be in Unix Time. Will retrieve all available items if value is not specified.</param>
        /// <returns>List of item retrieved</returns>
        public async Task<List<ItemRetrieved>> GetArchivedAsync(int sinceInUnixTime = 0)
        {
            var requestUrl = MakeRequestUri("v3/get");

            var request = new HttpRequest(HttpMethod.Post, requestUrl);

            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    state = "archive",
                    sort = "newest",
                    since = sinceInUnixTime
                });

            var response = await SendAsync<ItemRetrievedWrapper>(request);

            return response.List.Values.ToList();
        }
    }
}