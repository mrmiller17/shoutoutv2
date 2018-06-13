using ShoutoutProgram.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace ShoutoutProgram.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EventsIndex()
        {
            var allEvents = db.Events;
            return View(allEvents);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        //public ActionResult Edit([Bind(Include = "EventId,Subject,Description,Start,End,ThemeColor,IsFullDay,IsTicker")] Event @event)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(@event).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("EventsIndex");
        //    }
        //    return View(@event);
        //}

        // ActionResult for feed of shoutouts

        [Authorize]
        public ActionResult Feed()
        {
            var allShoutouts = db.Shoutouts
                .Include(s => s.User)
                .Include(s => s.Level)
                .Include(s => s.Recipient);

            return View(allShoutouts);
        }

        #region Event ActionResults

        [Authorize]
        public ActionResult Events()
        {
            return View();
        }

        [Authorize]
        public JsonResult GetEvents()
        {
            using (db)
            {
                var events = db.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;

            using (db)
            {
                if (e.EventId > 0)
                {
                    //Update the event
                    var v = db.Events.Where(a => a.EventId == e.EventId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                        v.IsTicker = e.IsTicker;
                    }
                }
                else
                {
                    db.Events.Add(e);
                }

                db.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        [Authorize]
        public JsonResult DeleteEvent(int eventId)
        {
            var status = false;

            using (db)
            {
                var v = db.Events.Where(a => a.EventId == eventId).FirstOrDefault();
                if (v != null)
                {
                    db.Events.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }
        #endregion

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}