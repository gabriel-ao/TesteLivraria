using Livraria.Infra.Entities.Base;
using System;
using System.Collections.Generic;

namespace Livraria.Infra.Entities
{
    public class Livro : EntityComplexBase
    {
        public string NomeLivro { get; set; }

        // relacionamento com Autor
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }


        // relacionamento com exemplar
        public IList<Exemplar> Exemplares { get; set; }
    }
}
