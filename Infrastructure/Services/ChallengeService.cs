using System.Net;
using Domain.ChallengeDTOs;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ChallengeService(DataContext _context) : IChallengeService
{
    public async Task<Response<string>> AddChallenge(AddChallengeDTOs addChallengeDTOs)
    {
        try
        {
            var chl = new Challenge()
            {
                Title = addChallengeDTOs.Title,
                Description = addChallengeDTOs.Description
            };
            await _context.Challenges.AddAsync(chl);
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return new Response<string>("Challenge Added Successfuly");
            }
            return new Response<string>("Eror");
        }
        catch (System.Exception)
        {

            return new Response<string>(HttpStatusCode.InternalServerError, "Something going wrong");
        }

    }

    public async Task<Response<bool>> DeleteChallege(int id)
    {
        try
        {
            var existing = await _context.Challenges.FindAsync(id);
            if (existing == null)
            {
                return new Response<bool>(HttpStatusCode.InternalServerError, "Not Found");
            }
            _context.Challenges.Remove(existing);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (System.Exception)
        {

            return new Response<bool>(HttpStatusCode.InternalServerError, "Something going wrong");
        }
    }

    public async Task<Response<List<GetChallengeDTOs>>> GetChallenge()
    {
          try
        {
            var chl = await _context.Challenges.Where(e => e.Id > 0).ToListAsync();
            var list = new List<GetChallengeDTOs>();
            foreach (var ch in chl)
            {
                var challenge = new GetChallengeDTOs()
                {
                    Id = ch.Id,
                    Title = ch.Title,
                    Description = ch.Description
                };
                list.Add(challenge);
            }
            return new Response<List<GetChallengeDTOs>>(list);
        }
        catch (System.Exception ex)
        {

            return new Response<List<GetChallengeDTOs>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> UpdateChallenge(UpdateChallengeDTOs updateChallengeDTOs)
    {
         try
        {
            var existing = await _context.Challenges.FirstOrDefaultAsync(e => e.Id == updateChallengeDTOs.Id);
            if (existing == null)
            {
                return new Response<string>(System.Net.HttpStatusCode.BadRequest, "Not Found");
            }
            existing.Title = updateChallengeDTOs.Title;
            existing.Description = updateChallengeDTOs.Description;
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return new Response<string>("Challege Added Successfuly");
            }
            return new Response<string>("Not Found");
        }
        catch (System.Exception ex)
        {

            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

}
