using System.Security.Claims;

namespace Diploma.Interfaces.Services.Customer.Dto
{
    public class GetCustomerInfoRequestDto : BaseRequestDto
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
