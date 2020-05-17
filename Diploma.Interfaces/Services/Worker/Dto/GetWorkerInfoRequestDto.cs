using System.Security.Claims;

namespace Diploma.Interfaces.Services.Worker.Dto
{
    public class GetWorkerInfoRequestDto : BaseRequestDto
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
