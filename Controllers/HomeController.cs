

using Microsoft.AspNetCore.Mvc;

namespace provet.Controllers
{
    public class HomeController : Controller
    {

        /* STARTSIDAN */
        //-------------------------------------------------------//
        public IActionResult Index()
        {

            ViewData["title"] = "Startsidan"; // Sidans titel
                                              // Hämta in user
                                              // Mockup
            string user = "Anders";


            ViewBag.user = user;
            return View();
        }


        /* FRÅGEDELEN */
        //-------------------------------------------------------//


        [Route("/fragor")] // ändrar routingen
        public IActionResult Questions()
        {
            ViewData["title"] = "Frågor"; // Sidans titel
            return View();
        }

        /* RESULTAT */
        //-------------------------------------------------------//


        [Route("/resultat")] // ändrar routingen
        public IActionResult Result()
        {
            ViewData["title"] = "Resultat"; // Sidans titel
            return View();
        }
    }
}