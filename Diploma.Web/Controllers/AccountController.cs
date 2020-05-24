using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Interfaces.Controllers;
using Diploma.Interfaces.Services.Account;
using Diploma.Interfaces.Services.Account.Dto;
using Diploma.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Web.Controllers
{
    public class AccountController : Controller
    {
        public readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient(RegisterClientRequestDto request)
        {
            var response = await accountService.RegisterClient(request.To<RegisterClientRequestDto>());

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegisterClientRequestDto request)
        {
            var response = await accountService.RegisterClient(request.To<RegisterClientRequestDto>());

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(RegisterClientRequestDto request)
        {
            var response = await accountService.RegisterClient(request.To<RegisterClientRequestDto>());

            return View(response);
        }
    }
}