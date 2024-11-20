using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using remoteops.Application.Interfaces;
using remoteops.Domain.Entities;

namespace remoteops.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _context;

        public TarefaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> GetByIdAsync(Guid id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
