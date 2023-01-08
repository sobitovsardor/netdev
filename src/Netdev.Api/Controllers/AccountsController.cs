using Microsoft.AspNetCore.Mvc;
using Netdev.Service.Dtos;
using Netdev.Service.Interfaces;

namespace Netdev.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] AccountRegisterDto dto)
        {
            return Ok(await _accountService.RegisterAsync(dto));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] AccountLoginDto dto)
            => Ok(new { Token = await _accountService.LoginAsync(dto) });
    }
}
