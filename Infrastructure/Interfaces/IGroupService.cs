using Domain.GroupDTOs;
using Domain.Response;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    
    Task<Response<string>> AddGroup(AddGroupDTOs groupDTOs);
    Task<Response<List<GetGroupDTOs>>> GetGroups();
    Task<Response<string>> UpdateGroup(UpdateGroupDTOs updateGroupDT);
    Task<Response<bool>> DeleteGroup(int id);
}
