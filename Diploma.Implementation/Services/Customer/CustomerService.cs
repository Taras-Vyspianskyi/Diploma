using System.Threading.Tasks;
using Diploma.Interfaces.Services.Customer;
using Diploma.Interfaces.Services.Customer.Dto;

namespace Diploma.Implementation.Services.Customer
{
    public class CustomerService : BaseService, ICustomerService
    {
        public Task<GetCustomerInfoResponseDto> GetCustomerInfo(GetCustomerInfoRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdateCustomerInfoResponseDto> UpdateCustomerInfo(UpdateCustomerInfoRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
