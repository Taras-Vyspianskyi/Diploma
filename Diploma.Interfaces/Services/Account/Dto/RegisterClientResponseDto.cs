using Microsoft.AspNetCore.Identity;

namespace Diploma.Interfaces.Services.Account.Dto
{
    public class RegisterClientResponseDto : BaseResponseDto
    {
        public IdentityResult IdentityResult { get; set; }
    }
}
