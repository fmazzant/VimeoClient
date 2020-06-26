using System;
using System.Collections.Generic;
using System.Text;

namespace VimeoClient.Bodies
{
    public class AccessTokenPayload
    {
        public string grant_type { get; set; } = "client_credentials";

        public string scope { get; set; } = "public";

    }

    public class AccessTokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }
}
