using ProjetoPraticoCodenation.Models;

namespace ProjetoPraticoCodenation.Services
{
    public interface ILogErroService
    {
        LogErro FindById(int id);
        LogErro Save(LogErro log);
    }
}