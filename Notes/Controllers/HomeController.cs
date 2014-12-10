//using Microsoft.AspNet.Identity;
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
            ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            var model = db.Notes.ToList();

            return View(model);
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