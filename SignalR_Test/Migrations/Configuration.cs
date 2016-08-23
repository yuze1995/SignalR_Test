namespace SignalR_Test.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SignalR_Test.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalR_Test.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SignalR_Test.Models.DBContext context)
        {

        }
    }
}
