using System.IO;
using System.Net;
using System.Collections.Generic;


namespace Tinder.NET
{
    public class Endpoint
    {
        public const string ServerBaseURL = @"https://api.gotinder.com";

        //SMS Auth section (use headers_def)
        public const string RequestOTP = @"/v2/auth/sms/send?auth_type=sms";        // 1st step of SMS authorization       [POST only,  headers_def]
        public const string ValidateOTP = @"/v2/auth/sms/validate?auth_type=sms";   // 2nd step of SMS authorization       [POST only,  headers_def]
        public const string LoginSMS = @"/v2/auth/login/sms";                       // 3rd step of SMS authorization       [POST only,  headers_def]

        //FB Auth section (use headers_def)
        public const string LoginFB = @"/v2/auth/login/facebook";

        //Features (use headers_auth)
        public const string Profile = @"/profile";                                  // Get own profile data/Set search preferences [GET/POST,  headers_auth] 
        public const string LikeUser = @"/like/{_id}";                              // Like user with {_id} (Swap right)    [GET only,  headers_auth]
        public const string PassUser = @"/pass/{_id}";                              // Pass user with {_id} (Swap left)     [GET only,  headers_auth]
        public const string Recs = @"/user/recs";                                   // Get match recommendations            [GET only,  headers_auth]
        public const string Matches = @"/v2/matches";                               // Get your matches                     [GET only,  headers_auth]
        public const string ProfileID = @"/user/{_id}";                             // Get a user's with {_id} profile data [GET only,  headers_auth]
        public const string Message = @"/user/matches/{_id}";                       // Send Message to user with {_id}      [GET     ,  headers_auth]
        public const string Unmatch = @"/user/matches/{_id}";                       // Unmatch user with {_id}              [DELETE  ,  headers_auth]
        public const string Ping = @"/user/ping";                                   // Change your location                 [POST only, headers_auth]
        public const string Updates = @"/updates";                                  // Get all updates since the given date [POST only, headers_auth]
        public const string InstagramAuth = @"/instagram/authorize";                // Authorize your Instagram account     [GET only,  headers_auth]                 
        public const string SpotifySettings = @"/v2/profile/spotify";               // Get Spotify settings                 [GET only,  headers_auth]
        public const string SetSpotifySong = @"/v2/profile/spotify/theme";          // Set Spotify song                     [PUT only,  headers_auth]
        public const string Username = @"/profile/username";                        // Change/Reset your username           [PUT/DELETE,headers_auth]
        public const string Meta = @"/meta";                                        // Get your own meta data               [GET only,  headers_auth]
        public const string MetaV2 = @"/v2/meta";                                   // Get your own meta data + extra data  [GET only,  headers_auth]
        public const string Report = @"/report/{_id}";                              // Report user with {_id}               [POST only, headers_auth]
        public const string CommonConnections = @"/user/{_id}/common_connections";  // Get common connection of user with {_id} [GET only, headers_auth]

    }

    public class AuxInfo
    {
        public const string user_agent = @"Tinder/11.4.0 (iPhone; iOS 12.4.1; Scale/2.00)";
        public const string content_type = @"application/json";
        public static Dictionary<string, string> headers_def = new Dictionary<string, string>()
        {
            { "user-agent", user_agent },
            { "content-type", content_type},
        };
        public static Dictionary<string, string> headers_auth;
        public static void HeadersAuthUpdate(string auth_token)
        {
            headers_auth = new Dictionary<string, string>()
            {
                { "user-agent", user_agent },
                { "content-type", content_type},
                { "X-Auth-Token", auth_token},
            };
        }
    }

    public class REST
    {
        public static string MakeRequest(string endpoint, string method, Dictionary<string, string> headers, byte[] data)
        {
            //Create new instace of request and assing it with certain endpoint
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Endpoint.ServerBaseURL + endpoint);
            request.Method = method;        //Set method of request (GET/POST/etc)
            foreach (var header in headers) //Add every entry from headers dictionary as well... - headers
            {
                if (header.Key == "user-agent") request.UserAgent = header.Value;
                if (header.Key == "content-type") request.ContentType = header.Value;
                if (header.Key == "X-Auth-Token") request.Headers["X-Auth-Token"] = header.Value;
            }

            Stream datastream;
            //Write data to request if it's diffrent than GET method
            if (request.Method != "GET")
            {
                datastream = request.GetRequestStream();
                datastream.Write(data, 0, data.Length);
                datastream.Close();
            }

            WebResponse response = request.GetResponse();
            datastream = response.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            datastream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}