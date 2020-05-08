using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinder.Models.Json;
using Tinder.Models.Db;
using Tinder.DAL;
using KatalogFront;

namespace Tinder.Db
{
    class HL
    {
        public static void Fill(RecommendationsRes profiles)
        {
            var db = new TinderContext();
          
            foreach (var profile in profiles.results)
            {
                if(!(db.XProfiles.Any(key => key.id == profile._id)))
                {
                    XProfile profile_tmp = new XProfile
                    {
                        id = profile._id,
                        name = profile.name,
                        bio = profile.bio,
                        distance = profile.distance_mi,
                        photo_url = profile.photos[0].url
                    };
                    db.XProfiles.Add(profile_tmp);
                }
            }
            db.SaveChanges();
        }

        public static List<XProfile> GetAllUserFromDb()
        {
            var db = new TinderContext();

            var profiles_query = from profile in db.XProfiles
                                 orderby profile.id
                                 select profile;

            return profiles_query.ToList();
        }
        public static List<XProfile> GetSpecUserFromDb(string name, string bio_keyword, int max_distance)
        {
            var db = new TinderContext();

            IQueryable<XProfile> spec_profiles = db.XProfiles;

            if(name.Length > 0)
            {
                spec_profiles = spec_profiles.Where(p => p.name == name);
            }

            if(bio_keyword.Length > 0)
            {
                spec_profiles = spec_profiles.Where(p => p.bio.Contains(bio_keyword));
            }

            if(max_distance > 0)
            {
                spec_profiles = spec_profiles.Where(p => (p.distance <= max_distance));
            }

            return spec_profiles.ToList();
        }

        public static void UpdateSelfProfile(string phone_number, string tinder_token)
        {
            var db = new TinderContext();
            string phone_number_tmp;
            string tinder_token_tmp; 

            if (phone_number.Length > 0)
                phone_number_tmp = phone_number;
            else
                phone_number_tmp = "null";

            if (tinder_token.Length > 0)
                tinder_token_tmp = tinder_token;
            else
                tinder_token_tmp = "null";

            if (db.SProfiles.Any(x => x.id == 1))    //Update
            {
                var self_profile = (from profile in db.SProfiles
                                    where profile.id == 1
                                    select profile).SingleOrDefault();
                self_profile.phone_number = phone_number_tmp;
                self_profile.tinder_token = tinder_token_tmp;
            }
            else
            {
                var self_profile = new SProfile
                {
                    id = 1,
                    phone_number = phone_number_tmp,
                    tinder_token = tinder_token_tmp
                };
                db.SProfiles.Add(self_profile);
            }
            db.SaveChanges();
        }

        public static SProfile GetSelfProfile()
        {
            var db = new TinderContext();

            var self_profile = (from profile in db.SProfiles
                                where profile.id == 1
                                select profile).SingleOrDefault();

            return self_profile;
        }
    }
}
