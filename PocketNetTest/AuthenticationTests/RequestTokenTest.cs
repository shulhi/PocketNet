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
            var pocket = new PocketOauth("11138-795ce1635b4487cac002aa0b", "http://www.google.com");

            var token = await pocket.GetRequestToken();

            Assert.AreEqual(30, token.Length);
        }
    }
}
