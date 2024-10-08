﻿using System.Text.Json.Serialization;

namespace BrainDumpApi_2.Models
{
    public class Nota
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public string? Conteudo { get; set; }

        public int? CategoriaId { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Ativa { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
