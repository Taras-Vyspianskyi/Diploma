using System.Threading.Tasks;
using Diploma.Interfaces.Services.Worker.Dto;

namespace Diploma.Interfaces.Services.Worker
{
    public interface IWorkerService
    {
        Task<GetCrewMembersResponseDto> GetCrewMembers(GetCrewMembersRequestDto requestDto);

        Task<UpdateCrewResponseDto> UpdateCrew(UpdateCrewRequestDto requestDto);

        Task<GetWorkerInfoResponseDto> GetWorkerInfo(GetWorkerInfoRequestDto requestDto);

        Task<UpdateWorkerInfoResponseDto> UpdateWorkerInfo(UpdateWorkerInfoRequestDto requestDto);
    }
}
