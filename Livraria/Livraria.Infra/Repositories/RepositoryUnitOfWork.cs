using Livraria.Infra.Context;
using Livraria.Infra.Entities;
using Livraria.Infra.Interfaces;
using Livraria.Infra.Repositories.Base;
using System;

namespace Livraria.Infra.Repositories
{
    public class RepositoryUnitOfWork : RepositoryBase<Domain.Model.UnitOfWork, UnitOfWork>, IRepositoryUnitOfWork
    {
        private readonly LivrariaContext _context;

        // exemplo
        //private RepositoryVeiculo repositoryVeiculo = null;

        private bool disposed = false;

        public RepositoryUnitOfWork(LivrariaContext context) : base(context)
        {
            _context = context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public new bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
