using System.Net;
using Domain.Entities;
using Domain.GroupDTOs;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService(DataContext _context) : IGroupService
{
    public async Task<Response<string>> AddGroup(AddGroupDTOs groupDTOs)
    {
        try
        {
            var gr = new Groups()
            {
                GroupsNick = groupDTOs.GroupNick,
                ChallangeId = groupDTOs.ChallangeId,
                NeededMember = groupDTOs.NeededMember,
                TeamSlogan = groupDTOs.TeamSlogan,
                CreatedAt = groupDTOs.CreatedAt
            };
            await _context.Groups.AddAsync(gr);
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return new Response<string>("Group Added Successfuly");
            }
            return new Response<string>("Eror");
        }
        catch (System.Exception)
        {

            return new Response<string>(HttpStatusCode.InternalServerError, "Something going wrong");
        }

    }

    public async Task<Response<bool>> DeleteGroup(int id)
    {
        try
        {
            var existing = await _context.Groups.FindAsync(id);
            if (existing == null)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, "Not Found");
            }
            _context.Groups.Remove(existing);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (System.Exception)
        {

            return new Response<bool>(HttpStatusCode.InternalServerError, "Something going wrong");
        }
    }

    public async Task<Response<List<GetGroupDTOs>>> GetGroups()
    {
        try
        {
            var gr = await _context.Groups.Where(e => e.Id > 0).ToListAsync();
            var list = new List<GetGroupDTOs>();
            foreach (var g in gr)
            {
                var group = new GetGroupDTOs()
                {
                    Id = g.Id,
                    GroupNick = g.GroupsNick,
                    ChallangeId = g.ChallangeId,
                    NeededMember = g.NeededMember,
                    TeamSlogan = g.TeamSlogan,
                    CreatedAt = g.CreatedAt,
                    Participants = g.Participants,
                    Challenge = g.Challenge
                };
                list.Add(group);
            }
            return new Response<List<GetGroupDTOs>>(list);
        }
        catch (System.Exception ex)
        {

            return new Response<List<GetGroupDTOs>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> UpdateGroup(UpdateGroupDTOs updateGroupDT)
    {
        try
        {
            var existing = await _context.Groups.FirstOrDefaultAsync(e => e.Id == updateGroupDT.Id);
            if (existing == null)
            {
                return new Response<string>(System.Net.HttpStatusCode.BadRequest, "Not Found");
            }
            existing.GroupsNick = updateGroupDT.GroupNick;
            existing.ChallangeId = updateGroupDT.ChallangeId;
            existing.NeededMember = updateGroupDT.NeededMember;
            existing.TeamSlogan = updateGroupDT.TeamSlogan;
            existing.CreatedAt = updateGroupDT.CreatedAt;
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return new Response<string>("Group Added Successfuly");
            }
            return new Response<string>("Not Found");
        }
        catch (System.Exception ex)
        {

            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

}
