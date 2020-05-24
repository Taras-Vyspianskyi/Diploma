using System.Linq;
using System.Threading.Tasks;
using Diploma.Interfaces.Services.Customer;
using Diploma.Interfaces.Services.Customer.Dto;
using Diploma.Interfaces.UnitOfWork;
using Diploma.Utils.ErrorHandling;
using Diploma.Utils.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Implementation.Services.Customer
{
    public class CustomerService : BaseService, ICustomerService
    {
        public readonly UserManager<Interfaces.Entities.User> userManager;
        public readonly IUnitOfWork unitOfWork;

        public CustomerService(
            UserManager<Interfaces.Entities.User> userManager,
            IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public Task<GetCustomerInfoResponseDto> GetCustomerInfo(GetCustomerInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await userManager.GetUserAsync(requestDto.ClaimsPrincipal);

                if (user == null)
                {
                    return new GetCustomerInfoResponseDto().AsError("User not found");
                }

                var customerData = (await unitOfWork.CustomerRepository.FilterByAsync(c => c.UserId == user.Id)).First();

                if (user == null)
                {
                    return new GetCustomerInfoResponseDto().AsError("Customer not found");
                }

                return new GetCustomerInfoResponseDto
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Coordinates = customerData.Coordinates
                }.AsSuccess();
            });
        }

        public Task<UpdateCustomerInfoResponseDto> UpdateCustomerInfo(UpdateCustomerInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await userManager.GetUserAsync(requestDto.ClaimsPrincipal);

                if (user == null)
                {
                    return new UpdateCustomerInfoResponseDto().AsError("User not found");
                }

                user.Name = requestDto.Name;
                user.Surname = requestDto.Surname;
                user.PhoneNumber = requestDto.PhoneNumber;

                var customerData = await unitOfWork.CustomerRepository.GetByIdAsync(user.Id);

                if (customerData == null)
                {
                    return new UpdateCustomerInfoResponseDto().AsError("Customer not found");
                }

                customerData.Coordinates = requestDto.Coordinates;

                unitOfWork.CustomerRepository.Update(customerData);

                await userManager.UpdateAsync(user);

                await unitOfWork.SaveAsync();

                return new UpdateCustomerInfoResponseDto
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                    Coordinates = customerData.Coordinates,
                }.AsSuccess();
            });
        }
    }
}
