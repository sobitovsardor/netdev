using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netdev.Domain.Entities.Docs;
using Netdev.Service.Dtos;
using Netdev.Service.Exceptions;
using Netdev.Service.Interfaces;
using System.Security.AccessControl;

namespace Netdev.Api.Controllers
{
    [Route("api/documentation")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        private IDocsService _docsService;
        public DocsController(IDocsService docsService)
        {
            this._docsService = docsService;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _docsService.GetAllAsync();
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
                var result = await _docsService.GetAsync(id);
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
        public async Task<IActionResult> CreateAsync([FromForm] DocCreatedto dto)
        {
            try
            {
                var result = await _docsService.CreateAsync(dto);
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
                var result = await _docsService.DeleteAsync(id);
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
        public async Task<IActionResult> UpdateByIdAsync(long id, [FromBody] Doc obj)
        {
            try
            {
                var result = await _docsService.UpdateAsync(id, obj);
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
