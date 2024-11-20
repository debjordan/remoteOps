using System;
using System.ComponentModel.DataAnnotations;
namespace remoteops.Domain.Entities
{
    public class Equipamento
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do equipamento. Ex: S1M11")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Informe uma descrição. MAX 50 Caracteres.")]
        [MaxLength(50, ErrorMessage = "Precisa ser menor que 50 caracteres.")]
        public string? Descricao { get; set; }
        public DateTime Data_criada { get; set; } = DateTime.UtcNow;
    }
}