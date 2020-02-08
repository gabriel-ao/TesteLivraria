using Livraria.Domain.Interfaces;

namespace Livraria.Infra.Interfaces
{
    public interface IRepositoryUnitOfWork
    {
        IRepositoryAutor Autor { get; }
        IRepositoryLivro Livro { get; }
        IRepositoryExemplar Exemplar { get; }
        bool Commit();
    }
}
