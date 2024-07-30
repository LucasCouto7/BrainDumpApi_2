using BrainDumpApi_2.Models;
using System.Text.Json.Serialization;

namespace BrainDumpApi_2.DTOs
{
    public class NotaDTO
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public string? Conteudo { get; set; }

        public int? CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
