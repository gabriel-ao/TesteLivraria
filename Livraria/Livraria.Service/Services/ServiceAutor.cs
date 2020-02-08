using AutoMapper;
using Livraria.Domain.Model;
using Livraria.Infra;
using Livraria.Infra.Interfaces;
using Livraria.Infra.Libraries.Lang;
using Livraria.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Service.Services
{
    public class ServiceAutor : IServiceAutor
    {
        #region Atributos

        private readonly IMapper _mapper;
        private readonly IRepositoryUnitOfWork _unitOfWork;

        #endregion


        #region Construtor

        public ServiceAutor(IRepositoryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(MapperProfile));
            });
            _mapper = config.CreateMapper();
        }

        #endregion

        public string AtivarAutorService(Guid id)
        {
            throw new NotImplementedException();
        }

        public string CadastrarAutorService(Autor autor)
        {
            _unitOfWork.Commit();
            return Message.MSG_S001;
        }

        public string DeletarAutorService(Guid id)
        {
            throw new NotImplementedException();
        }

        public string DesativarAutorService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Autor EditarUsuario(Autor autor)
        {
            throw new NotImplementedException();
        }

        public List<Autor> GetAllAutorByIdService()
        {
            throw new NotImplementedException();
        }

        public IServiceAutor GetAutorByIdService(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
