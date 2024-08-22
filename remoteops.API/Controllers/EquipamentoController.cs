using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using remoteops.Application.Interfaces;
using remoteops.Domain.Entities;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace remoteops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoRepository _repository;

        public EquipamentoController(IEquipamentoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var equipamento = await _repository.GetByIdAsync(id);
            if(equipamento == null) return NotFound();
            return Ok(equipamento);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipamento = await _repository.GetAllAsync();
            return Ok(equipamento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Equipamento equipamento)
        {
            if(equipamento == null) return BadRequest();
            await _repository.AddAsync(equipamento);
            return CreatedAtAction(nameof(Get), new {id = equipamento.id }, equipamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody], Equipamento equipamento)
        {
            if(id != equipamento.Id) return BadRequest();
            await _repository.UpdateAsync(equipamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}