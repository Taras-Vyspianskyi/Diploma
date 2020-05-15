using System.Threading.Tasks;
using Diploma.Interfaces.Services.Order.Dto;

namespace Diploma.Interfaces.Services.Order
{
    public interface IOrderService
    {
        Task<CreateOrderResponseDto> CreateOrder(CreateOrderRequestDto requestDto);

        Task<UpdateOrderStatusResponseDto> UpdateOrderStatus(UpdateOrderStatusRequestDto requestDto);

        Task<GetOrderInfoResponseDto> GetOrderInfo(GetOrderInfoRequestDto requestDto);
    }
}
