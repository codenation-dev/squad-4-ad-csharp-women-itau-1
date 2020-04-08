using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.test
{
    public class NivelServiceTeste
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Deve_Carregar_Nivel_Certo_Quando_Pesquisar_Por_Id(int id)
        {
            var fakeContext = new FakeContext("BuscaNivelPorId");   
            fakeContext.FillWith<Nivel>(); 

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions)) 
            {
                var expected = fakeContext.GetFakeData<Nivel>().Find(x => x.Id == id);

                var service = new NivelService(context);
                
                var actual = service.FindById(id);
           
                Assert.Equal(expected, actual, new NivelComparer());
            }
        }

        [Fact]
        public void Deve_Incluir_Novo_nivel_Quando_Salvar()
        {
            var fakeContext = new FakeContext("SalvarNivel");
            
            var fakenivel = fakeContext.GetFakeData<Nivel>().FirstOrDefault();
            fakenivel.Id = 0;

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new NivelService(context);
                var actual = service.Save(fakenivel);

                Assert.NotEqual(0, actual.Id);
            }
        }

    }
}

