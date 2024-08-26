using Microsoft.AspNetCore.Mvc;
using remoteops.Application.Interfaces;
using remoteops.Domain.Entities;
using remoteops.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace remoteops.API.Controllers
{
    [Route("api/Equipamento")]
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
            try
            {
                var equipamento = await _repository.GetByIdAsync(id);
                if (equipamento == null) return NotFound(new Equipamento());
                return Ok(equipamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Equipamento());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var equipamentos = await _repository.GetAllAsync();
                return Ok(equipamentos);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new List<Equipamento>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Equipamento equipamento)
        {
            if (equipamento == null) return BadRequest(new Equipamento());

            try
            {
                await _repository.AddAsync(equipamento);
                return CreatedAtAction(nameof(Get), new { id = equipamento.Id }, equipamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Equipamento());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Equipamento equipamento)
        {
            if (equipamento == null || id != equipamento.Id) return BadRequest(new Equipamento()); // Retorna um objeto vazio em caso de erro de validação

            try
            {
                await _repository.UpdateAsync(equipamento);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Equipamento());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the equipamento." }); // Retorna uma mensagem genérica em caso de erro
            }
        }
    }
}
