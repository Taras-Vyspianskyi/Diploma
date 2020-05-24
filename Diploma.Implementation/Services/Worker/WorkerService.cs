using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Interfaces.Services.Worker;
using Diploma.Interfaces.Services.Worker.Dto;
using Diploma.Interfaces.UnitOfWork;
using Diploma.Utils.ErrorHandling;
using Diploma.Utils.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Implementation.Services.Worker
{
    public class WorkerService : BaseService, IWorkerService
    {
        public readonly UserManager<Interfaces.Entities.User> userManager;
        public readonly IUnitOfWork unitOfWork;

        public WorkerService(
            UserManager<Interfaces.Entities.User> userManager,
            IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public Task<GetCrewMembersResponseDto> GetCrewMembers(GetCrewMembersRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var workers = await unitOfWork.WorkerRepository.FilterByAsync(c => c.CrewId == requestDto.CrewId);

                if (workers == null)
                {
                    return new GetCrewMembersResponseDto().AsError("Crew not found");
                }

                var result = new List<GetWorkerInfoResponseDto>();

                foreach (var worker in workers)
                {
                    var user = await unitOfWork.UserRepository.GetByIdAsync(worker.UserId);

                    if (user == null)
                    {
                        return new GetCrewMembersResponseDto().AsError("One of the workers data wasn`t found");
                    }

                    result.Add(new GetWorkerInfoResponseDto
                    {
                        UserId = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Category = worker.Category,
                        CrewId = requestDto.CrewId,
                        TransportType = worker.TransportType
                    });
                }

                return new GetCrewMembersResponseDto
                {
                    Workers = result
                }.AsSuccess();
            });
        }

        public Task<UpdateCrewResponseDto> UpdateCrew(UpdateCrewRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                foreach (var workerId in requestDto.WorkerIds)
                {
                    var worker = await unitOfWork.WorkerRepository.GetByIdAsync(workerId);

                    if (worker == null)
                    {
                        return new UpdateCrewResponseDto().AsError("Worker not found");
                    }

                    worker.CrewId = requestDto.CrewId;

                    unitOfWork.WorkerRepository.Update(worker);
                }

                await unitOfWork.SaveAsync();

                return new UpdateCrewResponseDto().AsSuccess();
            });
        }

        public Task<GetWorkerInfoResponseDto> GetWorkerInfo(GetWorkerInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await userManager.GetUserAsync(requestDto.ClaimsPrincipal);

                if (user == null)
                {
                    return new GetWorkerInfoResponseDto().AsError("User not found");
                }

                var workerData = (await unitOfWork.WorkerRepository.FilterByAsync(w => w.UserId == user.Id)).First();

                if (workerData == null)
                {
                    return new GetWorkerInfoResponseDto().AsError("Worker not found");
                }

                return new GetWorkerInfoResponseDto
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    CrewId = workerData.CrewId,
                    Category = workerData.Category,
                    TransportType = workerData.TransportType,
                }.AsSuccess();
            });
        }

        public Task<UpdateWorkerInfoResponseDto> UpdateWorkerInfo(UpdateWorkerInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await userManager.GetUserAsync(requestDto.ClaimsPrincipal);

                if (user == null)
                {
                    return new UpdateWorkerInfoResponseDto().AsError("User not found");
                }

                user.Name = requestDto.Name ?? user.Name;
                user.Surname = requestDto.Surname ?? user.Surname;
                user.PhoneNumber = requestDto.PhoneNumber ?? user.PhoneNumber;

                var workerData = await unitOfWork.WorkerRepository.GetByIdAsync(user.Id);

                if (workerData == null)
                {
                    return new UpdateWorkerInfoResponseDto().AsError("Customer not found");
                }

                workerData.Category = requestDto.Category != 0 ? requestDto.Category : workerData.Category;
                workerData.TransportType = requestDto.TransportType != 0 ? requestDto.TransportType : workerData.TransportType;

                unitOfWork.WorkerRepository.Update(workerData);

                await userManager.UpdateAsync(user);

                await unitOfWork.SaveAsync();

                return new UpdateWorkerInfoResponseDto
                { 
                    UserId = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Category = workerData.Category,
                    TransportType = workerData.TransportType,
                    CrewId = workerData.CrewId,
                }.AsSuccess();
            });
        }
    }
}
