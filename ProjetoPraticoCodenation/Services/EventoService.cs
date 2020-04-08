using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Services
{
    public class EventoService
    {
        private ProjetoPraticoContext _context;
        public EventoService(ProjetoPraticoContext context)
        {
            _context = context;
        }

        public Evento FindById(int id)
        {
            return _context.Eventos.Find(id);
        }

        public Evento Save(Evento evento)
        {
            var existe = _context.Eventos
                          .Where(x => x.Id == evento.Id)
                          .FirstOrDefault();

            if (existe == null)
                _context.Eventos.Add(evento);
            else
            {
                existe.Descricao = evento.Descricao;
                existe.Codigo = evento.Codigo;
            }

            _context.SaveChanges();

            return evento;

        }
    }
}
