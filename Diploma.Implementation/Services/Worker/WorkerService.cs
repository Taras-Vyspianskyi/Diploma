using System.Threading.Tasks;
using Diploma.Interfaces.Services.Worker;
using Diploma.Interfaces.Services.Worker.Dto;

namespace Diploma.Implementation.Services.Worker
{
    public class WorkerService : BaseService, IWorkerService
    {
        public Task<GetCrewMembersResponseDto> GetCrewMembers(GetCrewMembersRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdateCrewResponseDto> UpdateCrew(UpdateCrewRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetWorkerInfoResponseDto> GetWorkerInfo(GetWorkerInfoRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdateWorkerInfoResponseDto> UpdateWorkerInfo(UpdateWorkerInfoRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
