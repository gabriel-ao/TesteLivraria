using Livraria.Domain.Model.Base;
using System;

namespace Livraria.Domain.Model
{
    public class Exemplar : CreateBase
    {
        public string NomeExemplar { get; set; }
        public int NumeroPaginas { get; set; }


        //relacionamento com livro
        public Guid LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}
