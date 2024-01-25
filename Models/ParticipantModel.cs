using System.ComponentModel.DataAnnotations;

namespace provet.Models
{
    public class ParticipantModel
    {

        
        public string? Name { get; set; }

        public string? HigherEd { get; set; }

        public bool? ShowName { get; set; } = false;
    }
}