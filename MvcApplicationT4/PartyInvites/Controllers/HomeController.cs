using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        public static int UserAdId = 11;

 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeUserAdId(int num)
        {
            UserAdId = num;
            return View();
        }


    }
}