using Domain.ChallengeDTOs;
using Domain.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("/api/Challenge")]
[ApiController]
public class ChallengeController(IChallengeService service) : ControllerBase
{
    [HttpGet("Get-Chalenge")]
     public async Task<Response<List<GetChallengeDTOs>>> GetGroup()
    {
        return await service.GetChallenge();
    }
    [HttpPost("Add-Chalenge")]
    public async Task<Response<string>> AddChallenge(AddChallengeDTOs addChallengeDTOs)
    {
      return  await service.AddChallenge(addChallengeDTOs);
    }
    [HttpPut("Update-Challenge")]
     public async Task<Response<string>> UpdateChallenge(UpdateChallengeDTOs updateChallengeDTOs)
    {
        return await service.UpdateChallenge(updateChallengeDTOs);
    }
    [HttpDelete("Delete-Challenge")]
    public async Task<Response<bool>> DeleteChallege(int id)
    {
        return await service.DeleteChallege(id);
    }
}
