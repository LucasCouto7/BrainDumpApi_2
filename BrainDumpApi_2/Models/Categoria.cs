namespace BrainDumpApi_2.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Cor { get; set; }

        public ICollection<Nota> Notas { get; } = new List<Nota>();
    }
}
