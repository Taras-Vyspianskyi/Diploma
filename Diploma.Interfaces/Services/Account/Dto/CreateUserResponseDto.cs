using Microsoft.AspNetCore.Identity;

namespace Diploma.Interfaces.Services.Account.Dto
{
    public class CreateUserResponseDto : BaseResponseDto
    {
        public IdentityResult IdentityResult { get; set; }
    }
}
