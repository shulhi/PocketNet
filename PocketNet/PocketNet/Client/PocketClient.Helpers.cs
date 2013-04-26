using System.Net.Http;
using Newtonsoft.Json;
using PocketNet.PocketNet.HttpHelpers;
using PocketNet.PocketNet.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Client
{
    public partial class PocketClient
    {
        private string MakeRequestUri(string resourceUri)
        {
            return String.Format("{0}/{1}", PocketInfo.BaseUri, resourceUri);
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
