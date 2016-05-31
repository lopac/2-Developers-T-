using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndirectlyApp.Models;
using IndirectlyApp.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndirectlyApp.Controllers
{
    public class HomeController : Controller
    {
 
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            
            var homeViewModel = new HomeViewModel();
            var mosaics = db.Mosaics;
            homeViewModel.Mosaics = mosaics;
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