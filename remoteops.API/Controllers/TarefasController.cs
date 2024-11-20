using Microsoft.AspNetCore.Mvc;
using remoteops.Application.Interfaces;
using remoteops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace remoteops.API.Controllers
{
    [Route("api/Tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _repository;

        public TarefasController(ITarefaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Tarefas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefas = await _repository.GetAllAsync();
            return Ok(tarefas);
        }

        // GET: api/Tarefas/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tarefa = await _repository.GetByIdAsync(id);
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }

        // POST: api/Tarefas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarefa tarefa)
        {
            if (tarefa == null) return BadRequest();

            await _repository.AddAsync(tarefa);
            return CreatedAtAction(nameof(GetById), new { id = tarefa.Id }, tarefa);
        }

        // PUT: api/Tarefas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Tarefa tarefa)
        {
            if (tarefa == null || id != tarefa.Id) return BadRequest();

            await _repository.UpdateAsync(tarefa);
            return NoContent();
        }

        // DELETE: api/Tarefas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
