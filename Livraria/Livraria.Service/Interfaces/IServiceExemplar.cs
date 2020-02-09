using Livraria.Domain.Model;
using System;
using System.Collections.Generic;

namespace Livraria.Service.Interfaces
{
    public interface IServiceExemplar
    {
        // Create 
        string CadastrarExemplarService(Exemplar exemplar);

        // Read
        Exemplar GetExemplarByIdService(Guid Id);
        List<Exemplar> GetAllExemplaresByIdService();

        // Update
        Exemplar EditarExemplar(Exemplar exemplar);
        string AtivarExemplarService(Guid id);

        // Delete
        string DesativarExemplarService(Guid id);
        string DeletarExemplarService(Guid id);
    }
}
