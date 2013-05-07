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
        protected string MakeRequestUri(string resourceUri)
        {
            return String.Format("{0}/{1}", PocketInfo.BaseUri, resourceUri);
        }

        protected async Task<T> SendAsync<T>(HttpRequest request) where T : class
        {
            var response = await _httpClient.SendAsync(request);
            response.RaiseExceptionWhenError();
            
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
