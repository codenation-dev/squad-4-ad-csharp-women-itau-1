using ProjetoPraticoCodenation.Models;
using System.Collections.Generic;

namespace ProjetoPraticoCodenation.Services
{
    public interface IUsuarioService
    {
        Usuario FindById(int id);

        IList<Usuario> FindByName(string nome);
        Usuario Save(Usuario usuario);
    }
}