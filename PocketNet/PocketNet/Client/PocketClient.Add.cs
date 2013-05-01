using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketNet.PocketNet.Models;
using PocketNet.PocketNet.HttpHelpers;
using System.Net.Http;
using System.Net;

namespace PocketNet.PocketNet.Client
{
    public partial class PocketClient
    {
        public async Task<ItemAddedWrapper> AddItemAsync(string uri)
        {
            var requestUri = MakeRequestUri("v3/add");
            var encodedUri = HttpUtility.UrlEncode(uri);

            var request = new HttpRequest(HttpMethod.Post, requestUri);

            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    url = encodedUri
                });

            var response = await SendAsync<ItemAddedWrapper>(request);

            return response;
        }
    }
}
