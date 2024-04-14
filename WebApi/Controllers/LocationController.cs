using Domain.LocationDTOs;
using Domain.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Location")]
[ApiController]
public class LocationController(ILocationService service) : ControllerBase
{

    [HttpGet("Get-Locations")]
    public async Task<Response<List<GetLocationDTOs>>> GetLocations()
    {
        return await service.GetLocations();
    }
    [HttpPost("Add-Location")]
    public async Task<Response<string>> AddLocation(AddLocationDTOs addLocationDTOs)
    {
        return await service.AddLocation(addLocationDTOs);
    }
    [HttpPut("Update-Location")]
    public async Task<Response<string>> UpdateLocation(UpdateLocationDTOs updateLocationDTOs)
    {
        return await service.UpdateLocations(updateLocationDTOs);
    }
    [HttpDelete("Delete-Location")]
    public async Task<Response<bool>> DeleteLocation(int id)
    {
        return await service.DeleteLocation(id);
    }
}
