using System;


namespace Tinder.Models.Json
{
    public class RequestOTP { public string phone_number { get; set; } }
    public class RequestOTPRes
    {
        public RequestOTPResMeta meta { get; set; }
        public RequestOTPResData data { get; set; }
    }

    public class RequestOTPResMeta
    {
        public int status { get; set; }
    }

    public class RequestOTPResData
    {
        public int otp_length { get; set; }
        public bool sms_sent { get; set; }
    }

    public class ValidateOTP
    {
        public string otp_code { get; set; }
        public string phone_number { get; set; }
    }

    public class ValidateOTPRes
    {
        public ValidateOTPResMeta meta { get; set; }
        public ValidateOTPResData data { get; set; }
    }

    public class ValidateOTPResMeta
    {
        public int status { get; set; }
    }

    public class ValidateOTPResData
    {
        public string refresh_token { get; set; }
        public bool validated { get; set; }
    }


    public class LoginSMS { public string refresh_token { get; set; } }

    public class LoginSMSRES
    {
        public LoginSMSRESMeta meta { get; set; }
        public LoginSMSRESData data { get; set; }
    }

    public class LoginSMSRESMeta
    {
        public int status { get; set; }
    }

    public class LoginSMSRESData
    {
        public string _id { get; set; }
        public string api_token { get; set; }
        public string refresh_token { get; set; }
        public bool is_new_user { get; set; }
    }

    public class SendMessage
    {
        public string message { get; set; }
    }

    public class LoginFB
    {
        public string fb_auth_token { get; set; }
        public string fb_user_id { get; set; }
    }



    public class RecommendationsRes
    {
        public int status { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public bool group_matched { get; set; }
        public int distance_mi { get; set; }
        public string content_hash { get; set; }
        public object[] common_friends { get; set; }
        public Common_Likes[] common_likes { get; set; }
        public int common_friend_count { get; set; }
        public int common_like_count { get; set; }
        public int connection_count { get; set; }
        public string _id { get; set; }
        public string bio { get; set; }
        public DateTime birth_date { get; set; }
        public string name { get; set; }
        public DateTime ping_time { get; set; }
        public Photo1[] photos { get; set; }
        public Job[] jobs { get; set; }
        public School[] schools { get; set; }
        public Teaser teaser { get; set; }
        public Teaser1[] teasers { get; set; }
        public int gender { get; set; }
        public string birth_date_info { get; set; }
        public int s_number { get; set; }
        public bool show_gender_on_profile { get; set; }
        public Instagram instagram { get; set; }
        public Spotify_Theme_Track spotify_theme_track { get; set; }
        public bool is_traveling { get; set; }
    }

    public class Teaser
    {
        public string type { get; set; }
        public string _string { get; set; }
    }

    public class Instagram
    {
        public DateTime last_fetch_time { get; set; }
        public bool completed_initial_fetch { get; set; }
        public Photo[] photos { get; set; }
        public int media_count { get; set; }
        public string profile_picture { get; set; }
        public string username { get; set; }
    }

    public class Photo
    {
        public string image { get; set; }
        public string thumbnail { get; set; }
        public string ts { get; set; }
    }

    public class Spotify_Theme_Track
    {
        public string id { get; set; }
        public string name { get; set; }
        public Album album { get; set; }
        public Artist[] artists { get; set; }
        public string preview_url { get; set; }
        public string uri { get; set; }
    }

    public class Album
    {
        public string id { get; set; }
        public string name { get; set; }
        public Image[] images { get; set; }
    }

    public class Image
    {
        public int height { get; set; }
        public int width { get; set; }
        public string url { get; set; }
    }

    public class Artist
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Common_Likes
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Photo1
    {
        public string id { get; set; }
        public Crop_Info crop_info { get; set; }
        public string url { get; set; }
        public Processedfile[] processedFiles { get; set; }
        public DateTime last_update_time { get; set; }
        public string fileName { get; set; }
        public string extension { get; set; }
        public int[] webp_qf { get; set; }
        public Processedvideo[] processedVideos { get; set; }
        public bool main { get; set; }
    }

    public class Crop_Info
    {
        public User user { get; set; }
        public Algo algo { get; set; }
        public bool processed_by_bullseye { get; set; }
        public bool user_customized { get; set; }
    }

    public class User
    {
        public float width_pct { get; set; }
        public float x_offset_pct { get; set; }
        public float height_pct { get; set; }
        public float y_offset_pct { get; set; }
    }

    public class Algo
    {
        public float width_pct { get; set; }
        public float x_offset_pct { get; set; }
        public float height_pct { get; set; }
        public float y_offset_pct { get; set; }
    }

    public class Processedfile
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class Processedvideo
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class Job
    {
        public Title title { get; set; }
    }

    public class Title
    {
        public string name { get; set; }
    }

    public class School
    {
        public string name { get; set; }
    }

    public class Teaser1
    {
        public string type { get; set; }
        public string _string { get; set; }
    }

}
