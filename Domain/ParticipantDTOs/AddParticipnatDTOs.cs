namespace Domain.ParticipantDTOs;

public class AddParticipnatDTOs
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public DateTime CreateDate { get; set; }
    public int GroupId { get; set; }
    public int LocationId { get; set; }
}
