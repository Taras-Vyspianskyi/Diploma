using System.Threading.Tasks;
using Diploma.Interfaces.Services.Order;
using Diploma.Interfaces.Services.Order.Dto;

namespace Diploma.Implementation.Services.Order
{
    public class OrderService : BaseService, IOrderService
    {
        public Task<CreateOrderResponseDto> CreateOrder(CreateOrderRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdateOrderStatusResponseDto> UpdateOrderStatus(UpdateOrderStatusRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetOrderInfoResponseDto> GetOrderInfo(GetOrderInfoRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
