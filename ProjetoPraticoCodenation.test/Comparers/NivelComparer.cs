using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPraticoCodenation.test
{
    internal class NivelComparer : IEqualityComparer<Nivel>
    {
        public bool Equals( Nivel x,  Nivel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode( Nivel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}