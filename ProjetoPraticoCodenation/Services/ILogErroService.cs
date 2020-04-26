using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;

namespace ProjetoPraticoCodenation.Services
{
    public interface ILogErroService
    {
        LogErro FindById(int id);

        IEnumerable<LogErro> LocalizarPorNivelAmbiente(string nivel, string ambiente);

        void Remover(int id);

        LogErro Save(LogErro log);
    }
}