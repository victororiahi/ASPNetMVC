using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetMVC.Web.Models;

namespace ASPNetMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            AboutVM aboutVM = new AboutVM();

            aboutVM.Description = "Error";
            aboutVM.Name = "Home";
            aboutVM.Title = "About";
            aboutVM.Url = "www.victor.com";
            return View(aboutVM);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Privacy()
        {
            return Content("Private key");
        }
    }
}