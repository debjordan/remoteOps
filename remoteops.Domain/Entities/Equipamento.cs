using System;
namespace remoteops.Domain.Entities
{
    public class Equipamento
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data_criada { get; set; }
    }
}