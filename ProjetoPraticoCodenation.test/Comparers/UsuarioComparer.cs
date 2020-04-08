using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPraticoCodenation.test
{
    internal class UsuarioComparer : IEqualityComparer<Usuario>
    {
        public bool Equals( Usuario x,  Usuario y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode( Usuario obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}