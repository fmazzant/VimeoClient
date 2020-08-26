# VimeoClient

VimeoClient is a extendible .NET wrapper for Vimeo API v3.1.

By RestClient libray it can be possible to develop a vimeo webapi call.

```c#
VimeoClient.Vimeo client = new VimeoClient.Vimeo(new VimeoProperties
{
    AccessToken = "MyAccessToken",
    ClientSecret = "MyClientSecret",
    ClientId = "MyClientId",
    ValidCertificates = new List<string>() { "Vimeo certs" }
});
```

Now, you are using client to call a Vimeo rest methods. You can access to user information

 ```c#
var user = client.Me.GetTheUser(); //myself
var user = client.Users.GetTheUser(userId); //other users
```

The library is working in progress.
