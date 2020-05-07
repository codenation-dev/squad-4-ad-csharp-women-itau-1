using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;

namespace ProjetoPraticoCodenation.Services
{
    public interface ILogErroService
    {
        LogErro FindById(int id);

        IEnumerable<LogErro> LocalizarPorNivelAmbiente(string nivel, string ambiente);

        IList<LogErro> LocalizarPorAmbiente(string ambiente);

        IList<LogErro> LocalizarPorDescricaoAmbiente(string descricao, string ambiente);

        IList<LogErro> LocalizarPorOrigemAmbiente(string origem, string ambiente);

        IList<LogErro> LocalizarArquivados();
        
        IList<LogErro> OrdenarPorFrequencia(IList<LogErro> logErros);

        IList<LogErro> OrdenarPorNivel(IList<LogErro> logErros);

        void Remover(int id);

        void Arquivar(int id);

        void Desarquivar(int id);

        LogErro Salvar(LogErro log);
        IEnumerable<LogErro> OrdenarPorNivel(IEnumerable<LogErro> listaLogErro);
        IEnumerable<LogErro> OrdenarPorFrequencia(IEnumerable<LogErro> listaLogErro);
    }
}