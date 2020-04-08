using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjetoPraticoCodenation.Models;

namespace ProjetoPraticoCodenation.test
{
    /// Fake Data
    /// powered by https://mockaroo.com/
    ///
    public class FakeContext
    {
        public DbContextOptions<ProjetoPraticoContext> FakeOptions { get; }

        private Dictionary<Type, string> DataFileNames { get; } = 
            new Dictionary<Type, string>();
        private string FileName<T>() { return DataFileNames[typeof(T)]; }

        public FakeContext(string testName)
        {
            FakeOptions = new DbContextOptionsBuilder<ProjetoPraticoContext>()
                .UseInMemoryDatabase(databaseName: $"ProjetoPratico_{testName}")
                .Options;
            
            DataFileNames.Add(typeof(Usuario), $"FakeData{Path.DirectorySeparatorChar}usuario.json");
            DataFileNames.Add(typeof(Nivel), $"FakeData{Path.DirectorySeparatorChar}nivel.json");
            DataFileNames.Add(typeof(Evento), $"FakeData{Path.DirectorySeparatorChar}evento.json");
            DataFileNames.Add(typeof(Ambiente), $"FakeData{Path.DirectorySeparatorChar}ambiente.json");
            DataFileNames.Add(typeof(LogErro),$"FakeData{Path.DirectorySeparatorChar}logerro.json");

        }

        public void FillWithAll()
        {
            FillWith<Usuario>();
            FillWith<Nivel>();
            FillWith<Evento>();
            FillWith<Ambiente>();
            FillWith<LogErro>();
        }

        public void FillWith<T>() where T: class
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

    }
}
