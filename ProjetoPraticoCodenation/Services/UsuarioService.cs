using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Services
{
    public class UsuarioService : IUsuarioService
    {
        private ProjetoPraticoContext _context;
        public UsuarioService(ProjetoPraticoContext context)
        {
            _context = context;
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario Save(Usuario usuario)
        {
            var existe = _context.Usuarios
                          .Where(x => x.Id == usuario.Id)
                          .FirstOrDefault();

            if (existe == null)
                _context.Usuarios.Add(usuario);
            else
            {
                existe.Nome = usuario.Nome;
                existe.Login = usuario.Login;
                existe.Senha = usuario.Senha;
                existe.Token = usuario.Token;
            }

            _context.SaveChanges();

            return usuario;

        }
    }
}
