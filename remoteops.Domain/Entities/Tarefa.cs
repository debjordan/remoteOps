using System;
using System.ComponentModel.DataAnnotations;
namespace remoteops.Domain.Entities
{
    public class Tarefa
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Descricao { get; set; }
    public string Status { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public DateTime? DataConclusao { get; set; }
}
}