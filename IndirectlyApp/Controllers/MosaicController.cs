using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using IndirectlyApp.Models;
using IndirectlyApp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

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

        [HttpPost]
        public ActionResult CreateComment(int mosaicId, string body)
        {

          
            try
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);


                var newComment = new Comment
                {
                    User = user,
                    DateTimeCreated = DateTimeOffset.UtcNow,
                    Body = body,
                    Mosaic = db.Mosaics.Find(mosaicId)
                };

                var commentViewModel = new CommentViewModel
                {
                    Body = newComment.Body,
                    DateCreated = newComment.DateTimeCreated,
                    MosaicId = newComment.MosaicId,
                    Username = newComment.User.UserName
                };

                db.Comments.Add(newComment);


                db.SaveChanges();
                //return Json(
                //    new
                //    {
                //        Data = commentViewModel
                //    }, JsonRequestBehavior.AllowGet);
                //Response.StatusCode = (int)HttpStatusCode.OK;
                //return Json(
                //   new
                //   {
                //       Body = "fffff"
                //   }, JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            catch
            {
                //Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //return new HttpStatusCodeResult();
                return new JsonResult();
            }
        }

        // POST: Mosaic/Create
        [HttpPost]
        public ActionResult Like(int id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                db.Mosaics.Find(id).LikedBy.Add(user);
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
               
            }
        }
        [HttpPost]
        public ActionResult Unlike(int id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                db.Mosaics.Find(id).LikedBy.Remove(user);
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

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
