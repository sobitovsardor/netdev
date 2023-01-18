using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netdev.Domain.Entities.Users;
using Netdev.Service.Dtos;
using Netdev.Service.Exceptions;
using Netdev.Service.Interfaces;
using Netdev.Service.Utils;

namespace Netdev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public  IActionResult GetAllAsync([FromQuery] PaginationParams @params)
        {
            try
            {
                return Ok(_userService.GetAllAsync(@params));
               
            }
            catch 
            {
                return StatusCode(500);
                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {
                var result = await _userService.GetAsync(id);
                return Ok(result);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(long id)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);
                return Ok(result);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateAsync([FromForm] UserCreateDto userCreateDto, long id)
        {
            try
            {
                var result = await _userService.UpdateAsync(id, userCreateDto);
                return Ok(result);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
    }
}
