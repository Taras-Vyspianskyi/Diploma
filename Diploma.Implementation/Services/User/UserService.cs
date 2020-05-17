using System.Threading.Tasks;
using Diploma.Interfaces.Services.User;
using Diploma.Interfaces.Services.User.Dto;
using Diploma.Interfaces.UnitOfWork;
using Diploma.Utils.ErrorHandling;
using Diploma.Utils.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Implementation.Services.User
{
    public class UserService : BaseService, IUserService
    {
        public readonly UserManager<Interfaces.Entities.User> UserManager;
        public readonly IUnitOfWork UnitOfWork;

        public UserService(
            UserManager<Interfaces.Entities.User> userManager,
            IUnitOfWork unitOfWork)
        {
            UserManager = userManager;
            UnitOfWork = unitOfWork;
        }

        public Task<GetUserInfoResponseDto> GetUserInfo(GetUserInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await UserManager.GetUserAsync(requestDto.ClaimsPrincipal);

                if (user == null)
                {
                    return new GetUserInfoResponseDto().AsError("User not found");
                }

                return new GetUserInfoResponseDto
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                }.AsSuccess();
            });
        }

        public Task<UpdateUserInfoResponseDto> UpdateUserInfo(UpdateUserInfoRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await UserManager.GetUserAsync(requestDto.ClaimsPrincipal);

                if (user == null)
                {
                    return new UpdateUserInfoResponseDto().AsError("User not found");
                }

                user.Name = requestDto.Name;
                user.Surname = requestDto.Surname;
                user.PhoneNumber = requestDto.PhoneNumber;

                await UserManager.UpdateAsync(user);

                await UnitOfWork.SaveAsync();

                return new UpdateUserInfoResponseDto
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                }.AsSuccess();
            });
        }
    }
}
