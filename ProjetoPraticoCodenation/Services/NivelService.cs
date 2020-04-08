using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Services
{
    public class NivelService
    {
        private ProjetoPraticoContext _context;
        public NivelService(ProjetoPraticoContext context)
        {
            _context = context;
        }

        public Nivel FindById(int id)
        {
            return _context.Niveis.Find(id);
        }

        public Nivel Save(Nivel nivel)
        {
            var existe = _context.Niveis
                          .Where(x => x.Id == nivel.Id)
                          .FirstOrDefault();

            if (existe == null)
                _context.Niveis.Add(nivel);
            else
            {
                existe.Codigo = nivel.Codigo;
                existe.Descricao = nivel.Descricao;
            }

            _context.SaveChanges();

            return nivel;

        }
    }
}
