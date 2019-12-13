using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using StatNav.Models;

namespace StatNav.DAL
{
    public class StatNavContext: DbContext
    {
        public StatNavContext() : base("StatNavContext")
        {
        }

        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Status> Status { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}