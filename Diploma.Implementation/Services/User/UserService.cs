using System.Threading.Tasks;
using Diploma.Interfaces.Services.User;
using Diploma.Interfaces.Services.User.Dto;

namespace Diploma.Implementation.Services.User
{
    public class UserService : IUserService
    {
        public Task<GetUserInfoResponseDto> GetUserInfo(GetUserInfoRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdateUserInfoResponseDto> UpdateUserInfo(UpdateUserInfoRequestDto requestDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
