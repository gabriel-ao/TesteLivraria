using AutoMapper;
using Livraria.Domain.Interfaces;
using Livraria.Infra.Context;
using Livraria.Infra.Entities;
using Livraria.Infra.Repositories.Base;


namespace Livraria.Infra.Repositories
{
    public class RepositoryExemplar : RepositoryBase<Domain.Model.Exemplar, Exemplar>, IRepositoryExemplar
    {
        #region Atributos

        private IMapper _mapper;

        #endregion

        #region Construtor

        public RepositoryExemplar(LivrariaContext context) : base(context)
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
