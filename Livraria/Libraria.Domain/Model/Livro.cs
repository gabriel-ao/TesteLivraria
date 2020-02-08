using Livraria.Domain.Model.Base;
using System;
using System.Collections.Generic;

namespace Livraria.Domain.Model
{
    public class Livro : CreateBase
    {
        public string NomeLivro { get; set; }

        // relacionamento com Autor
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }


        // relacionamento com exemplar
        public IList<Exemplar> Exemplares { get; set; }
    }
}
