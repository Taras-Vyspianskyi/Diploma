using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Interfaces.Services.Order;
using Diploma.Interfaces.Services.Order.Dto;
using Diploma.Interfaces.UnitOfWork;
using Diploma.Utils.ErrorHandling;
using Diploma.Utils.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Implementation.Services.Order
{
    public class OrderService : BaseService, IOrderService
    {
        public readonly UserManager<Interfaces.Entities.User> UserManager;
        public readonly IUnitOfWork UnitOfWork;

        public OrderService(
            UserManager<Interfaces.Entities.User> userManager,
            IUnitOfWork unitOfWork)
        {
            UserManager = userManager;
            UnitOfWork = unitOfWork;
        }

        public Task<CreateOrderResponseDto> CreateOrder(CreateOrderRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var time = DateTime.Now;

                var newOrder = new Interfaces.Entities.Order
                {
                    OrderId = $"{time}-{Guid.NewGuid()}",
                    CustomerId = requestDto.CustomerId,
                    Category = requestDto.Category,
                    OperatorId = requestDto.OperatorId,
                    CrewId = requestDto.CrewId,
                    AddressLine1 = requestDto.AddressLine1,
                    AddressLine2 = requestDto.AddressLine2,
                    Time = time,
                    Status = Interfaces.Enums.ExecutionStatusEnum.Pending
                };

                await UnitOfWork.OrderRepository.AddAsync(newOrder);

                return new CreateOrderResponseDto
                {
                    OrderId = newOrder.OrderId
                }.AsSuccess();
            });
        }

        public Task<UpdateOrderStatusResponseDto> UpdateOrderStatus(UpdateOrderStatusRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var order = await UnitOfWork.OrderRepository.GetByIdAsync(requestDto.OrderId);

                order.Status = requestDto.Status;
                order.Time = DateTime.Now;
                order.Id = string.Empty;

                await UnitOfWork.OrderRepository.AddAsync(order);

                await UnitOfWork.SaveAsync();

                return new UpdateOrderStatusResponseDto
                {
                    Time = order.Time,
                    Status = order.Status
                }.AsSuccess();
            });
        }

        public Task<GetOrderInfoResponseDto> GetOrderInfo(GetOrderInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var orders = (await UnitOfWork.OrderRepository.FilterByAsync(o => o.OrderId == requestDto.OrderId));

                return new GetOrderInfoResponseDto
                {
                    OrderData = orders
                }.AsSuccess();
            });
        }
    }
}
