using System.Net;
using Domain.Entities;
using Domain.ParticipantDTOs;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService(DataContext _context) : IParticipantService
{
    public async Task<Response<string>> AddParticipant(AddParticipnatDTOs addParticipnat)
    {
          try
        {
            var pr = new Participant()
            {
                FullName = addParticipnat.FullName,
                Email = addParticipnat.Email,
                Phone = addParticipnat.Phone,
                Password = addParticipnat.Phone,
                CreateDate = addParticipnat.CreateDate,
                GroupId = addParticipnat.GroupId,
                LocationId = addParticipnat.LocationId
            };
            await _context.Participants.AddAsync(pr);
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return new Response<string>("Participant Added Successfuly");
            }
            return new Response<string>("Eror");
        }
        catch (System.Exception)
        {

            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, "Something going wrong");
        }
    }

    public async Task<Response<bool>> DeleteParticipant(int id)
    {
          try
        {
            var existing = await _context.Participants.FindAsync(id);
            if (existing == null)
            {
                return new Response<bool>(System.Net.HttpStatusCode.BadRequest, "Not Found");
            }
            _context.Participants.Remove(existing);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (System.Exception)
        {

            return new Response<bool>(HttpStatusCode.InternalServerError, "Something going wrong");
        }
    }

    public async Task<Response<List<GetParticipantDTOs>>> GetParticipants()
    {
         try
        {
            var pr = await _context.Participants.Where(e => e.Id > 0).ToListAsync();
            var list = new List<GetParticipantDTOs>();
            foreach (var p in pr)
            {
                var part = new GetParticipantDTOs()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Email = p.Email,
                    Phone = p.Phone,
                    Password = p.Password,
                    CreateDate = p.CreateDate,
                    GroupId = p.GroupId,
                    LocationId = p.LocationId,
                    Group = p.Group,
                    Location = p.Location
                };
                list.Add(part);
            }
            return new Response<List<GetParticipantDTOs>>(list);
        }
        catch (System.Exception ex)
        {

            return new Response<List<GetParticipantDTOs>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> UpdateParticipant(UpdateParticipantDTOs updateParticipant)
    {
         try
        {
            var existing = await _context.Participants.FirstOrDefaultAsync(e => e.Id == updateParticipant.Id);
            if (existing == null)
            {
                return new Response<string>(System.Net.HttpStatusCode.BadRequest, "Not Found");
            }
            existing.FullName = updateParticipant.FullName;
            existing.Email=  updateParticipant.Email;
            existing.Phone = updateParticipant.Phone;
            existing.Password = updateParticipant.Password;
            existing.CreateDate = updateParticipant.CreateDate;
            existing.GroupId = updateParticipant.GroupId;
            existing.LocationId = updateParticipant.LocationId;
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return new Response<string>("Participant Added Successfuly");
            }
            return new Response<string>("Not Found");
        }
        catch (System.Exception ex)
        {

            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

}
