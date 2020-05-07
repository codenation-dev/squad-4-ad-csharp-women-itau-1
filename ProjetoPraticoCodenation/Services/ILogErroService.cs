using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;

namespace ProjetoPraticoCodenation.Services
{
    public interface ILogErroService
    {
        LogErro FindById(int id);

        IEnumerable<LogErro> LocalizarPorNivelAmbiente(string nivel, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia);

        IList<LogErro> LocalizarPorAmbiente(string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia);

        IList<LogErro> LocalizarPorDescricaoAmbiente(string descricao, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia);

        IList<LogErro> LocalizarPorOrigemAmbiente(string origem, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia);

        IList<LogErro> LocalizarArquivados();

        void Remover(int id);

        void Arquivar(int id);

        void Desarquivar(int id);

        LogErro Salvar(LogErro log);
    }
}