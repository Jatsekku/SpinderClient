using Tinder.Models.Db;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Tinder.DAL
{
    public class TinderContext : DbContext
    {
        public TinderContext() : base("TinderContext")
        {
        }

        public DbSet<XProfile> XProfiles { get; set; }
        public DbSet<SProfile> SProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
