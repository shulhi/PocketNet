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
        public string MakeRequestUri(string resourceUri)
        {
            return String.Format("{0}/{1}", PocketInfo.BaseUri, resourceUri);
        }
    }
}
