using System.ComponentModel.DataAnnotations;

namespace provet.Models;
public class StartsidanViewModel
{
    public IEnumerable<ResultDataModel>? LastFiveUsers { get; set; }

    public ParticipantModel? ParticipantModel { get; set; }


    [Required(ErrorMessage = "Ett namn måste fyllas i")]
    [Display(Name = "Provdeltagare")]
    [MinLength(3, ErrorMessage = "Minst tre tecken långt namn")]
    [MaxLength(15)]
    public string? Name { get; set; }

    public string? Meddelande { get; set; }
}