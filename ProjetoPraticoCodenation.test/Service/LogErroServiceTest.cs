
using Xunit;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;
using System.Collections.Generic;
using Xunit.Extensions;
using System;

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
                var actual = service.Salvar(fakeLogErro);

                Assert.NotEqual(0, actual.Id);
            }
        }
        /*
        [Fact]
        public void Devera_Alterar_LogErro()
        {
            var fakeContext = new FakeContext("AlterarLogErro");
           
            var fakeLogErro = fakeContext.GetFakeData<LogErro>().Last();
            fakeLogErro.Arquivado = true;
           
            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new LogErroService(context);
                var actual = service.Arquivar(fakeLogErro);

                Assert.Equal(fakeLogErro.Arquivado, actual.Arquivado);
            }
        }*/

        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Deve_Remover_LogErro_1(int id)
        {
            var fakeContext = new FakeContext("RemoverLogErro");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new LogErroService(context);

                service.Remover(id);

                var actual = service.FindById(id);

                Assert.Null(actual);
            }
        }
        
        [Theory]
        [InlineData("error", "Produção")]
        [InlineData("debug", "Homologacao")]
        public void Deve_Retornar_Log_Por_Nivel_e_Ambiente(string nivel, string ambiente)
        {
            var fakeContext = new FakeContext("LocalizarPorNivelAmbiente");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<LogErro>().Where(x => x.Nivel == nivel)
                                                                .Where(x => x.Ambiente == ambiente);

                var service = new LogErroService(context);

                var actual = service.LocalizarPorNivelAmbiente(nivel, ambiente, true, false);

                Assert.Equal(expected, actual, new LogErroComparer());
            }
        }
        
        [Theory]
        [InlineData("error", "Produção")]
        [InlineData("debug", "Homologacao")]
        public void Deve_Retornar_Log_Por_Descricao_e_Ambiente(string descricao, string ambiente)
        {
            var fakeContext = new FakeContext("LocalizarPorDescricaoAmbiente");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<LogErro>().Where(x => x.Descricao == descricao)
                                                                .Where(x => x.Ambiente == ambiente);

                var service = new LogErroService(context);

                var actual = service.LocalizarPorDescricaoAmbiente(descricao, ambiente, true, false);

                Assert.Equal(expected, actual, new LogErroComparer());
            }
        }

        [Theory]
        [MemberData(nameof(_data))]
        public void Deve_Excluir_Log(List<int> listaId)
        {
            var fakeContext = new FakeContext("LocalizarPorDescricaoAmbiente");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new LogErroService(context);

                List<LogErro> before = new List<LogErro>();
                

                foreach (int id in listaId)
                {
                    before.Add(service.FindById(id));
                }

                foreach (int id in listaId)
                {
                    service.Remover(id);
                }

                List<LogErro> after = new List<LogErro>();

                foreach (int id in listaId)
                {
                    var obj = service.FindById(id);
                    if (obj != null)
                        after.Add(obj);
                }

                Assert.NotEqual(before.Count, after.Count);
            }
        }

        public static List<object[]> _data = new List<object[]>
        {
            new object[] { new List<int> { 1, 2} }
        };

    }
}

