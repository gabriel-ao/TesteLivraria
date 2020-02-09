using Livraria.Domain.Exceptions;
using Livraria.Domain.Model;
using Livraria.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemplarController : ControllerBase
    {
        public IServiceExemplar _serviceExemplar;

        public ExemplarController(IServiceExemplar serviceExemplar)
        {
            _serviceExemplar = serviceExemplar;
        }

        [HttpGet("BuscarExemplar")]
        public Exemplar BuscarExemplar(Guid id)
        {
            return _serviceExemplar.GetExemplarByIdService(id);
        }

        [HttpGet("BuscarTodosExemplar")]
        public List<Exemplar> BuscarTodosLivros()
        {
            return _serviceExemplar.GetAllExemplaresByIdService();
        }

        [HttpPost("CadastrarExemplar")]
        public string CadastrarLivro(Exemplar exemplar)
        {
            var dados = "";
            try
            {
                dados = _serviceExemplar.CadastrarExemplarService(exemplar);
            }
            catch (LivrariaExceptions error)
            {

                Console.WriteLine(error);
            }
            return dados;
        }

        [HttpPost("AtivarExemplar")]
        public string AtivarLivro(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceExemplar.AtivarExemplarService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }

        [HttpDelete("DesativarExemplar")]
        public string DesativarLivro(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceExemplar.DesativarExemplarService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }

        [HttpDelete("DelecaoDefinitiva")]
        public string DeletarExemplarDefinitivo(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceExemplar.DeletarExemplarService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }

        [HttpPut("EditarLivro")]
        public string EditarExemplar(Exemplar exemplar)
        {
            try
            {
                _serviceExemplar.EditarExemplar(exemplar);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return "Livro editado com sucesso";
        }
    }
}