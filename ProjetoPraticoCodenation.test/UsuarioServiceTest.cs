using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;

namespace ProjetoPraticoCodenation.test
{
    public class UsuarioServiceTest
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Deve_Carregar_Usuario_Certo_Quando_Pesquisar_Por_Id(int id)
        {
            var fakeContext = new FakeContext("BuscaUsuarioPorId");   
            fakeContext.FillWith<Usuario>(); 

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions)) 
            {
                var expected = fakeContext.GetFakeData<Usuario>().Find(x => x.Id == id);

                var service = new UsuarioService(context);
                
                var actual = service.FindById(id);
           
                Assert.Equal(expected, actual, new UsuarioComparer());
            }
        }

        [Fact]
        public void Deve_Incluir_Novo_Usuario_Quando_Salvar()
        {
            var fakeContext = new FakeContext("SalvarUsuario");
            
            var fakeUsuario = fakeContext.GetFakeData<Usuario>().FirstOrDefault();
            fakeUsuario.Id = 0;

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new UsuarioService(context);
                var actual = service.Save(fakeUsuario);

                Assert.NotEqual(0, actual.Id);
            }
        }

    }
}

