using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.test
{
    public class EventoServiceTest
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Deve_Carregar_Evento_Certo_Quando_Pesquisar_Por_Id(int id)
        {
            var fakeContext = new FakeContext("BuscaEventoPorId");   
            fakeContext.FillWith<Evento>(); 

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions)) 
            {
                var expected = fakeContext.GetFakeData<Evento>().Find(x => x.Id == id);

                var service = new EventoService(context);
                
                var actual = service.FindById(id);
           
                Assert.Equal(expected, actual, new EventoComparer());
            }
        }

        [Fact]
        public void Deve_Incluir_Novo_Evento_Quando_Salvar()
        {
            var fakeContext = new FakeContext("SalvarEvento");
            
            var fakeEvento = fakeContext.GetFakeData<Evento>().FirstOrDefault();
            fakeEvento.Id = 0;

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new EventoService(context);
                var actual = service.Save(fakeEvento);

                Assert.NotEqual(0, actual.Id);
            }
        }

    }
}

