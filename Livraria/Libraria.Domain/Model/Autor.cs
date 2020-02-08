using Livraria.Domain.Model.Base;
using System.Collections.Generic;

namespace Livraria.Domain.Model
{
    public class Autor : CreateBase
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
