

using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            //Rensar session
            HttpContext.Session.Clear();

            // Hämta in fil för att lista de fem senaste testen
            var jsonStr = System.IO.File.ReadAllText("result.json");
            var JsonObj = JsonConvert.DeserializeObject<IEnumerable<ResultDataModel>>(jsonStr);
            var viewModel = new StartsidanViewModel
            {
                LastFiveUsers = JsonObj,
                ParticipantModel = new ParticipantModel()
                
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(ParticipantModel participant)
        {
            ViewData["title"] = "Startsidan"; // Sidans titel

   

            // Om valid input spara variabler och skicka vidare till frågor
            if (ModelState.IsValid)
            {
                // Spara sessions-variabler från formulär
                if (participant.Name != null && participant.HigherEd != null)
                {
                    HttpContext.Session.SetString("_name", participant.Name);
                    HttpContext.Session.SetString("_education", participant.HigherEd);
#pragma warning disable CS8604 // Possible null reference argument.
                    HttpContext.Session.SetString("_consent", participant.ShowName.ToString()); // Kan ej vara null
#pragma warning restore CS8604 // Possible null reference argument.

                }
                return RedirectToAction("Questions");
            }
            // Hämta in fil för att lista de fem senaste testen
            var jsonStr = System.IO.File.ReadAllText("result.json");
            var JsonObj = JsonConvert.DeserializeObject<IEnumerable<ResultDataModel>>(jsonStr);
            var viewModel = new StartsidanViewModel
            {
                LastFiveUsers = JsonObj,
                ParticipantModel = new ParticipantModel()
            };
            return View(viewModel);
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


        // Hantera frågeformuläret

        [HttpPost]
        [Route("/fragor")] // ändrar routingen
        public IActionResult Questions(AnswersModel answers)
        {
              ViewData["title"] = "Frågor"; // Sidans titel
            if(ModelState.IsValid) {
            // Skapa en varibel som håller antalet rätta svar
            int points = 0;

            // Rätta provet

            if (answers.Question1 == "alternative3")
            {
                points++;
            }
            if (answers.Question2 == "alternative2")
            {
                points++;
            }
            if (answers.Question3 == "alternative2")
            {
                points++;
            }
            if (answers.Question4 == "alternative2")
            {
                points++;
            }
            if (answers.Question5 == "alternative1")
            {
                points++;
            }

            //Skapa en sessionsvariabel för poängen
            HttpContext.Session.SetString("_points", points.ToString());

            if (HttpContext.Session.GetString("_consent")?.ToLower() == "true")
            {
                // Skapa json
                var result = new ResultDataModel
                {
                    Name = HttpContext.Session.GetString("_name"),
                    HigherEd = HttpContext.Session.GetString("_education"),
                    Score = points
                };



                var fetchedFile = System.IO.File.ReadAllText("result.json");
                var file = JsonConvert.DeserializeObject<List<ResultDataModel>>(fetchedFile);

                if (file != null){
                // Lägg till till listan File
                file.Insert(0, result);

                // Behåll bara de fem första posterna
                file = file.Take(5).ToList();

                // Skriv till filen
                var updatedJson = JsonConvert.SerializeObject(file, Formatting.Indented);
                System.IO.File.WriteAllText("result.json", updatedJson);
                }
            }
            return RedirectToAction("Result");
 }
            
           return View();
        }
        /* RESULTAT */
        //-------------------------------------------------------//


        [Route("/resultat")] // ändrar routingen
        public IActionResult Result()
        {
            ViewData["title"] = "Resultat"; // Sidans titel
            ViewBag.resultName = HttpContext.Session.GetString("_name");
            ViewBag.testresult = HttpContext.Session.GetString("_points");
            return View();
        }
    }
}