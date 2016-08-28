using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationT4.Models;
 

 

namespace MvcApplicationT4.Controllers
{
  
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public static List<string> countries;
        public static List<string> dsc;
        public static List<int> born;

        static HomeController()
        {
            countries = new List<string>() { "AU", "US", "GB"};
            dsc = new List<string>() { "AU is good ", "US is good ", "GB is good " };
            born = new List<int>() { 1999, 2000, 1999 };
        }

      //  [Route("aaa")]
        public ActionResult Countries()
        {
            List<Country> lc = new List<Country>(3);
            for (int i = 0; i < 3; i++)
            {
                lc.Add( new Country());

                lc[i].dateBuild = born[i];
                lc[i].dsc = dsc[i];
                lc[i].name = countries[i];
            }

            return View(lc);
        }

        public ActionResult Test()
        {
            

            return View( );
        }

        public ActionResult Index()
        {
            ViewBag.CustomVariable = RouteData.Values["id"];

            ViewBag.conts = countries;
            return View();
        }

        public ActionResult TestRazorV()
        {
            TempData["Message"] = "Привет";

            return new HttpStatusCodeResult(404, "Страница не найдена");

            return RedirectToRoute(new
            {
                controller = "Home",
                action = "ChModel",
                id = "2"                
            });
            //return View();
        }


        [HttpGet]
        [ActionName("ChModel")]        
        public ActionResult ChModel(int id )
        {

            var a = TempData["Message"] ;
            Country chCntr = new Country() 
            {
                name =  countries.ElementAt(id),
                dsc = dsc.ElementAt(id),
                dateBuild = born.ElementAt(id)

            };
           
            return View(chCntr);
        }

        public ActionResult ViewModel(int id)
        {
           
            Country chCntr = new Country()
            {
                name = countries.ElementAt(id),
                dsc = dsc.ElementAt(id),
                dateBuild = born.ElementAt(id)

            };
            return View(chCntr);
        }

        [HttpPost]
        [ActionName("ViewModel")]
        public ActionResult ViewModel_Post(Country cc)
        {
          
            return  RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("ChModel")]
        public ActionResult ChModel_Post([Bind(Include = "name,dsc,dateBuild,selectedDate")]  Country country) //
        {
            if (ModelState.IsValid)
            {
               
                var ind = countries.IndexOf(country.name); //.Where(a => a == country.name);
                if (ind < 0)
                {
                    return View();
                }

                 
                dsc[ind] = country.dsc;
                countries[ind] = country.name;
                born[ind] = country.selectedDate;

                //countries.Add(country.name);
                //dsc.Add(country.name + "is good");
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        [ActionName("CreModel")]
        public ActionResult CreModel( )
        {
       
          
            return View();
        }

        [HttpPost]
        [ActionName("CreModel")]
        public ActionResult CreModel_Post(Country country) // 
        {
            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(country.name))
                { 
                    ModelState.AddModelError("Name", "Name required");
                    return View();
                }

                countries.Add(country.name);
                dsc.Add(country.name + "is good");
                return RedirectToAction("Index");
            }

            return View();
            
        } 

        public ActionResult Details(int id)
        {      
            string countryD = dsc.ElementAt(id);

            return View(model: countryD);
        }

        [HttpPost]
        public ActionResult Del(int id)
        {


            countries.RemoveAt(id);
            dsc.RemoveAt(id);
            born.RemoveAt(id);

            return RedirectToAction("Index");
        }

        public string Index2()
        {         
            return "Hi " + Request.QueryString["one"];
        }

    }
}
