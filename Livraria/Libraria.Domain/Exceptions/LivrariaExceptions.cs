using System;

namespace Livraria.Domain.Exceptions
{
    public class LivrariaExceptions : Exception
    {
        public LivrariaExceptions()
        {

        }

        public LivrariaExceptions(string message) : base(message)
        {

        }

        public LivrariaExceptions(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
