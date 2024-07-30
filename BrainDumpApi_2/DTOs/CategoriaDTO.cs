using System.ComponentModel.DataAnnotations;

namespace BrainDumpApi_2.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string? Cor { get; set; }
    }
}
