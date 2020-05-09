using System.Threading.Tasks;
using Diploma.Interfaces.Models;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Interfaces.Services
{
    public interface IAccountService
    {
        Task<SignInResult> LoginAsync(LoginModel loginModel);

        Task LogoutAsync();
    }
}
