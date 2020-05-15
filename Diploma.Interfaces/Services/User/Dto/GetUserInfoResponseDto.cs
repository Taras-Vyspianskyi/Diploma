namespace Diploma.Interfaces.Services.User.Dto
{
    public class GetUserInfoResponseDto : BaseResponseDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
