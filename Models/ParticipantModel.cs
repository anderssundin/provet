using System.ComponentModel.DataAnnotations;

namespace provet.Models
{
    public class ParticipantModel
    {

        [Required(ErrorMessage = "Ett namn måste fyllas i")]
        [Display(Name = "Provdeltagare")]
        [MinLength(3, ErrorMessage = "Minst tre tecken långt namn")]
        [MaxLength(15)]
        public string? Name { get; set; }

        public string? HigherEd { get; set; }

        public bool? ShowName { get; set; } = false;
    }
}