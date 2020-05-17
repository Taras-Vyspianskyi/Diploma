using System.Collections.Generic;

namespace Diploma.Interfaces.Services.Worker.Dto
{
    public class UpdateCrewRequestDto : BaseRequestDto
    {
        public int CrewId { get; set; }

        public IEnumerable<string> WorkerIds { get; set; }
    }
}
