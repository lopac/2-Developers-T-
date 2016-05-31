using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndirectlyApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndirectlyApp.Controllers
{
    public class MosaicController : Controller
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        // GET: Mosaic
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mosaic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mosaic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mosaic/Create
        [HttpPost]
        public ActionResult Create(int id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                db.Mosaics.Find(id).LikedBy.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mosaic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mosaic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mosaic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mosaic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
