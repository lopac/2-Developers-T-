using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndirectlyApp.Models;
using IndirectlyApp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace IndirectlyApp.Controllers
{
    public class HomeController : Controller
    {
 
        private ApplicationDbContext db = new ApplicationDbContext();
        

 
        public ActionResult Index()
        {
            
            var homeViewModel = new HomeViewModel();
            var mosaics = db.Mosaics;
            var userId = User.Identity.GetUserId();

            foreach (var mosaic in mosaics)
            {
                if (mosaic.LikedBy.FirstOrDefault(x => x.Id == userId) != null)
                {
                    mosaic.IsLiked = true;
                }
            }
            homeViewModel.Mosaics = mosaics;
            var user = Request.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .Users.First(x => x.Id == userId);

            homeViewModel.CurrentUser = user;
            return View(homeViewModel);
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