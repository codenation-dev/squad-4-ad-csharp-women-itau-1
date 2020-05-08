using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Data;
using Microsoft.EntityFrameworkCore.Internal;

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
        public IList<LogErro> LocalizarPorAmbiente(string ambiente)
        {
            return _context.Logs.Where(x => x.Ambiente == ambiente)
                                .Where(x => x.Arquivado == false)
                                .ToList();
        }
        public IList<LogErro> LocalizarPorNivelAmbiente(string nivel, string ambiente)
        {
            return _context.Logs.Where(x => x.Nivel == nivel)
                                .Where(x => x.Ambiente == ambiente)
                                .Where(x => x.Arquivado == false)
                                .ToList();
        }
        public IList<LogErro> LocalizarPorDescricaoAmbiente(string descricao, string ambiente)
        {
            return _context.Logs.Where(x => x.Descricao == descricao)
                                .Where(x => x.Ambiente == ambiente)
                                .Where(x => x.Arquivado == false)
                                .ToList();
        }
        public IList<LogErro> LocalizarPorOrigemAmbiente(string origem, string ambiente)
        {
            return _context.Logs.Where(x => x.Origem == origem)
                                .Where(x => x.Ambiente == ambiente)
                                .Where(x => x.Arquivado == false)
                                .ToList();
        }
        public IList<LogErro> OrdenarPorFrequencia(IList<LogErro> logErros)
        {
            var ordenacao = logErros.GroupBy(x => x.Nivel)
                                    .Select(group => new
                                    {
                                        Nivel = group.Key,
                                        Frequencia = group.Count()
                                    })
                                    .OrderByDescending(x => x.Frequencia)
                                    .ToList();

            var ordenacaoFrequencia = ordenacao.Select(x => x.Nivel).ToList();
            return logErros.OrderBy(x => ordenacaoFrequencia.IndexOf(x.Nivel)).ToList();
        }
        public IList<LogErro> OrdenarPorNivel(IList<LogErro> logErros)
        {
            return logErros.OrderBy(x => x.Nivel).ToList();
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
        public IList<LogErro> LocalizarArquivados()
        {
            return _context.Logs.Where(x => x.Arquivado == true)
                                    .ToList();
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
