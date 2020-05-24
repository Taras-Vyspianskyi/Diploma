using System;
using System.Threading.Tasks;
using Diploma.Interfaces.Enums;
using Diploma.Interfaces.Services.Account;
using Diploma.Interfaces.Services.Account.Dto;
using Diploma.Interfaces.UnitOfWork;
using Diploma.Utils.ErrorHandling;
using Diploma.Utils.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Implementation.Services.Account
{
    public class AccountService : BaseService, IAccountService
    {
        public readonly UserManager<Interfaces.Entities.User> userManager;
        public readonly SignInManager<Interfaces.Entities.User> signInManager;
        public readonly RoleManager<IdentityRole> roleManager;
        public readonly IUnitOfWork unitOfWork;

        public AccountService(
            UserManager<Interfaces.Entities.User> userManager,
            SignInManager<Interfaces.Entities.User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.unitOfWork = unitOfWork;
        }

        public Task<LoginResponseDto> Login(LoginRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var authResult = await signInManager.PasswordSignInAsync(
                requestDto.Email,
                requestDto.Password,
                true,
                false);

                return new LoginResponseDto
                {
                    SignInResult = authResult
                }.AsSuccess();
            });
        }

        public Task<LogoutResponseDto> Logout(LogoutRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                await signInManager.SignOutAsync();

                return new LogoutResponseDto().AsSuccess();
            });
        }

        public Task<RegisterClientResponseDto> RegisterClient(RegisterClientRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = new Interfaces.Entities.User
                {
                    Name = requestDto.Name,
                    Surname = requestDto.Surname,
                    UserName = requestDto.Email,
                    Email = requestDto.Email,
                    PhoneNumber = requestDto.PhoneNumber
                };

                var result = await userManager.CreateAsync(user, requestDto.Password);

                if (!result.Succeeded)
                {
                    return new RegisterClientResponseDto().AsError(result.Errors == null ? string.Join("\n", result.Errors) : "Undefined registration error occured");
                }

                try
                {
                    if (requestDto.UserType == UserTypeEnum.Worker)
                    {
                        await unitOfWork.WorkerRepository.AddAsync(new Interfaces.Entities.Worker
                        {
                            UserId = user.Id,
                            Category = requestDto.Category,
                            TransportType = requestDto.TransportType
                        });

                        await unitOfWork.SaveAsync();

                        await userManager.AddToRoleAsync(user, nameof(UserTypeEnum.Worker));
                    }
                    else if (requestDto.UserType == UserTypeEnum.Customer)
                    {
                        await unitOfWork.CustomerRepository.AddAsync(new Interfaces.Entities.Customer
                        {
                            UserId = user.Id,
                            Coordinates = requestDto.Coordinates,
                        });

                        await unitOfWork.SaveAsync();

                        await userManager.AddToRoleAsync(user, nameof(UserTypeEnum.Customer));
                    }
                    else
                    {
                        throw new Exception("Unknown user type");
                    }
                }
                catch (Exception ex)
                {
                    await userManager.DeleteAsync(user);
                    throw new Exception("Registration failed", ex);
                }

                return new RegisterClientResponseDto
                { 
                    IdentityResult = result
                }.AsSuccess();
            });
        }

        public Task<CreateUserResponseDto> CreateUser(CreateUserRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = new Interfaces.Entities.User
                {
                    Name = requestDto.Name,
                    Surname = requestDto.Surname,
                    UserName = requestDto.Email,
                    Email = requestDto.Email,
                    PhoneNumber = requestDto.PhoneNumber
                };

                var result = await userManager.CreateAsync(user, requestDto.Password);

                if (!result.Succeeded)
                {
                    return new CreateUserResponseDto().AsError(result.Errors == null ? string.Join("\n", result.Errors) : "Undefined user creation error occured");
                }

                return new CreateUserResponseDto
                {
                    IdentityResult = result
                }.AsSuccess();
            });

        }

        public Task<UpdatePasswordResponseDto> UpdatePassword(UpdatePasswordRequestDto requestDto)
        {
            return ErrorHandler.HandleRequestAsync(async () =>
            {
                var user = await userManager.GetUserAsync(requestDto.ClaimsPrincipal);

                await userManager.ChangePasswordAsync(user, requestDto.OldPassword, requestDto.NewPassword);

                return new UpdatePasswordResponseDto().AsSuccess();
            });
        }
    }
}
