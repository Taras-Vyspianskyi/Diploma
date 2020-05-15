using System.Threading.Tasks;
using Diploma.Interfaces.Services.Account.Dto;

namespace Diploma.Interfaces.Services.Account
{
    public interface IAccountService
    {
        Task<LoginResponseDto> Login(LoginRequestDto requestDto);

        Task<LogoutResponseDto> Logout(LogoutRequestDto requestDto);

        Task<RegisterClientResponseDto> RegisterClient(RegisterClientRequestDto requestDto);

        Task<CreateUserResponseDto> CreateUser(CreateUserRequestDto requestDto);

        Task<UpdatePasswordResponseDto> UpdatePassword(UpdatePasswordRequestDto requestDto);
    }
}
