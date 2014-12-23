using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.ComponentModel;

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
		public ActionResult Create(Note note, string[] SharedUsersIDs)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
//				note.Owner = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
				foreach (var item in SharedUsersIDs)
				{
					note.SharedUsers.Add(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(item));
				}
				db.Notes.Add(note);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(note);
        }

        public ActionResult Edit(int id)
        {
            ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var note = db.Notes.Find(id);
            if (note == null)
                return HttpNotFound();
            return View(note);
        }


        [HttpPost]
		public ActionResult Edit(Note note/*, string[] SharedUsers*/)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

				//var noteInDb = db.Notes.Include(n => n.SharedUsers)
				//	.Single(p => p.Id == note.Id);
				var noteInDb = db.Notes.Single(n => n.Id == note.Id);
				noteInDb.SharedUsers.Clear();

				//db.Entry(note).State = EntityState.Modified;
				db.Entry(noteInDb).CurrentValues.SetValues(note);

				foreach (var item in note.SharedUsers)
					noteInDb.SharedUsers.Add(item);

				db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(note);
        }
    }
}
