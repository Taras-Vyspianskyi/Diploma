using Diploma.Interfaces.Enums;

namespace Diploma.Interfaces.Services.Account.Dto
{
    public class RegisterClientRequestDto : BaseRequestDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public TransportTypeEnum TransportType { get; set; }

        public WorkerCategoryEnum Category { get; set; }

        public UserTypeEnum UserType { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Password { get; set; }
    }
}
