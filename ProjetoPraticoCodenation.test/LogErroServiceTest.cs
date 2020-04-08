using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.test
{
    public class LogErroServiceTest
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Deve_Carregar_LogErro_Certo_Quando_Pesquisar_Por_Id(int id)
        {
            var fakeContext = new FakeContext("BuscaLogErroPorId");   
            fakeContext.FillWith<LogErro>(); 

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions)) 
            {
                var expected = fakeContext.GetFakeData<LogErro>().Find(x => x.Id == id);

                var service = new LogErroService(context);
                
                var actual = service.FindById(id);
           
                Assert.Equal(expected, actual, new LogErroComparer());
            }
        }

        [Fact]
        public void Deve_Incluir_Novo_LogErro_Quando_Salvar()
        {
            var fakeContext = new FakeContext("SalvarLogErro");
            
            var fakeLogErro = fakeContext.GetFakeData<LogErro>().FirstOrDefault();
            fakeLogErro.Id = 0;

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new LogErroService(context);
                var actual = service.Save(fakeLogErro);

                Assert.NotEqual(0, actual.Id);
            }
        }

    }
}

