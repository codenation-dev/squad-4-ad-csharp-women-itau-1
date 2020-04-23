using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Services
{
    public class LogErroService
    {
        private ProjetoPraticoContext _context;
        public LogErroService(ProjetoPraticoContext context)
        {
            _context = context;
        }

        public LogErro FindById(int id)
        {
            return _context.Logs.Find(id);
        }

        public LogErro Save(LogErro log)
        {
            var existe = _context.Logs
                          .Where(x => x.Id == log.Id)
                          .FirstOrDefault();

            if (existe == null)
                _context.Logs.Add(log);
            else
            {
                existe.Titulo = log.Titulo;
                existe.Descricao = log.Descricao;
                existe.Nivel = log.Nivel;
                existe.UsuarioId = log.UsuarioId;
                existe.EventoId = log.EventoId;
                existe.Ambiente = log.Ambiente;
                existe.DataCriacao = log.DataCriacao;
            }

            _context.SaveChanges();

            return log;
        }
    }
}
