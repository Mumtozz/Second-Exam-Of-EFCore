using Domain.Entities;

namespace Domain.ChallengeDTOs;

public class GetChallengeDTOs
{

    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public List<Groups>? Group { get; set; }
}
