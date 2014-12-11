using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Notes.Controllers
{
    public class HomeController : Controller
    {
		[Authorize]
        public ActionResult Index()
        {
			return View(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
        }

		public ActionResult PopulateDB()
		{
			ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

			Note note = new Note();
			note.Name = "Name2";
			note.Text = "text dsf s gdfg dfg dfgfd gerf ge";
			//			note.Owner = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
			note.SharedUsers.Add(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName("glyu@gmail.com"));
			note.SharedUsers.Add(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName("tarassel@gmail.com"));
			db.Notes.Add(note);

			Note note2 = new Note();
			note2.Name = "Name1";
			note2.Text = "text sgdf gdfg tg rtgrt grt grt1";
			note2.SharedUsers.Add(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName("glyu@gmail.com"));
			db.Notes.Add(note2);

			db.SaveChanges();
			return RedirectToAction("Index", "Home");
		}

		public ActionResult ClearDB()
		{
			ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

			foreach (var note in db.Notes)
				db.Notes.Remove(note);
			db.SaveChanges();
			return RedirectToAction("Index", "Home");
		}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}