namespace Domain.GroupDTOs;

public class AddGroupDTOs
{
    
    public string? GroupNick { get; set; }
    public int ChallangeId { get; set; }
    public bool NeededMember { get; set; }
    public string? TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
}
