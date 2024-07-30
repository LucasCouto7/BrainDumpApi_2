using BrainDumpApi_2.Context;

namespace BrainDumpApi_2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private INotaRepository? _notaRepo;
        private ICategoriaRepository? _categoriaRepo;

        public BrainDumpApiContext _context;

        public UnitOfWork(BrainDumpApiContext context)
        {
            _context = context;
        }
        public INotaRepository NotaRepository
        {
            get
            {
               return _notaRepo = _notaRepo ?? new NotaRepository(_context);
            }

        }
        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
            }

        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
