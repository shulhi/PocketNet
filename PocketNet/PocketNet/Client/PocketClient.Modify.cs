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
        public async Task FavoriteItemAsync(params int[] itemId)
        {
            var items = itemId.Select(i => new {action = "favorite", item_id = i}).ToList();

            var response = await GetValuesAsync<ItemModified>("v3/send", new
                {
                    consumer_key = _consumerKey,
                    access_token = _accessToken,
                    actions = items
                });
        }

        public async Task UnfavoriteItemAsync(params int[] itemId)
        {
            var items = itemId.Select(i => new {action = "unfavorite", item_id = i}).ToList();

            var response = await GetValuesAsync<ItemModified>("v3/send", new
            {
                consumer_key = _consumerKey,
                access_token = _accessToken,
                actions = items
            });
        }

        public async Task DeleteItemAsync(params int[] itemId)
        {
            var items = itemId.Select(i => new {action = "delete", item_id = i}).ToList();

            var response = await GetValuesAsync<ItemModified>("v3/send", new
            {
                consumer_key = _consumerKey,
                access_token = _accessToken,
                actions = items
            });
        }

        public async Task ArchiveItemAsync(params int[] itemId)
        {
            var items = itemId.Select(i => new { action = "archive", item_id = i }).ToList();

            var response = await GetValuesAsync<ItemModified>("v3/send", new
            {
                consumer_key = _consumerKey,
                access_token = _accessToken,
                actions = items
            });
        }

        public async Task ReaddItemAsync(params int[] itemId)
        {
            var items = itemId.Select(i => new { action = "readd", item_id = i }).ToList();

            var response = await GetValuesAsync<ItemModified>("v3/send", new
            {
                consumer_key = _consumerKey,
                access_token = _accessToken,
                actions = items
            });
        }
    }
}