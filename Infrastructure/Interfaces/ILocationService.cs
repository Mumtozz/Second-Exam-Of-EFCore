using Domain.LocationDTOs;
using Domain.Response;

namespace Infrastructure.Interfaces;

public interface ILocationService
{
    
    Task<Response<string>> AddLocation(AddLocationDTOs locationDTOs);
    Task<Response<List<GetLocationDTOs>>> GetLocations();
    Task<Response<string>> UpdateLocations(UpdateLocationDTOs updateLocationDTOs);
    Task<Response<bool>> DeleteLocation(int id);
}
