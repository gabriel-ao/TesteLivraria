using AutoMapper;
using Livraria.Domain.Interfaces;
using Livraria.Infra.Context;
using Livraria.Infra.Entities;
using Livraria.Infra.Repositories.Base;

namespace Livraria.Infra.Repositories
{
    public class RepositoryLivro : RepositoryBase<Domain.Model.Livro, Livro>, IRepositoryLivro
    {
        #region Atributos

        private IMapper _mapper;

        #endregion

        #region Construtor

        public RepositoryLivro(LivrariaContext context) : base(context)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(MapperProfile));
            });
            _mapper = config.CreateMapper();
        }

        #endregion
    }
}

