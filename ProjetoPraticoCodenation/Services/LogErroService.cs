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

        public IEnumerable<LogErro> LocalizarPorNivelAmbiente(string nivel, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia)
        {
            if (ordenarPorNivel)
            {
                return _context.Logs.Where(x => x.Nivel == nivel)
                                    .Where(x => x.Ambiente == ambiente)
                                    .OrderBy(x => x.Nivel)
                                    .ToList();
            }
            else
            {

                return _context.Logs.Where(x => x.Nivel == nivel)
                                    .Where(x => x.Ambiente == ambiente)
                                    .ToList();
            }

        }

        public IList<LogErro> LocalizarPorDescricaoAmbiente(string descricao, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia)
        {
            if (ordenarPorNivel)
            {
                return _context.Logs.Where(x => x.Descricao == descricao).
                                 Where(x => x.Ambiente == ambiente).
                                 Distinct().
                                 OrderBy(x => x.Nivel).
                                 ToList();
            }
            else
            {
                return _context.Logs.Where(x => x.Descricao == descricao).
                  Where(x => x.Ambiente == ambiente).
                  Distinct().
                  ToList();
            }
        }

        public IList<LogErro> LocalizarPorOrigemAmbiente(string origem, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia)
        {
            if (ordenarPorNivel)
            {
                return _context.Logs.Where(x => x.Origem == origem)
                            .Where(x => x.Ambiente == ambiente)
                            .OrderBy(x => x.Nivel)
                            .ToList();
            }
            else
            {
                return _context.Logs.Where(x => x.Origem == origem)
                     .Where(x => x.Ambiente == ambiente)
                     .ToList();

            }
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


        public void Arquivar(int id)
        {
            var logerroExistente = FindById(id);

            if (logerroExistente != null)
            {
                logerroExistente.Arquivado = true;
                _context.SaveChanges();
            }
        }


        public void Desarquivar(int id)
        {
            var logerroExistente = FindById(id);

            if (logerroExistente != null)
            {
                logerroExistente.Arquivado = false;
                _context.SaveChanges();
            }
        }


        public LogErro Salvar(LogErro log)
        {
            var logerroExistente = _context.Logs
                          .Where(x => x.Id == log.Id)
                          .FirstOrDefault();

            if (logerroExistente == null)
                _context.Logs.Add(log);
            else
            {
                logerroExistente.Titulo = log.Titulo;
                logerroExistente.Descricao = log.Descricao;
                logerroExistente.Nivel = log.Nivel;
                logerroExistente.UsuarioOrigem = log.UsuarioOrigem;
                logerroExistente.Evento = log.Evento;
                logerroExistente.Origem = log.Origem;
                logerroExistente.Arquivado = log.Arquivado;
                logerroExistente.Ambiente = log.Ambiente;
                logerroExistente.DataCriacao = log.DataCriacao;
            }

            _context.SaveChanges();

            return log;
        }
    }
}
