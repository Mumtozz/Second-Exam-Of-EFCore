using Domain.ParticipantDTOs;
using Domain.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("/api/Participant")]
[ApiController]
public class ParticipantController(IParticipantService service) : ControllerBase
{
     [HttpGet("Get-Participant")]
     public async Task<Response<List<GetParticipantDTOs>>> GetParticipants()
    {
        return await service.GetParticipants();
    }
    [HttpPost("Add-Participant")]
    public async Task<Response<string>> AddParticipant(AddParticipnatDTOs addParticipnatDTOs)
    {
      return  await service.AddParticipant(addParticipnatDTOs);
    }
    [HttpPut("Update-Participant")]
     public async Task<Response<string>> UpdateParticipant(UpdateParticipantDTOs updateParticipantDTOs)
    {
        return await service.UpdateParticipant(updateParticipantDTOs);
    }
    [HttpDelete("Delete-Participant")]
    public async Task<Response<bool>> DeleteGroup(int id)
    {
        return await service.DeleteParticipant(id);
    }
}
