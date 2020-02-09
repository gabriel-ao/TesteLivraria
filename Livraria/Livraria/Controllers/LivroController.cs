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
    public class LivroController : ControllerBase
    {
        public IServiceLivro _serviceLivro;

        public LivroController(IServiceLivro serviceLivro)
        {
            _serviceLivro = serviceLivro;
        }

        [HttpGet("BuscarLivro")]
        public Livro BuscarAutor(Guid id)
        {
            return _serviceLivro.GetLivroByIdService(id);
        }

        [HttpGet("BuscarTodosLivros")]
        public List<Livro> BuscarTodosUsuarios()
        {
            return _serviceLivro.GetAllLivrosByIdService();
        }

        [HttpPost("CadastrarLivro")]
        public string CadastrarLivro(Livro livro)
        {
            try
            {
                _serviceLivro.CadastrarLivroService(livro);
            }
            catch (LivrariaExceptions error)
            {

                Console.WriteLine(error);
            }
            return "Livro cadastrado com sucesso";
        }

        [HttpPost("AtivarLivro")]
        public string AtivarLivro(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceLivro.AtivarLivroService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }

        [HttpDelete("DesativarLivro")]
        public string DesativarLivro(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceLivro.DesativarLivroService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }

        [HttpDelete("DelecaoDefinitiva")]
        public string DeletarLivroDefinitivo(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceLivro.DeletarLivroService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }

        [HttpPut("EditarLivro")]
        public string EditarLivro(Livro livro)
        {
            try
            {
                _serviceLivro.EditarLivro(livro);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return "Livro editado com sucesso";
        }
    }
}