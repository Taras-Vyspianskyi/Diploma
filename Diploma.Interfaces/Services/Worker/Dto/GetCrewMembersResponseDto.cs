using System.Collections.Generic;

namespace Diploma.Interfaces.Services.Worker.Dto
{
    public class GetCrewMembersResponseDto : BaseResponseDto
    {
        public IEnumerable<GetWorkerInfoResponseDto> Workers { get; set; }
    }
}
