using System.Net;
using Domain.Entities;
using Domain.LocationDTOs;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService(DataContext _context) : ILocationService
{
    public async Task<Response<string>> AddLocation(AddLocationDTOs locationDTOs)
    {
        try
        {
            var lc = new Location()
            {
                Name = locationDTOs.Name,
                Description = locationDTOs.Description
            };
            await _context.Locations.AddAsync(lc);
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return new Response<string>("Location Added Successfuly");
            }
            return new Response<string>("Eror");
        }
        catch (System.Exception)
        {

            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, "Something going wrong");
        }
    }

    public async Task<Response<bool>> DeleteLocation(int id)
    {
         try
        {
            var existing = await _context.Locations.FindAsync(id);
            if (existing == null)
            {
                return new Response<bool>(System.Net.HttpStatusCode.BadRequest, "Not Found");
            }
            _context.Locations.Remove(existing);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (System.Exception)
        {

            return new Response<bool>(HttpStatusCode.InternalServerError, "Something going wrong");
        }
    }

    public async Task<Response<List<GetLocationDTOs>>> GetLocations()
    {
        try
        {
        var lc = await _context.Locations.Where(e => e.Id > 0).ToListAsync();
        var list = new List<GetLocationDTOs>();
        foreach (var l in lc)
        {
            var group = new GetLocationDTOs()
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                Participants = l.Participants
            };
            list.Add(group);
        }
        return new Response<List<GetLocationDTOs>>(list);
        }
        catch (System.Exception ex)
        {
            
            return new Response<List<GetLocationDTOs>>(HttpStatusCode.InternalServerError,ex.Message);
        }

    }

    public async Task<Response<string>> UpdateLocations(UpdateLocationDTOs updateLocationDTOs)
    {
        try
        {
            var existing = await _context.Locations.FirstOrDefaultAsync(e => e.Id == updateLocationDTOs.Id);
            if (existing == null)
            {
                return new Response<string>(System.Net.HttpStatusCode.InternalServerError, "Not Found");
            }
            existing.Name = updateLocationDTOs.Name;
            existing.Description = updateLocationDTOs.Description;
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return new Response<string>("Location Added Successfuly");
            }
            return new Response<string>("Not Found");
        }
        catch (System.Exception ex)
        {

            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

}
