using Livraria.Domain.Exceptions;
using Livraria.Domain.Model;
using Livraria.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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
            return "usuario cadastrado com sucesso";
        }
    }
}