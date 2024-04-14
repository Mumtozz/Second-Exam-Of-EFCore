using Domain.ChallengeDTOs;
using Domain.Response;

namespace Infrastructure.Interfaces;

public interface IChallengeService
{
    
    Task<Response<string>> AddChallenge(AddChallengeDTOs addChallengeDTOs);
    Task<Response<List<GetChallengeDTOs>>> GetChallenge();
    Task<Response<string>> UpdateChallenge(UpdateChallengeDTOs updateChallengeDTOs);
    Task<Response<bool>> DeleteChallege(int id);
}
