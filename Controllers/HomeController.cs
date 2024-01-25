

using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using provet.Models;

namespace provet.Controllers
{
    public class HomeController : Controller
    {

        /* STARTSIDAN */
        //-------------------------------------------------------//
       
        public IActionResult Index()
        {

            ViewData["title"] = "Startsidan"; // Sidans titel

            // Hämta in highscore
            // Mockup
            var viewModel = new StartsidanViewModel
            {
                // Hämta från fil senare!!
                LastFiveUsers = new List<string>
                {
                    "Anders",
                    "Sven",
                    "Lisa",
                    "Adam",
                    "Steve"
                },
                Meddelande = "Grymt jobbat!"
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(ParticipantModel participant)
        {
             ViewData["title"] = "Startsidan"; // Sidans titel
            
            // Set session variables
            
            HttpContext.Session.SetString("_name", participant.Name);
            
            return RedirectToAction("Questions");
        }


        /* FRÅGEDELEN */
        //-------------------------------------------------------//


        [Route("/fragor")] // ändrar routingen
        public IActionResult Questions()
        {

            
            ViewBag.user = HttpContext.Session.GetString("_name");

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