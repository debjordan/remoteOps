using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using remoteops.Application.Interfaces;
using remoteops.Domain.Entities;
using remoteops.Infrastructure.Exceptions;

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
            try
            {
                _context.Equipamento.Add(equipamento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseException("Ocorreu um erro ao adicionar o equipamento ao banco.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var equipamento = await _context.Equipamento.FindAsync(id);
                if (equipamento != null)
                {
                    _context.Equipamento.Remove(equipamento);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseException("Ocorreu um erro ao excluir o equipamento ao banco.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<IEnumerable<Equipamento>> GetAllAsync()
        {
            try
            {
                return await _context.Equipamento.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseException("An error occurred while retrieving all equipamentos.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException("An unexpected error occurred.", ex);
            }
        }

        public async Task<Equipamento> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.Equipamento.FindAsync(id);
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseException("An error occurred while retrieving the equipamento by ID.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException("An unexpected error occurred.", ex);
            }
        }

        public async Task UpdateAsync(Equipamento equipamento)
        {
            try
            {
                _context.Equipamento.Update(equipamento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseException("An error occurred while updating the equipamento in the database.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException("An unexpected error occurred.", ex);
            }
        }
    }
}
