using System.Threading.Tasks;
using Diploma.Interfaces.Services.Customer.Dto;

namespace Diploma.Interfaces.Services.Customer
{
    public interface ICustomerService
    {
        Task<GetCustomerInfoResponseDto> GetCustomerInfo(GetCustomerInfoRequestDto requestDto);

        Task<UpdateCustomerInfoResponseDto> UpdateCustomerInfo(UpdateCustomerInfoRequestDto requestDto);
    }
}
