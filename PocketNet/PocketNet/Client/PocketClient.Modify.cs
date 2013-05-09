using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PocketNet.PocketNet.HttpHelpers;
using PocketNet.PocketNet.Models;

namespace PocketNet.PocketNet.Client
{
    public partial class PocketClient
    {
        public async Task MarkAsFavoriteAsync(params int[] itemId)
        {
            var requestUri = MakeRequestUri("v3/send");
            var request = new HttpRequest(HttpMethod.Post, requestUri);

            var items = itemId.Select(i => new {action = "favorite", item_id = i}).ToList();

            request.AddBody(new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    actions = items
                });

            var response = await SendAsync<ItemModified>(request);
        }
    }
}
