using System.ComponentModel.DataAnnotations;

namespace provet.Models
{
    public class AnswersModel
    {

        [Required(ErrorMessage = "** Välj ett alternativ **")]
        public string? Question1 { get; set; }

          [Required(ErrorMessage = "** Välj ett alternativ **")]
        public string? Question2 { get; set; }

          [Required(ErrorMessage = "** Välj ett alternativ **")]
        public string? Question3 { get; set; }

          [Required(ErrorMessage = "** Välj ett alternativ **")]
        public string? Question4 { get; set; }

          [Required(ErrorMessage = "** Välj ett alternativ **")]
        public string? Question5 { get; set; }


    }
}