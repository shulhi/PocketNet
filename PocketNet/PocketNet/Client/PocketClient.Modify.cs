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
            var items = itemId.Select(i => new {action = "favorite", item_id = i}).ToList();

            var response = await GetValuesAsync<ItemModified>("v3/send", new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    actions = items
                });
        }

        public async Task MarkAsUnfavoriteAsync(params int[] itemId)
        {
            var items = itemId.Select(i => new {action = "unfavorite", item_id = i}).ToList();

            var response = await GetValuesAsync<ItemModified>("v3/send", new
            {
                consumer_key = _consumerKey,
                access_token = _accessToken,
                actions = items
            });
        }

        public async Task MarkAsDeleteAsync(params int[] itemId)
        {
            var items = itemId.Select(i => new {action = "delete", item_id = i}).ToList();

            var response = await GetValuesAsync<ItemModified>("v3/send", new
            {
                consumer_key = _consumerKey,
                access_token = _accessToken,
                actions = items
            });
        }
    }
}