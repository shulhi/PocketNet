using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using PocketNet.PocketNet.Authenticator;
using System.Threading.Tasks;

namespace PocketNetTest.AuthenticationTests
{
    [TestClass]
    public class PocketOauthTest
    {
        [TestMethod]
        public async Task Oauth_RequestToken_OK()
        {
            var pocket = new PocketOauth("consumer_key", "rediret_uri");

            var token = await pocket.GetRequestTokenAsync();

            Assert.AreEqual(30, token.Length);
        }

        // This doesn't work for now as need to authorize the app first (in step 2)
        [TestMethod]
        public async Task Oauth_AccessToken_OK()
        {
            var pocket = new PocketOauth("consumer_key", "rediret_uri");
            const string requestToken = "request_token";

            var token = await pocket.GetAccessTokenAsync(requestToken);

            Assert.IsNotNull(token);
        }
    }
}
