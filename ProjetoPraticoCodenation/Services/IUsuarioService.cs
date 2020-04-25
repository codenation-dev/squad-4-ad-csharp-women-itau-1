using ProjetoPraticoCodenation.Models;

namespace ProjetoPraticoCodenation.Services
{
    public interface IUsuarioService
    {
        Usuario FindById(int id);
        Usuario Save(Usuario usuario);
    }
}