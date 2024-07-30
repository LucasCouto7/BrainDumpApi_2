using BrainDumpApi_2.Models;
using BrainDumpApi_2.Pagination;
using X.PagedList;


namespace BrainDumpApi_2.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IPagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParams);
        Task<IPagedList<Categoria>> GetCategoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams);
    }
}
