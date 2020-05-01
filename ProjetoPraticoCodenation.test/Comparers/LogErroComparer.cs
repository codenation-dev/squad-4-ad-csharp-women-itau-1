using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPraticoCodenation.test
{
    internal class LogErroComparer : IEqualityComparer<LogErro>
    {
        public bool Equals( LogErro x, LogErro y)
        {
            return x.Id == y.Id 
                && x.Nivel == y.Nivel
                && x.Ambiente == y.Ambiente
                && x.Descricao == y.Descricao
                && x.Titulo == y.Titulo
                && x.Arquivado == y.Arquivado
                && x.Origem == y.Origem
                && x.UsuarioOrigem == y.UsuarioOrigem
                && x.DataCriacao == y.DataCriacao
                ;
        }

        public int GetHashCode(LogErro obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}