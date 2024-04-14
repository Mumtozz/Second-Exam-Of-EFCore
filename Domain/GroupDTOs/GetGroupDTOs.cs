using Domain.Entities;

namespace Domain.GroupDTOs;

public class GetGroupDTOs
{
    
    public int Id { get; set; }
    public string? GroupNick { get; set; }
    public int ChallangeId { get; set; }
    public bool NeededMember { get; set; }
    public string? TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Participant>? Participants { get; set; }
    public Challenge? Challenge { get; set; }
}
