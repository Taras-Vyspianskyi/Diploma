using System.Security.Claims;

namespace Diploma.Interfaces.Services.Account.Dto
{
    public class UpdatePasswordRequestDto : BaseRequestDto
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
