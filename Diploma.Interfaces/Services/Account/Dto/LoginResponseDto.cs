using Microsoft.AspNetCore.Identity;

namespace Diploma.Interfaces.Services.Account.Dto
{
    public class LoginResponseDto : BaseResponseDto
    {
        public string UserId { get; set; }
        
        public SignInResult SignInResult { get; set; }
    }
}
