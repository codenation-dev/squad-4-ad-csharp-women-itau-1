using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPraticoCodenation.test
{
    internal class EventoComparer : IEqualityComparer<Evento>
    {
        public bool Equals( Evento x,  Evento y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode( Evento obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}