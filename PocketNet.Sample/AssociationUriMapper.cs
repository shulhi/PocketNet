using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace PocketNet.Sample
{
    public class AssociationUriMapper : UriMapperBase
    {
        private string _tempUri;

        public override Uri MapUri(Uri uri)
        {
            _tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());
            // detect if the app is launch thru the getpocket protocol, then we redirect to /MainPage.xaml
            if (_tempUri.Contains("getpocket:MainPage"))
            {
                return new Uri("/MainPage.xaml", UriKind.Relative);
            }
            // Otherwise perform normal launch.
            return uri;
        }
    }
}
