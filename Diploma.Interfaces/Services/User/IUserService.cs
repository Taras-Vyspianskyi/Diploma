using System.Threading.Tasks;
using Diploma.Interfaces.Services.User.Dto;

namespace Diploma.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<GetUserInfoResponseDto> GetUserInfo(GetUserInfoRequestDto requestDto);

        Task<UpdateUserInfoResponseDto> UpdateUserInfo(UpdateUserInfoRequestDto requestDto);
    }
}
