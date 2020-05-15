using Remote_db.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace Remote_db.Repositories {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext() : base("azure_remoteDb", throwIfV1Schema: false) {
            this.Configuration.ProxyCreationEnabled = false;
            Database.Log = s => Debug.WriteLine(s);
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // Enable cascade delete when you remove something that requires it.
            base.OnModelCreating(modelBuilder);
        }

        // Start of DbSet(s)

        public DbSet<House> Houses { get; set; }
        public DbSet<HouseRoom> Rooms { get; set; }
        public DbSet<AvailableTimes> FreeIntervals { get; set; }
        //public DbSet<Dibs> Dibs { get; set; }
        //public DbSet<Favs> Favorites { get; set; }

        // End of DbSet(s)
    }
}
