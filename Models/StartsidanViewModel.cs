namespace provet.Models;
public class StartsidanViewModel 
{
    public IEnumerable<ResultDataModel>? LastFiveUsers {get; set;}

    public ParticipantModel? participantModel {get; set;}

    public string? Meddelande {get; set;}
}