using Livraria.Domain.Model;
using System;
using System.Collections.Generic;

namespace Livraria.Service.Interfaces
{
    public interface IServiceLivro
    {
        // Create 
        string CadastrarLivroService(Livro livro);

        // Read
        Livro GetLivroByIdService(Guid Id);
        List<Livro> GetAllLivrosByIdService();

        // Update
        Livro EditarLivro(Livro livro);
        string AtivarLivroService(Guid id);

        // Delete
        string DesativarLivroService(Guid id);
        string DeletarLivroService(Guid id);
    }
}
