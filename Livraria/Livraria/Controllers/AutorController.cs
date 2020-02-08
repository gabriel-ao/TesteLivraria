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
    public class AutorController : ControllerBase
    {
        public IServiceAutor _serviceAutor;

        public AutorController(IServiceAutor serviceAutor)
        {
            _serviceAutor = serviceAutor;
        }

        [HttpGet("BuscarAutor")]
        public Autor BuscarAutor(Guid id)
        {
            return _serviceAutor.GetAutorByIdService(id);
        }

        [HttpGet("BuscarTodosAutores")]
        public List<Autor> BuscarTodosUsuarios()
        {
            return _serviceAutor.GetAllAutorByIdService();
        }

        [HttpPost("CadastrarAutor")]
        public string CadastrarAutor(Autor autor)
        {
            try
            {
                _serviceAutor.CadastrarAutorService(autor);
            }
            catch (LivrariaExceptions error)
            {

                Console.WriteLine(error);
            }
            return "Autor cadastrado com sucesso";
        }

        [HttpPut("EditarAutor")]
        public string EditarAutor(Autor user)
        {
            try
            {
                _serviceAutor.EditarAutor(user);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return "Autor editado com sucesso";
        }


        [HttpDelete("DesativarAutor")]
        public string DesativarAutor(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceAutor.DesativarAutorService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }

        [HttpPost("AtivarAutor")]
        public string AtivarAutor(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceAutor.AtivarAutorService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }


        [HttpDelete("DelecaoDefinitiva")]
        public string DeletarAutorDefinitivo(Guid id)
        {
            string retorno = "";
            try
            {
                retorno = _serviceAutor.DeletarAutorService(id);
            }
            catch (LivrariaExceptions error)
            {
                Console.WriteLine(error);
            }

            return retorno;
        }

    }
}