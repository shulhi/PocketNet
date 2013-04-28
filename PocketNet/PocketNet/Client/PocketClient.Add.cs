using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocketNet.PocketNet.Models;
using PocketNet.PocketNet.HttpHelpers;
using System.Net.Http;

namespace PocketNet.PocketNet.Client
{
    public partial class PocketClient
    {
        // Not sure to let user encode, or we encode for them
        // Currently user need to encode
        public async Task<ItemAddedWrapper> AddItemAsync(string encodedUriToAdd)
        {
            var requestUri = MakeRequestUri("v3/add");

            var request = new HttpRequest(HttpMethod.Post, requestUri);

            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    url = encodedUriToAdd
                });

            var response = await SendAsync<ItemAddedWrapper>(request);

            return response;
        }
    }
}
