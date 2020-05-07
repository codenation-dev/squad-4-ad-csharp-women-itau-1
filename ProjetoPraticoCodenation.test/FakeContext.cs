using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using ProjetoPraticoCodenation.Data;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.test
{
    /// Fake Data
    /// powered by https://mockaroo.com/
    ///
    public class FakeContext
    {
        public DbContextOptions<ProjetoPraticoContext> FakeOptions { get; }
        public IMapper Mapper { get; }

        private Dictionary<Type, string> DataFileNames { get; } =
            new Dictionary<Type, string>();
        private string FileName<T>() { return DataFileNames[typeof(T)]; }

        public FakeContext(string testName)
        {
            FakeOptions = new DbContextOptionsBuilder<ProjetoPraticoContext>()
                .UseInMemoryDatabase(databaseName: $"ProjetoPratico_{testName}")
                .Options;

            DataFileNames.Add(typeof(LogErro), $"FakeData{Path.DirectorySeparatorChar}logerro.json");
            DataFileNames.Add(typeof(LogErroDTO), $"FakeData{Path.DirectorySeparatorChar}logerro.json");

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LogErro, LogErroDTO>().ReverseMap();
            });

            this.Mapper = configuration.CreateMapper();
        }

        public void FillWithAll()
        {
            FillWith<LogErro>();
        }

        public void FillWith<T>() where T : class
        {
            using (var context = new ProjetoPraticoContext(FakeOptions))
            {
                if (context.Set<T>().Count() == 0)
                {
                    foreach (T item in GetFakeData<T>())
                        context.Set<T>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        public List<T> GetFakeData<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public List<T> Get<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public Mock<ILogErroService> FakeLogErroService()
        {
            var service = new Mock<ILogErroService>();

            service.Setup(x => x.Salvar(It.IsAny<LogErro>()))
                .Returns((LogErro log) =>
                {
                    if (log.Id == 0)
                        log.Id = 999;

                    return log;
                });


            service.Setup(x => x.FindById(It.IsAny<int>())).
                Returns((int id) => Get<LogErro>().FirstOrDefault(x => x.Id == id));


            service.Setup(x => x.LocalizarPorAmbiente(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns((string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia) =>
                {
                    var logs = Get<LogErro>();
                    return logs
                     .Where(l => l.Ambiente == ambiente)
                     .Where(l => l.Arquivado == false)
                     .OrderBy(l => l.Nivel)
                     .ToList();
                });


            service.Setup(x => x.LocalizarPorNivelAmbiente(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns((string nivel, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia) =>
                {
                    var logs = Get<LogErro>();
                    return logs
                     .Where(l => l.Nivel == nivel)
                     .Where(l => l.Ambiente == ambiente)
                     .Where(l => l.Arquivado == false)
                     .OrderBy(l => l.Nivel)
                     .ToList();
                });


            service.Setup(x => x.LocalizarPorDescricaoAmbiente(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns((string descricao, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia) =>
                {
                    var logs = Get<LogErro>();
                    var lista = logs
                     .Where(l => l.Descricao == descricao)
                     .Where(l => l.Ambiente == ambiente)
                     .Where(l => l.Arquivado == false)
                     .OrderBy(l => l.Nivel)
                     .ToList();

                    return lista;
                });

            service.Setup(x => x.LocalizarPorOrigemAmbiente(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns((string origem, string ambiente, bool ordenarPorNivel, bool ordenarPorFrequencia) =>
                {
                    var logs = Get<LogErro>();
                    var lista = logs
                     .Where(l => l.Origem == origem)
                     .Where(l => l.Ambiente == ambiente)
                     .Where(l => l.Arquivado == false)
                     .OrderBy(l => l.Nivel)
                     .ToList();

                    return lista;
                });

            service.Setup(x => x.LocalizarArquivados()).
                Returns(() => {
                    var logs = Get<LogErro>();
                    var lista = logs
                     .Where(l => l.Arquivado == true)
                     .ToList();

                    return lista;
                });

            return service;
        }



    }
}
