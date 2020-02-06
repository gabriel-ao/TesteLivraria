using System;
using System;

namespace Livraria.Domain.Extensions
{

    public class ExceptionExtension
    {
        public static string PrepareExceptionString(Exception ex)
        {

            var exceptionMessage = $"{ex.Message}\r\n\t{ex}\r\n---------------------------\r\n";

            if (ex.InnerException != null)
                exceptionMessage += $"\t{PrepareExceptionString(ex.InnerException)}";

            return exceptionMessage;

        }
    }

}
