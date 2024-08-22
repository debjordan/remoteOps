using remoteops.Domain.Entities;
using System;
namespace remoteops.Application.Interfaces
{
    public interface IEquipamentoRepository
    {
        Task<Equipamento> GetByIdAsync(Guid id);
        Task<IEnumerable<Equipamento>> GetAllAsync();
        Task AddAsync(Equipamento equipamento);
        Task UpdateAsync(Equipamento equipamento);
        Task DeleteAsync(Guid id);
    }
}