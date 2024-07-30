namespace BrainDumpApi_2.Repositories
{
    public interface IUnitOfWork
    {
        INotaRepository NotaRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        Task Commit();
    }
}
