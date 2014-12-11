namespace Notes.Migrations
{
    using Notes.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
//    using Microsoft.AspNet.Identity.Owin;

    internal sealed class Configuration : DbMigrationsConfiguration<Notes.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Notes.Models.ApplicationDbContext";
        }

        protected override void Seed(Notes.Models.ApplicationDbContext context)
        {
//            var user = new ApplicationUser { UserName = "1", Email = "1" };
//            var result = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().Create(user, "1");

			//context.Notes.AddOrUpdate(n => n.Name, new Note { Name = "Text1", Text = "blablabla" });
			//context.Notes.AddOrUpdate(n => n.Name, new Note { Name = "Text2", Text = "rrerewrew" });
        }
    }
}
