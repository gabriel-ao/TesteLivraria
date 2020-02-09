using AutoMapper;
using Livraria.Domain.Model;
using Livraria.Infra;
using Livraria.Infra.Interfaces;
using Livraria.Infra.Libraries.Lang;
using Livraria.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Service.Services
{
    public class ServiceLivro : IServiceLivro
    {
        #region Atributos

        private readonly IMapper _mapper;
        private readonly IRepositoryUnitOfWork _unitOfWork;

        #endregion


        #region Construtor

        public ServiceLivro(IRepositoryUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(MapperProfile));
            });
            _mapper = config.CreateMapper();
        }
        
        #endregion

        public string AtivarLivroService(Guid id)
        {
            var desativarLivro = GetLivroByIdService(id);

            if (desativarLivro.Active != true)
            {
                desativarLivro.Active = true;

                _unitOfWork.Livro.Update(desativarLivro);
                _unitOfWork.Commit();
                return Message.MSG_S002;
            }

            return Message.MSG_S003;
        }

        public string CadastrarLivroService(Livro livro)
        {
            var cadastrar = GetAllLivrosByIdService();

            bool VerificandoLivro = false;

            foreach (var vericicandoCadastro in cadastrar)
            {
                if(vericicandoCadastro.NomeLivro == livro.NomeLivro && vericicandoCadastro.AutorId == livro.AutorId)
                {
                    VerificandoLivro = true;
                }
            }

            if(VerificandoLivro == false)
            {
                _unitOfWork.Livro.Add(livro);
                _unitOfWork.Commit();
                return Message.MSG_S001;
            }
            return Message.MSG_S004;
        }



        public string DeletarLivroService(Guid id)
        {
            var deletarLivro = GetLivroByIdService(id);

            if (deletarLivro.Id != null)
            {
                _unitOfWork.Livro.Delete(deletarLivro);
                _unitOfWork.Commit();
                return Message.MSG_D001;
            }
            return Message.MSG_D002;
        }

        public string DesativarLivroService(Guid id)
        {
            var desativarLivro = GetLivroByIdService(id);

            if (desativarLivro.Active != false)
            {
                desativarLivro.Active = false;

                _unitOfWork.Livro.Update(desativarLivro);
                _unitOfWork.Commit();
                return Message.MSG_D001;
            }

            return Message.MSG_D003;
        }

        public Livro EditarLivro(Livro livro)
        {
            var editLivro = GetLivroByIdService(livro.Id);

            if (editLivro != null)
            {
                _unitOfWork.Livro.Update(livro);
                _unitOfWork.Commit();
            }

            return livro;
        }

        public List<Livro> GetAllLivrosByIdService()
        {
            List<Livro> livro = new List<Livro>();

            livro = _unitOfWork.Livro.List().OrderBy(x => x.NomeLivro).ToList();

            if (livro == null)
            {
                throw new Exception("Livro invalido");
            }

            //Comparison<Livro> comp = (l1, l2) => l1.NomeLivro.CompareTo(l2.NomeLivro);
            //return livro.Sort(comp);
            return livro;
        }


        public Livro GetLivroByIdService(Guid Id)
        {
            var livro = _unitOfWork.Livro.Query(l => l.Id == Id);

            if (livro == null)
            {
                throw new Exception("Livro invalido");
            }

            return livro;
        }

    }
}
