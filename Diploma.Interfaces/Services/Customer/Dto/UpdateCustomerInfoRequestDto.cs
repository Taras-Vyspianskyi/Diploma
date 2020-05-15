namespace Diploma.Interfaces.Services.Customer.Dto
{
    public class UpdateCustomerInfoRequestDto : BaseRequestDto
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
    }
}
