using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketNet.PocketNet.Client
{
    public class PocketClient
    {
        private readonly string _consumerKey;
        private readonly string _accessToken;

        public PocketClient(string consumerKey, string accessToken)
        {
            _consumerKey = consumerKey;
            _accessToken = accessToken;
        }
    }
}
