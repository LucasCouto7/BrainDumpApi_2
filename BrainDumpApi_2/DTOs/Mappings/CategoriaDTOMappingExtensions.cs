using BrainDumpApi_2.Models;

namespace BrainDumpApi_2.DTOs.Mappings
{
    public static class CategoriaDTOMappingExtensions
    {
        public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
        {
            if (categoria is null)
                return null;

            return new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Cor = categoria.Cor
            };
        }

        public static Categoria? ToCategoria(this CategoriaDTO categoriaDto)
        {
            if (categoriaDto is null) return null;

            return new Categoria
            {
                Id = categoriaDto.Id,
                Nome = categoriaDto.Nome,
                Cor = categoriaDto.Cor
            };
        }

        public static IEnumerable<CategoriaDTO> ToCategoriaDTOList(this IEnumerable<Categoria> categorias)
        {
            if (categorias is null || !categorias.Any())
            {
                return new List<CategoriaDTO>();
            }

            return categorias.Select(categoria => new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Cor = categoria.Cor
            }).ToList();
        }
    }
}
