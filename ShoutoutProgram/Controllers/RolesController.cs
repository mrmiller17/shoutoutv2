using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoutoutProgram.Models;

namespace ShoutoutProgram.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext db;

        public RolesController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Roles
        public ActionResult Index()
        {
            var Roles = db.Roles.ToList();
            return View(Roles);
        }

        // GET: Create new role
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            db.Roles.Add(Role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}