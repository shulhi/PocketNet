using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Authenticator
{
    public interface IPocketAuth
    {
        Task<string> GetRequestToken();
        Task<string> GetAccessToken(string requestToken);
        string BuildAuthorizeUri(string requestToken);
    }
}
