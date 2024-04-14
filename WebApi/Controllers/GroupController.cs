using Domain.GroupDTOs;
using Domain.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Group")]
[ApiController]
public class GroupController(IGroupService service) : ControllerBase
{
    [HttpGet("Get-Groups")]
     public async Task<Response<List<GetGroupDTOs>>> GetGroup()
    {
        return await service.GetGroups();
    }
    [HttpPost("Add-Group")]
    public async Task<Response<string>> AddGroup(AddGroupDTOs addGroupDTOs)
    {
      return  await service.AddGroup(addGroupDTOs);
    }
    [HttpPut("Update-Group")]
     public async Task<Response<string>> UpdateGroup(UpdateGroupDTOs update)
    {
        return await service.UpdateGroup(update);
    }
    [HttpDelete("Delete-Group")]
    public async Task<Response<bool>> DeleteGroup(int id)
    {
        return await service.DeleteGroup(id);
    }
}







