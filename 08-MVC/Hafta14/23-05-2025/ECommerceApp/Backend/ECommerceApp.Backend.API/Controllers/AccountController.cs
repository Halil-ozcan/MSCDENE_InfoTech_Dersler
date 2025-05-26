using ECommerceApp.Backend.API.ControllerBases;
using ECommerceApp.Backend.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Backend.API.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : CustomControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyProfile()
        {
            var response = await _accountService.GetByIdAsync(GetUserId());
            return CreateResult(response);
        }
    }
}