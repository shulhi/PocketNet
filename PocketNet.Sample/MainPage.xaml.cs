using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PocketNet.Sample.Resources;
using PocketNet.PocketNet.Authenticator;
using Microsoft.Phone.Tasks;
using PocketNet.PocketNet.Client;
using PocketNet.PocketNet.Models;

namespace PocketNet.Sample
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly PocketOauth _pocketOauth;
        private PocketClient _pocketClient;

        public MainPage()
        {
            InitializeComponent();

            // For this example, I implement the Uri association feature for WP8
            // Refer http://www.developer.nokia.com/Community/Wiki/URI_associations_for_Windows_Phone_8
            _pocketOauth = new PocketOauth("13800-484706a3a08844c6ab34ccf6xx", "getpocket:MainPage");
        }

        private async void LoginPocket_OnClick(object sender, RoutedEventArgs e)
        {
            var token = await _pocketOauth.GetRequestTokenAsync();
            var authorizeUri = _pocketOauth.BuildAuthorizeUri(token);

            StorageHelper.Save("request_token", token);

            var webBrowser = new WebBrowserTask();
            webBrowser.Uri = new Uri(authorizeUri);
            webBrowser.Show();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                var requestToken = StorageHelper.Retrieve("request_token");

                if (requestToken != null)
                {
                    var accessToken = await _pocketOauth.GetAccessTokenAsync(requestToken);
                    StorageHelper.Save("access_token", accessToken);

                    TokenContent.Text = String.Format("Request token = {0}, Access token = {1}", requestToken,
                                                      accessToken);

                    _pocketClient = new PocketClient("11138-795ce1635b4487cac002aa0b", accessToken);

                    var pocketObject = await _pocketClient.GetAllUnreadAsync();

                    TokenContent.Text = pocketObject.First().Excerpt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}