using Livraria.Infra.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Entities
{
    public class Exemplar : Livro
    {
        public string NomeExemplar { get; set; }

        public int NumeroPaginas { get; set; }

    }
}
