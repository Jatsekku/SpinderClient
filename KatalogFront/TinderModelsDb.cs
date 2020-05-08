using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Tinder.Models.Db
{
    public class XProfile
    {
        public string id { get; set; }
        public string name { get; set; }
        public string bio { get; set; }
        public int distance { get; set; }
        public string photo_url { get; set; }
    }

    public class SProfile
    {
        public int id { get; set; }
        public string phone_number { get; set; }
        public string tinder_token { get; set; }
    }
}
