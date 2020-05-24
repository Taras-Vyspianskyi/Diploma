namespace Diploma.Interfaces.Services.Customer.Dto
{
    public class GetCustomerInfoResponseDto : BaseResponseDto
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Coordinates { get; set; }

        public string AddressLine2 { get; set; }
    }
}
