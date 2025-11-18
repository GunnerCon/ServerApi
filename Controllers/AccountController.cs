using Microsoft.AspNetCore.Mvc;
using ServerApi.Services;
using ServerApi.DTOs;

namespace ServerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _service;

        public AccountController(AccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var account = _service.GetById(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public IActionResult Create(CreateAccountDto dto)
        {
            var account = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateAccountDto dto)
        {
            var success = _service.Update(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
