using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;

namespace ProjetoPraticoCodenation.Services
{
    public interface ILogErroService
    {
        LogErro FindById(int id);

        IEnumerable<LogErro> LocalizarPorNivelAmbiente(string nivel, string ambiente);

        IList<LogErro> LocalizarPorDescricaoAmbiente(string descricao, string ambiente);

        IList<LogErro> LocalizarPorOrigemAmbiente(string origem, string ambiente);

        void Remover(int id);

        LogErro Salvar(LogErro log);
    }
}