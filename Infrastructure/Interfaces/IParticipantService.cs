using Domain.ParticipantDTOs;
using Domain.Response;

namespace Infrastructure.Interfaces;

public interface IParticipantService
{
    
    Task<Response<string>> AddParticipant(AddParticipnatDTOs addParticipnat);
    Task<Response<List<GetParticipantDTOs>>> GetParticipants();
    Task<Response<string>> UpdateParticipant(UpdateParticipantDTOs updateParticipant);
    Task<Response<bool>> DeleteParticipant(int id);
}
