

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

            // Hämta in highscore
            // Mockup
            var viewModel = new StartsidanViewModel
            {
                HighScore = new List<string>
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


    /* FRÅGEDELEN */
    //-------------------------------------------------------//


    [Route("/fragor")] // ändrar routingen
    public IActionResult Questions()
    {

        string user = "Anders";
        ViewBag.user = user;

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