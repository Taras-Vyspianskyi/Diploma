namespace Diploma.Interfaces.Services.Account.Dto
{
    public class UpdatePasswordRequestDto : BaseRequestDto
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
