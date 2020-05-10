using System;
using System.Threading.Tasks;
using Diploma.Interfaces.Models;
using Diploma.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Implementation.Services
{
    public class AccountService : IAccountService
    {
        public Task<SignInResult> LoginAsync(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
