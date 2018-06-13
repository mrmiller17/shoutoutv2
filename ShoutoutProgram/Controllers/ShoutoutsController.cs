using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ShoutoutProgram.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace ShoutoutProgram.Controllers
{
    public class ShoutoutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Constructor
        public ShoutoutsController()
        {
            db = new ApplicationDbContext();
        }

        #region Form ActionResults

        // GET: Shoutouts
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string sortOrder)
        {
            var allShoutouts = db.Shoutouts
                .Include(s => s.User)
                .Include(s => s.Level)
                .Include(s => s.Recipient);
            return View(allShoutouts);
        }

        // GET: Shoutouts/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            ShoutoutFormViewModel SFVM = new ShoutoutFormViewModel(); // What is this for?

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var shoutout = db.Shoutouts
                .Include(s => s.User)
                .Include(s => s.Level)
                .Include(s => s.Recipient)
                .Single(s => s.ShoutoutId == id);

            if (shoutout == null)
            {
                return HttpNotFound();
            }

            return View(shoutout);
        }

        // GET: Shoutouts/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ShoutoutFormViewModel
            {
                Recipients = db.Users.ToList(),
                Levels = db.Levels.ToList()
            };

            return View(viewModel);
        }

        // POST: Shoutouts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ShoutoutFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Levels = db.Levels.ToList();
                return View("Create", viewModel);
            }


            if (ModelState.IsValid)
            {
                // Save data for Create
                var shoutout = new Shoutout
                {
                    UserId = User.Identity.GetUserId(),
                    RecipientId = viewModel.Recipient,
                    Recipients = viewModel.Recipients,
                    DateTime = DateTime.Now,
                    LevelId = viewModel.Level,
                    Project = viewModel.Giver,
                    Description = viewModel.Description
                };

                // Save to Shoutout table
                db.Shoutouts.Add(shoutout);
                db.SaveChanges();

                // Success alert
                TempData["Success"] = "Added Successfully!";

                return RedirectToAction("Create");
            }

            return View(viewModel);
        }

        // GET: Shoutouts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Pull data for Edit
            var shoutout = db.Shoutouts
                .Include(s => s.User)
                .Include(s => s.Level)
                .Include(s => s.Recipient)
                .Single(s => s.ShoutoutId == id);

            var viewModel = new ShoutoutFormViewModel
            {
                ShoutoutId = shoutout.ShoutoutId,
                Description = shoutout.Description,
                DateTime = shoutout.DateTime,
                Giver = shoutout.Project,
                Recipient = shoutout.RecipientId,
                Levels = db.Levels.ToList(),
                Level = shoutout.LevelId,
                Recipients = db.Users.ToList(),
            };

            if (shoutout == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

        // POST: Shoutouts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ShoutoutId,Description,DateTime,Giver,Recipient,Levels,Level,Repients")] ShoutoutFormViewModel shoutout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoutout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoutout);
        }

        // GET: Shoutouts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            // Check for ShoutoutId
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Pull data for Delete
            var shoutout = db.Shoutouts
                .Include(s => s.User)
                .Include(s => s.Level)
                .Include(s => s.Recipient)
                .Single(s => s.ShoutoutId == id);

            // Check if shoutout has data
            if (shoutout == null)
            {
                return HttpNotFound();
            }

            return View(shoutout);
        }

        
        public JsonResult GetShoutouts()
        {
            using (db)
            {
                var shoutouts = db.Shoutouts.ToList();
                return new JsonResult { Data = shoutouts, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // POST: Shoutouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Shoutout shoutout = db.Shoutouts.Find(id);
            db.Shoutouts.Remove(shoutout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Shoutout Calendar ActionResults

        [Authorize]
        public ActionResult Calendar()
        {
            return View();
        }

        [Authorize]
        public JsonResult GetEvents()
        {
            using (db)
            {
                var events = db.Shoutouts.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        #endregion

        #region MonthlySummary ActionResults

        [HttpGet]
        public ActionResult MonthlySummary()
        {
            var DistinctRecipients = db.Users.Where(x => x.FullName != null).ToList();

            List<string> Names = new List<string>();

            foreach (var item in DistinctRecipients)
            {
                Names.Add(item.FullName);
            }

            var shoutout = db.Shoutouts
                .Include(s => s.User)
                .Include(s => s.Level)
                .Include(s => s.Recipient);

            var viewModel = new MonthlySummaryViewModel()
            {
                DistinctRecipients = Names,
                Recipients = db.Users.ToList()
            };

            return View(viewModel);
        }

        #endregion

        
    }
}