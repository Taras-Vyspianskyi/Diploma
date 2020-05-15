namespace Diploma.Interfaces.Services.Account.Dto
{
    public class LoginRequestDto : BaseRequestDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
