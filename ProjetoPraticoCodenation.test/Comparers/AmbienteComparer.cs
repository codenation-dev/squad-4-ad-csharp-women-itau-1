using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPraticoCodenation.test
{
    internal class AmbienteComparer : IEqualityComparer<Ambiente>
    {
        public bool Equals( Ambiente x,  Ambiente y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode( Ambiente obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}