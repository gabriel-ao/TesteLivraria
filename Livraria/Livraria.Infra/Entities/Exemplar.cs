using Livraria.Infra.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Entities
{
    public class Exemplar : EntityComplexBase
    {
        public string NomeExemplar { get; set; }

        public int NumeroPaginas { get; set; }

        //relacionamento com livro
        public Guid LivroId { get; set; }
        public Livro Livro { get; set; }

    }
}
