using System.Threading.Tasks;
using Diploma.Interfaces.Services.Account;
using Diploma.Interfaces.Services.Account.Dto;

namespace Diploma.Implementation.Services.Account
{
    public class AccountService : BaseService, IAccountService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<LogoutResponseDto> Logout(LogoutRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<RegisterClientResponseDto> RegisterClient(RegisterClientRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<CreateUserResponseDto> CreateUser(CreateUserRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdatePasswordResponseDto> UpdatePassword(UpdatePasswordRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
