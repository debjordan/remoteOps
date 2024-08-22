using System;
using remoteops.Application.Interfaces;
using remoteops.Domain.Entities;

namespace remoteops.Infrastructure.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Equipamento equipamento)
        {
            object value = _context.Equipamento.Add(equipamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var equipamento = await _context.Equipamento.FindAsync(id);
            if(equipamento != null)
            {
                _context.Equipamento.Remove(equipamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Equipamento>> GetAllAsync()
        {
            return await _context.Equipamento.ToListAsync(id);
        }

        public async Task<Equipamento> GetByIdAsync(Guid id)
        {
            return await _context.Equipamento.FindAsync(id);
        }

        public async Task UpdateAsync(Equipamento equipamento)
        {
            _context.Equipamento.Update(equipamento);
            await _context.SaveChangesAsync();
        }
    }
}