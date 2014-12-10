using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace Notes.Controllers
{
   [Authorize]
   public class NoteController : Controller
    {
        public ActionResult Delete(int id)
        {
            ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            var note = db.Notes.Find(id);

            if (note == null)
                return HttpNotFound();
            else
            {
                var model = db.Notes.Remove(note);
                db.SaveChanges();
                //                ViewBag.Message = "Note deleted";

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                db.Notes.Add(note);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(note);
        }

        public ActionResult Edit(int id)
        {
            ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var model = db.Notes.Find(id);

            return View(model);
        }
    }
}