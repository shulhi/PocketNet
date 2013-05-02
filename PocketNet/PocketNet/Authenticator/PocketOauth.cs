using System.Net;
using Newtonsoft.Json;
using PocketNet.PocketNet.Exceptions;
using PocketNet.PocketNet.HttpHelpers;
using PocketNet.PocketNet.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http.Headers;

namespace PocketNet.PocketNet.Authenticator
{
    public class PocketOauth : IPocketAuth
    {
        private readonly string _consumerKey;
        private readonly string _redirectUri;
        private readonly HttpClient _httpClient;

        public PocketOauth(string consumerKey, string redirectUri)
        {
            _consumerKey = consumerKey;
            _redirectUri = redirectUri;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetRequestTokenAsync()
        {
            _httpClient.BaseAddress = new Uri(PocketInfo.BaseUri);
            _httpClient.DefaultRequestHeaders.Add("X-Accept", "application/x-www-form-urlencoded");

            var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("consumer_key", _consumerKey),
                    new KeyValuePair<string, string>("redirect_uri", _redirectUri)
                });

            var response = await _httpClient.PostAsync("/v3/oauth/request", content);
            // don't use response.response.EnsureSuccessStatusCode() because exception thrown is does not detail enough
            // instead use this extension to throw custom exception
            response.RaiseExceptionWhenError();
            
            var resultContent = response.Content.ReadAsStringAsync().Result;

            return resultContent.Substring(5, 30);
        }

        public async Task<string> GetAccessTokenAsync(string requestToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PocketInfo.BaseUri);

                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("consumer_key", _consumerKey),
                        new KeyValuePair<string, string>("code", requestToken)
                    });

                var response = await client.PostAsync("/v3/oauth/authorize", content);
                response.RaiseExceptionWhenError();

                var resultContent = response.Content.ReadAsStringAsync().Result;

                return resultContent.Substring(13, 30);
            }
        }

        public string BuildAuthorizeUri(string requestToken)
        {
            if (String.IsNullOrEmpty(requestToken))
                throw new ArgumentNullException("requestToken", "Request token cannot be null or empty.");

            return String.Format("https://getpocket.com/auth/authorize?request_token={0}&redirect_uri={1}",
                                 requestToken, _redirectUri);
        }
    }
}