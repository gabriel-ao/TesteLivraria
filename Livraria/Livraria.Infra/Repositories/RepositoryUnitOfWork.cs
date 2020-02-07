using Livraria.Domain.Interfaces;
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

        private RepositoryAutor repositoryAutor = null;

        private RepositoryLivro repositoryLivro = null;

        private RepositoryExemplar repositoryExemplar = null;

        private bool disposed = false;

        public RepositoryUnitOfWork(LivrariaContext context) : base(context)
        {
            _context = context;
        }

        public IRepositoryAutor Autor {
            get {
                if (repositoryAutor == null)
                {
                    repositoryAutor = new RepositoryAutor(_context);
                }
                return repositoryAutor;
            }
        }

        public IRepositoryLivro Livro {
            get {
                if (repositoryLivro == null)
                {
                    repositoryLivro = new RepositoryLivro(_context);
                }
                return repositoryLivro;
            }
        }

        public IRepositoryExemplar Exemplar {
            get {
                if (repositoryExemplar== null)
                {
                    repositoryExemplar = new RepositoryExemplar(_context);
                }
                return repositoryExemplar;
            }
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
