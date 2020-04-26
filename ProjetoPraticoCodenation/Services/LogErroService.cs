using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoPraticoCodenation.Services
{
    public class LogErroService : ILogErroService
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

        public IEnumerable<LogErro> LocalizarPorNivelAmbiente(string nivel, string ambiente)
        {
            return _context.Logs.Where(x => x.Nivel == nivel)
                                .Where(x => x.Ambiente == ambiente)
                                .ToList();
        }

         public IList<LogErro> LocalizarPorNivelAmbiente(string descricao, string ambiente)
        {
            return _context.Logs.Where(x => x.Descricao == descricao).
                                 Where(x => x.Ambiente == ambiente).
                                 Distinct().
                                 ToList();
        }


        public void Remover(int id)
        {
            var existe = FindById(id);

            if (existe != null)
            {
                _context.Logs.Remove(existe);
                _context.SaveChanges();
            }
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
                existe.UsuarioOrigem = log.UsuarioOrigem;
                existe.Evento = log.Evento;
                existe.IPOrigem = log.IPOrigem;
                existe.Arquivado = log.Arquivado;
                existe.Ambiente = log.Ambiente;
                existe.DataCriacao = log.DataCriacao;
            }

            _context.SaveChanges();

            return log;
        }
    }
}
