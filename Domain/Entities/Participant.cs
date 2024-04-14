namespace Domain.Entities;

public class Participant
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public DateTime CreateDate { get; set; }
    public int GroupId { get; set; }
    public int LocationId { get; set; }
    public Groups? Group { get; set; }
    public Location? Location { get; set; }
}
