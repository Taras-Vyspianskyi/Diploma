using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Interfaces.Enums;
using Diploma.Interfaces.Services.Elastic;
using Diploma.Interfaces.Services.Elastic.Dto;
using Diploma.Interfaces.Services.Order;
using Diploma.Interfaces.Services.Order.Dto;
using Diploma.Interfaces.Services.RouteProvider;
using Diploma.Interfaces.Services.RouteProvider.Dto;
using Diploma.Interfaces.UnitOfWork;
using Diploma.Utils.ErrorHandling;
using Diploma.Utils.Extensions;
using Microsoft.AspNetCore.Identity;
using Nest;

namespace Diploma.Implementation.Services.Order
{
    public class OrderService : BaseService, IOrderService
    {
        public readonly UserManager<Interfaces.Entities.User> userManager;
        public readonly IUnitOfWork unitOfWork;
        public readonly IElasticService elasticService;
        public readonly IRouteService routeService;

        public OrderService(
            UserManager<Interfaces.Entities.User> userManager,
            IUnitOfWork unitOfWork,
            IElasticService elasticService,
            IRouteService routeService)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.elasticService = elasticService;
            this.routeService = routeService;
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
                    Coordinates = requestDto.Coordinates,
                    AddressLine2 = requestDto.AddressLine2,
                    Time = time,
                    Status = ExecutionStatusEnum.Pending
                };

                await unitOfWork.OrderRepository.AddAsync(newOrder);

                var lastCrewOrderCoords = (await unitOfWork.OrderRepository.FilterByAsync(x => x.CrewId == requestDto.CrewId)).OrderByDescending(x => x.Id).First().Coordinates;

                var transportType = (await unitOfWork.WorkerRepository.FilterByAsync(x => x.CrewId == requestDto.CrewId)).First().TransportType;

                var minutes = (await routeService.GetRouteTime(new GetRouteTimeRequestDto
                {
                    CoordinatesFrom = lastCrewOrderCoords,
                    CoordinatesTo = requestDto.Coordinates,
                    TransportType = transportType.GetDescription()
                })).Minutes;

                await unitOfWork.TimeToOrderRepository.AddAsync(new Interfaces.Entities.TimeToOrder
                {
                    OrderId = newOrder.OrderId,
                    Minutes = minutes
                });

                await unitOfWork.SaveAsync();

                var crewAvailability = await elasticService.SearchCrew(requestDto.CrewId);
                double currentAvailability = 0;

                if (crewAvailability != null)
                {
                    currentAvailability = crewAvailability.Minutes;
                }

                currentAvailability += minutes + 60;

                await elasticService.CreateOrUpdateCrewAvailability(new CrewAvailability
                { 
                    CrewId = requestDto.CrewId,
                    Minutes = currentAvailability
                });

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
                var order = await unitOfWork.OrderRepository.GetByIdAsync(requestDto.OrderId);

                order.Status = requestDto.Status;
                order.Time = DateTime.Now;
                order.Id = default;

                await unitOfWork.OrderRepository.AddAsync(order);

                await unitOfWork.SaveAsync();

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
                var orders = (await unitOfWork.OrderRepository.FilterByAsync(o => o.OrderId == requestDto.OrderId));

                return new GetOrderInfoResponseDto
                {
                    OrderData = orders
                }.AsSuccess();
            });
        }
    }
}
