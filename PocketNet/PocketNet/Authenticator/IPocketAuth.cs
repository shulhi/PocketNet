using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Authenticator
{
    public interface IPocketAuth
    {
        Task<string> GetRequestTokenAsync();
        Task<string> GetAccessTokenAsync(string requestToken);
        string BuildAuthorizeUri(string requestToken);
    }
}
