using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.test
{
    public class AmbienteServiceTest
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
  
        public void Deve_Carregar_Ambiente_Certo_Quando_Pesquisar_Por_Id(int id)
        {
            var fakeContext = new FakeContext("BuscaAmbientePorId");   
            fakeContext.FillWith<Ambiente>(); 

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions)) 
            {
                var expected = fakeContext.GetFakeData<Ambiente>().Find(x => x.Id == id);

                var service = new AmbienteService(context);
                
                var actual = service.FindById(id);
           
                Assert.Equal(expected, actual, new AmbienteComparer());
            }
        }

        [Fact]
        public void Deve_Incluir_Novo_Ambiente_Quando_Salvar()
        {
            var fakeContext = new FakeContext("SalvarAmbiente");
            
            var fakeAmbiente = fakeContext.GetFakeData<Ambiente>().FirstOrDefault();
            fakeAmbiente.Id = 0;

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new AmbienteService(context);
                var actual = service.Save(fakeAmbiente);

                Assert.NotEqual(0, actual.Id);
            }
        }

    }
}

