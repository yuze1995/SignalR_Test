using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SignalR_Test.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DBContext")
        {
        }

        public DbSet<Groups> Groups { get; set; }
        public DbSet<Members> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}