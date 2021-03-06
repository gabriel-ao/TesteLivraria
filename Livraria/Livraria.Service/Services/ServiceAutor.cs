﻿using AutoMapper;
using Livraria.Domain.Model;
using Livraria.Infra;
using Livraria.Infra.Interfaces;
using Livraria.Infra.Libraries.Lang;
using Livraria.Service.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

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
            var desativarAutor = GetAutorByIdService(id);

            if (desativarAutor.Active != true)
            {
                desativarAutor.Active = true;

                _unitOfWork.Autor.Update(desativarAutor);
                _unitOfWork.Commit();
                return Message.MSG_S002;
            }

            return Message.MSG_D003;
        }

        public string CadastrarAutorService(Autor autor)
        {
            var cadastrar = GetAllAutorByIdService();

            bool VerificandoLivro = false;

            foreach (var vericicandoCadastro in cadastrar)
            {
                if (vericicandoCadastro.NomeAutor == autor.NomeAutor)
                {
                    VerificandoLivro = true;
                }
            }

            if (VerificandoLivro == false)
            {
                _unitOfWork.Autor.Add(autor);
                _unitOfWork.Commit();
                return Message.MSG_S001;
            }
            return Message.MSG_S004;
        }

        public string DeletarAutorService(Guid id)
        {
            var deletarAutor = GetAutorByIdService(id);

            if (deletarAutor.Id != null)
            {
                _unitOfWork.Autor.Delete(deletarAutor);
                _unitOfWork.Commit();
                return Message.MSG_D001;
            }
            return Message.MSG_D002;
        }

        public string DesativarAutorService(Guid id)
        {
            var desativarAutor = GetAutorByIdService(id);

            if (desativarAutor.Active != false)
            {
                desativarAutor.Active = false;

                _unitOfWork.Autor.Update(desativarAutor);
                _unitOfWork.Commit();
                return Message.MSG_S002;
            }

            return Message.MSG_D003;
        }

        public Autor EditarAutor(Autor autor)
        {
            var editAutor = GetAutorByIdService(autor.Id);

            if (editAutor != null)
            {
                _unitOfWork.Autor.Update(autor);
                _unitOfWork.Commit();
            }

            return autor;
        }

        public List<Autor> GetAllAutorByIdService()
        {
            List<Autor> autor = new List<Autor>();

            autor = _unitOfWork.Autor.List().OrderBy(x => x.NomeAutor).ToList();


            if (autor == null)
            {
                throw new Exception("Usuario invalido");
            }

            return autor;
        }

        public Autor GetAutorByIdService(Guid Id)
        {
            var autor = _unitOfWork.Autor.Query(a => a.Id == Id);

            if (autor == null)
            {
                throw new Exception("Usuario invalido");
            }

            return autor;
        }
    }
}
