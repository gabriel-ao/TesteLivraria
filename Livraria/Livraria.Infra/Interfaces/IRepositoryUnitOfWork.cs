using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Interfaces
{
    public interface IRepositoryUnitOfWork
    {
        bool Commit();
    }
}
