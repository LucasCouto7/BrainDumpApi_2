using BrainDumpApi_2.Context;
using BrainDumpApi_2.Models;
using BrainDumpApi_2.Pagination;
using X.PagedList;

namespace BrainDumpApi_2.Repositories
{
    public class NotaRepository : Repository<Nota>, INotaRepository
    {
        public NotaRepository(BrainDumpApiContext context) : base(context) { }
        public async Task<IPagedList<Nota>> GetNotasAsync(NotasParameters notasParams)
        {
            var notas = await GetAllAsync();

            var notasOrdenados = notas.OrderBy(n => n.Id).AsQueryable();

            var resultado = await notasOrdenados.ToPagedListAsync(notasParams.PageNumber, notasParams.PageSize);

            return resultado;
        }
        public async Task<IEnumerable<Nota>> GetNotasPorCategoriaAsync(int id)
        {
            var notas = await GetAllAsync();
            var notasCategoria = notas.Where(c => c.Id == id);
            return notasCategoria;
        }

    }
}
