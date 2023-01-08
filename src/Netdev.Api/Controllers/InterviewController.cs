using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netdev.Domain.Entities.Docs;
using Netdev.Domain.Entities.Interviews;
using Netdev.Service.Dtos;
using Netdev.Service.Exceptions;
using Netdev.Service.Interfaces;
using Netdev.Service.Services;

namespace Netdev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private IInterviewService _interviewservice;

        public InterviewController(IInterviewService interviewService)
        {
                this._interviewservice = interviewService;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _interviewservice.GetAllAsync();
                return Ok(result);
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
                var result = await _interviewservice.GetAsync(id);
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] InterviewCreatedto dto)
        {
            try
            {
                var result = await _interviewservice.CreateAsync(dto);
                if (result) return Ok();
                else return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(long id)
        {
            try
            {
                var result = await _interviewservice.DeleteAsync(id);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateByIdAsync(long id, [FromBody] Interview obj)
        {
            try
            {
                var result = await _interviewservice.UpdateAsync(id, obj);
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
