using Diploma.Interfaces.Controllers;
using Diploma.Interfaces.Services.Account;
using Diploma.Interfaces.Services.Account.Dto;
using Diploma.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Diploma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<BaseResponse> RegisterClientAsync(BaseRequest request)
        {
            var response = await accountService.RegisterClient(request.To<RegisterClientRequestDto>());

            return response.To<BaseResponse>();
        }

        [HttpPost]
        public async Task<BaseResponse> Login(BaseRequest request)
        {
            var response = await accountService.RegisterClient(request.To<RegisterClientRequestDto>());

            return response.To<BaseResponse>();
        }

        [HttpPost]
        public async Task<BaseResponse> Logout(BaseRequest request)
        {
            var response = await accountService.RegisterClient(request.To<RegisterClientRequestDto>());

            return response.To<BaseResponse>();
        }
    }
}