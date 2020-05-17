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
        public readonly UserManager<Interfaces.Entities.User> UserManager;
        public readonly IUnitOfWork UnitOfWork;

        public CustomerService(
            UserManager<Interfaces.Entities.User> userManager,
            IUnitOfWork unitOfWork)
        {
            UserManager = userManager;
            UnitOfWork = unitOfWork;
        }

        public Task<GetCustomerInfoResponseDto> GetCustomerInfo(GetCustomerInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await UserManager.GetUserAsync(requestDto.ClaimsPrincipal);

                if (user == null)
                {
                    return new GetCustomerInfoResponseDto().AsError("User not found");
                }

                var customerData = (await UnitOfWork.CustomerRepository.FilterByAsync(c => c.UserId == user.Id)).First();

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
                    AddressLine1 = customerData.AddressLine1,
                    AddressLine2 = customerData.AddressLine2
                }.AsSuccess();
            });
        }

        public Task<UpdateCustomerInfoResponseDto> UpdateCustomerInfo(UpdateCustomerInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await UserManager.GetUserAsync(requestDto.ClaimsPrincipal);

                if (user == null)
                {
                    return new UpdateCustomerInfoResponseDto().AsError("User not found");
                }

                user.Name = requestDto.Name;
                user.Surname = requestDto.Surname;
                user.PhoneNumber = requestDto.PhoneNumber;

                var customerData = await UnitOfWork.CustomerRepository.GetByIdAsync(user.Id);

                if (customerData == null)
                {
                    return new UpdateCustomerInfoResponseDto().AsError("Customer not found");
                }

                customerData.AddressLine1 = requestDto.AddressLine1;
                customerData.AddressLine2 = requestDto.AddressLine2;

                UnitOfWork.CustomerRepository.Update(customerData);

                await UserManager.UpdateAsync(user);

                await UnitOfWork.SaveAsync();

                return new UpdateCustomerInfoResponseDto
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                    AddressLine1 = customerData.AddressLine1,
                    AddressLine2 = customerData.AddressLine2
                }.AsSuccess();
            });
        }
    }
}
