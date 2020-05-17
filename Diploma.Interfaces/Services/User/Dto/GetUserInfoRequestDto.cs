using System.Security.Claims;

namespace Diploma.Interfaces.Services.User.Dto
{
    public class GetUserInfoRequestDto : BaseRequestDto
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
