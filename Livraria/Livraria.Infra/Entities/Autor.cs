using Livraria.Infra.Entities.Base;
using System.Collections.Generic;

namespace Livraria.Infra.Entities
{
    public class Autor : EntityComplexBase
    {
        public Autor()
        {
            this.Livros = new List<Livro>();
        }

        public string NomeAutor { get; set; }

        //relacionamento com livros
        public IList<Livro> Livros { get; set; }
    }
}
