using System.Security.Claims;

namespace Diploma.Interfaces.Services.User.Dto
{
    public class UpdateUserInfoRequestDto : BaseRequestDto
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}
