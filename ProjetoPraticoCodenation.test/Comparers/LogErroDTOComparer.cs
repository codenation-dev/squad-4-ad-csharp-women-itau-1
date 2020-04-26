using ProjetoPraticoCodenation.DTOs;
using System.Collections.Generic;

namespace ProjetoPraticoCodenation.test.Model
{
    internal class LogErroDTOComparer : IEqualityComparer<LogErroDTO>
    {
        public bool Equals(LogErroDTO x, LogErroDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(LogErroDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}