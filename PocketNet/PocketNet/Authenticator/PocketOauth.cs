using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Authenticator
{
    public class PocketOauth : IPocketAuth
    {
        private readonly string _consumerKey;
        private readonly string _redirectUri;

        public PocketOauth(string consumerKey, string redirectUri)
        {
            _consumerKey = consumerKey;
            _redirectUri = redirectUri;
        }

        public async Task<string> GetRequestToken()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://getpocket.com");

                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("consumer_key", _consumerKey),
                        new KeyValuePair<string, string>("redirect_uri", _redirectUri)
                    });

                var result = await client.PostAsync("/v3/oauth/request", content);
                var resultContent = result.Content.ReadAsStringAsync().Result;

                return resultContent.Substring(5, 30);
            }
        }

        public Task<string> GetAccessToken(string requestToken)
        {
            throw new NotImplementedException();
        }

        public string BuildAuthorizeUri(string requestToken)
        {
            throw new NotImplementedException();
        }
    }
}