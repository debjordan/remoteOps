using Microsoft.EntityFrameworkCore;
using remoteops.Domain.Entities;
namespace remoteops.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Equipamento> Equipamentos { get; set; }
    }
}