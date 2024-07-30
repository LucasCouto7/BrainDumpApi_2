using BrainDumpApi_2.Context;
using BrainDumpApi_2.Models;
using BrainDumpApi_2.Pagination;
using X.PagedList;

namespace BrainDumpApi_2.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(BrainDumpApiContext context) : base(context) { }

        public async Task<IPagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParameters)
        {
            var categorias = await GetAllAsync();

            var categoriasOrdenadas = categorias.OrderBy(c => c.Id).ToList();

            var resultado = await categoriasOrdenadas.ToPagedListAsync(categoriasParameters.PageNumber, categoriasParameters.PageSize);

            return resultado;
        }

        public async Task<IPagedList<Categoria>> GetCategoriasFiltroNomeAsync(
                                                    CategoriasFiltroNome categoriasParams)
        {
            var categorias = await GetAllAsync();

            if (!string.IsNullOrEmpty(categoriasParams.Nome))
            {
                categorias = categorias.Where(c => c.Nome.Contains(categoriasParams.Nome));
            }

            var categoriasFiltradas = await categorias.ToPagedListAsync(
                                                 categoriasParams.PageNumber,
                                                 categoriasParams.PageSize);

            return categoriasFiltradas;
        }
    }
}
