using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPraticoCodenation.test
{
    internal class LogErroComparer : IEqualityComparer<LogErro>
    {
        public bool Equals( LogErro x, LogErro y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(LogErro obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}