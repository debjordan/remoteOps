using remoteops.Domain.Entities;
using System;
namespace remoteops.Application.Interfaces
{
    public interface ITarefaRepository
    {
         Task<Tarefa> GetByIdAsync(Guid id);
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task AddAsync(Tarefa tarefa);
        Task UpdateAsync(Tarefa tarefa);
        Task DeleteAsync(Guid id);
    }
}