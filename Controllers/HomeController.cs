using E_RecrutementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace E_RecrutementProject.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult About()
        {
          //  ViewBag.Message = "Your application description page.";

            return View();
        }


        [Authorize]
        public ActionResult TrouverPoste()
        {

            return View();
        }
        public ActionResult EspaceRecruteur()
        {

            return View();
        }

    }
}