using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ShoutoutProgram.Models;

namespace ShoutoutProgram.Controllers
{
    public class SuggestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Suggestions
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Suggestions.ToList());
        }

        // GET: Suggestions/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.Suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // GET: Suggestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suggestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suggestion suggestion)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", suggestion);
            }

            if (ModelState.IsValid)
            {
                var suggestions = new Suggestion
                {
                    FirstName = suggestion.FirstName,
                    LastName = suggestion.LastName,
                    EmailAddress = suggestion.EmailAddress,
                    DateTime = DateTime.Now,
                    Description = suggestion.Description
                };


                // Save data
                db.Suggestions.Add(suggestions);
                db.SaveChanges();

                // Success alert
                TempData["Success"] = "Added Successfully!";

                return RedirectToAction("Create");
            }

            return View(suggestion);
        }

        // GET: Suggestions/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.Suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // POST: Suggestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateTime,Description")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggestion);
        }

        // GET: Suggestions/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.Suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // POST: Suggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Suggestion suggestion = db.Suggestions.Find(id);
            db.Suggestions.Remove(suggestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult Box()
        //{
        //    var allSuggestions = db.Suggestions;
        //    return View(allSuggestions);
        //}
    }
}
