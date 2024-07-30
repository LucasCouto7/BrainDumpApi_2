using BrainDumpApi_2.Models;
using BrainDumpApi_2.Pagination;
using X.PagedList;

namespace BrainDumpApi_2.Repositories
{
    public interface INotaRepository : IRepository<Nota>
    {
        Task<IPagedList<Nota>> GetNotasAsync(NotasParameters notasParams);
        Task<IEnumerable<Nota>> GetNotasPorCategoriaAsync(int id);
    }
}
