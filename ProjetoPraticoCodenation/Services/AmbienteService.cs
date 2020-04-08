using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Services
{
    public class AmbienteService 
    {
        private ProjetoPraticoContext _context;
        public AmbienteService(ProjetoPraticoContext context)
        {
            _context = context;
        }

        public Ambiente FindById(int id)
        {
            return _context.Ambientes.Find(id);
        }

        public Ambiente Save(Ambiente ambiente)
        {
            var existe = _context.Ambientes           
                          .Where(x => x.Id == ambiente.Id)
                          .FirstOrDefault();

            if (existe == null)
                _context.Ambientes.Add(ambiente);
            else
            {
                existe.Descricao = ambiente.Descricao;
            }

            _context.SaveChanges();

            return ambiente;

        }
    }
}
