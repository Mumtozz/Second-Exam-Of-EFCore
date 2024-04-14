namespace Domain.Entities;

public class Groups
{
    public int Id { get; set; }
    public string? GroupsNick { get; set; }
    public int ChallangeId { get; set; }
    public bool NeededMember { get; set; }
    public string? TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Participant>? Participants { get; set; }
    public Challenge? Challenge { get; set; }
}
