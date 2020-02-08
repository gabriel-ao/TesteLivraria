using Livraria.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Service.Interfaces
{
    public interface IServiceAutor
    {
        // Create 
        string CadastrarAutorService(Autor autor);

        // Read
        Autor GetAutorByIdService(Guid Id);
        List<Autor> GetAllAutorByIdService();

        // Update
        Autor EditarAutor(Autor autor);
        string AtivarAutorService(Guid id);

        // Delete
        string DesativarAutorService(Guid id);
        string DeletarAutorService(Guid id);

    }
}
