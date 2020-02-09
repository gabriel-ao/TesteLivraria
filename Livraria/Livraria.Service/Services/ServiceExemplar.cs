using AutoMapper;
using Livraria.Domain.Model;
using Livraria.Infra;
using Livraria.Infra.Interfaces;
using Livraria.Infra.Libraries.Lang;
using Livraria.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Livraria.Service.Services
{
    public class ServiceExemplar : IServiceExemplar
    {
        #region Atributos

        private readonly IMapper _mapper;
        private readonly IRepositoryUnitOfWork _unitOfWork;

        #endregion


        #region Construtor

        public ServiceExemplar(IRepositoryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(MapperProfile));
            });
            _mapper = config.CreateMapper();
        }

        #endregion
        public string AtivarExemplarService(Guid id)
        {
            var desativarLivro = GetExemplarByIdService(id);

            if (desativarLivro.Active != true)
            {
                desativarLivro.Active = true;

                _unitOfWork.Exemplar.Update(desativarLivro);
                _unitOfWork.Commit();
                return Message.MSG_S002;
            }

            return Message.MSG_S003;
        }

        public string CadastrarExemplarService(Exemplar exemplar)
        {
            var cadastrar = GetAllExemplaresByIdService();

            bool VerificandoLivro = false;

            foreach (var vericicandoCadastro in cadastrar)
            {
                if (vericicandoCadastro.NomeExemplar == exemplar.NomeExemplar && 
                    vericicandoCadastro.LivroId == exemplar.LivroId &&
                    vericicandoCadastro.NumeroVersao == exemplar.NumeroVersao)
                {
                    VerificandoLivro = true;
                }
            }

            if (VerificandoLivro == false)
            {
                _unitOfWork.Exemplar.Add(exemplar);
                _unitOfWork.Commit();
                return Message.MSG_S001;
            }
            return Message.MSG_S004;
        }

        public string DeletarExemplarService(Guid id)
        {
            var deletarLivro = GetExemplarByIdService(id);

            if (deletarLivro.Id != null)
            {
                _unitOfWork.Exemplar.Delete(deletarLivro);
                _unitOfWork.Commit();
                return Message.MSG_D001;
            }
            return Message.MSG_D002;
        }

        public string DesativarExemplarService(Guid id)
        {
            var desativarExemplar = GetExemplarByIdService(id);

            if (desativarExemplar.Active != false)
            {
                desativarExemplar.Active = false;

                _unitOfWork.Exemplar.Update(desativarExemplar);
                _unitOfWork.Commit();
                return Message.MSG_D001;
            }

            return Message.MSG_D003;
        }


        public Exemplar EditarExemplar(Exemplar exemplar)
        {
            var editLivro = GetExemplarByIdService(exemplar.Id);

            if (editLivro != null)
            {
                _unitOfWork.Exemplar.Update(exemplar);
                _unitOfWork.Commit();
            }

            return exemplar;
        }

        public List<Exemplar> GetAllExemplaresByIdService()
        {
            List<Exemplar> livro = new List<Exemplar>();

            livro = _unitOfWork.Exemplar.List();

            if (livro == null)
            {
                throw new Exception("Exemplar invalido");
            }

            return livro;
        }

        public Exemplar GetExemplarByIdService(Guid Id)
        {
            var Exemplar = _unitOfWork.Exemplar.Query(l => l.Id == Id);

            if (Exemplar == null)
            {
                throw new Exception("Exemplar invalido");
            }

            return Exemplar;
        }
    }
}
