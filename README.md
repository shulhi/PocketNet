PocketNet
=========
.Net wrapper for Pocket/Read It Later API

Docs
=========

Authentication
---------
Pocket follows three simple steps to authenticate. Use PocketNet as below to handle the steps.

1. Make a request for `request_token`

        PocketOauth _pocketOauth = new PocketOauth("your_consumer_key_here", "redirect_uri_here");
        var requestToken = await _pocketOauth.GetRequestTokenAsync();

2. Then point the browser to url to authorize

        // You will need to pass the request token from step 1
        // Then point your browser to this Uri return by this method
        var authorizeUri = _pocketOauth.BuildAuthorizeUri(requestToken);

3. Make a request for `access_token`

        // You will need to pass the request token from step 1
        var accessToken = _pocketOauth.GetAccessTokenAsync(requestToken);

Retrieving items
----------

Todo

Adding items
----------
Todo

Modifying items
-----

Todo

