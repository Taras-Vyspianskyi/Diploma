using Diploma.Interfaces.Services.Elastic.Dto;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Interfaces.Services.Elastic
{
    public interface IElasticService
    {
        Task<List<CrewAvailability>> SearchCrews();

        Task<CrewAvailability> SearchCrew(int id);

        Task<bool> CreateOrUpdateCrewAvailability(CrewAvailability crewAvailability);
    }
}
