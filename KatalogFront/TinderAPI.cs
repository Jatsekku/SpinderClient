using System.Text;
using System.Text.Json;
using Tinder.Db;


namespace Tinder.API
{

    public class OperationsLL
    {
        public static Models.Json.RequestOTPRes RequestOTP(string phone_number)
        {
            string jsonString = JsonSerializer.Serialize(new Models.Json.RequestOTP() { phone_number = phone_number });
            byte[] data = Encoding.ASCII.GetBytes(jsonString);
            Models.Json.RequestOTPRes response =
                JsonSerializer.Deserialize<Models.Json.RequestOTPRes>(NET.REST.MakeRequest(NET.Endpoint.RequestOTP, "POST", NET.AuxInfo.headers_def, data));
            return response;
        }

        public static Models.Json.ValidateOTPRes ValidateOTP(string phone_number, string otp_code)
        {
            string jsonString = JsonSerializer.Serialize(new Models.Json.ValidateOTP()
            {
                phone_number = phone_number,
                otp_code = otp_code
            });
            byte[] data = Encoding.ASCII.GetBytes(jsonString);
            Models.Json.ValidateOTPRes response =
                JsonSerializer.Deserialize<Models.Json.ValidateOTPRes>(NET.REST.MakeRequest(NET.Endpoint.ValidateOTP, "POST", NET.AuxInfo.headers_def, data));
            return response;
        }

        public static Models.Json.LoginSMSRES LoginSMS(string refresh_token)
        {
            string jsonString = JsonSerializer.Serialize(new Models.Json.LoginSMS() { refresh_token = refresh_token });
            byte[] data = Encoding.ASCII.GetBytes(jsonString);
            Models.Json.LoginSMSRES response =
                JsonSerializer.Deserialize<Models.Json.LoginSMSRES>(NET.REST.MakeRequest(NET.Endpoint.LoginSMS, "POST", NET.AuxInfo.headers_def, data));
            return response;
        }

        public static Models.Json.RecommendationsRes GetRecommendations()
        {
            Models.Json.RecommendationsRes response =
                JsonSerializer.Deserialize<Models.Json.RecommendationsRes>(NET.REST.MakeRequest(NET.Endpoint.Recs, "GET", NET.AuxInfo.headers_auth, null));
            return response;
        }

        /*
        public static string SendMessage(string id, string message)
        {
            string jsonString = JsonSerializer.Serialize(new Models.Json.SendMessage() { message = message });
            byte[] data = Encoding.ASCII.GetBytes(jsonString);
            string endpoint = NET.Endpoint.Message
            string response = 
        }
        */
        
        /*
        public static string PassUSer(string id)
        {
            string response =
                JsonSerializer.Deserialize<Models.Json.RecommendationsRes>(NET.REST.MakeRequest(NET.Endpoint.Recs, "GET", NET.AuxInfo.headers_auth, null));
        }
        */

        public static string LoginFB(string fb_auth_token, string fb_user_id)
        {
            string jsonString = JsonSerializer.Serialize(new Models.Json.LoginFB() { fb_auth_token = fb_auth_token, fb_user_id = fb_user_id });
            byte[] data = Encoding.ASCII.GetBytes(jsonString);
            string response = NET.REST.MakeRequest(NET.Endpoint.LoginFB, "POST", NET.AuxInfo.headers_def, data);
            return response;
        }
    }

    public class Prototypes
    {
        public static string GetRecommendations()
        {
            string response = NET.REST.MakeRequest(NET.Endpoint.Recs, "GET", NET.AuxInfo.headers_auth, null);
            return response;
        }
    }

    public class OperationsHL
    {
        public static void RequestOTP(string phone_number)
        {
            OperationsLL.RequestOTP(phone_number);
        }

        public static string LoginSMS(string phone_number, string otp_code)
        {
            string refresh_token = OperationsLL.ValidateOTP(phone_number, otp_code).data.refresh_token;
            string x_auth_token = OperationsLL.LoginSMS(refresh_token).data.api_token;
            NET.AuxInfo.HeadersAuthUpdate(x_auth_token);
            return x_auth_token;
        }

        public static void LoginTinderToken(string tinder_token)
        {
            NET.AuxInfo.HeadersAuthUpdate(tinder_token);
        }
    }

}