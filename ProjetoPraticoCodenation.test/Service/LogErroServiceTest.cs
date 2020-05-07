
using Xunit;
using System.Linq;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Services;
using System.Collections.Generic;
using Xunit.Extensions;
using System;
using Microsoft.EntityFrameworkCore;
using ProjetoPraticoCodenation.Data;

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

        [Theory]
        [InlineData("Producao")]
        [InlineData("Desenvolvimento")]
        public void Deve_Retornar_Log_Por__Ambiente(string ambiente)
        {
            var fakeContext = new FakeContext("LocalizarPorAmbiente");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var dados = fakeContext.GetFakeData<LogErro>();
                var expected = dados.Where(x => x.Ambiente == ambiente)
                                    .Where(x => x.Arquivado == false)
                                    .ToList();

                var service = new LogErroService(context);

                var actual = service.LocalizarPorAmbiente(ambiente, false, false);

                Assert.NotEmpty(actual);
                Assert.NotEmpty(expected);
                Assert.Equal(expected, actual, new LogErroComparer());
            }
        }

        [Theory]
        [InlineData("error", "Producao")]
        [InlineData("warning", "Desenvolvimento")]
        public void Deve_Retornar_Log_Por_Nivel_e_Ambiente(string nivel, string ambiente)
        {
            var fakeContext = new FakeContext("LocalizarPorNivelAmbiente");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var dados = fakeContext.GetFakeData<LogErro>();
                var expected = dados.Where(x => x.Nivel == nivel)
                                    .Where(x => x.Ambiente == ambiente)
                                    .Where(x => x.Arquivado == false)
                                    .ToList();

                var service = new LogErroService(context);

                var actual = service.LocalizarPorNivelAmbiente(nivel, ambiente, true, false);

                Assert.NotEmpty(actual);
                Assert.NotEmpty(expected);
                Assert.Equal(expected, actual, new LogErroComparer());
            }
        }

        [Theory]
        [InlineData("Erro 504 Gateway Timeout", "Producao")]
        [InlineData("404 nao encontrado.", "Producao")]
        public void Deve_Retornar_Log_Por_Descricao_e_Ambiente(string descricao, string ambiente)
        {
            var fakeContext = new FakeContext("LocalizarPorDescricaoAmbiente");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var dados = fakeContext.GetFakeData<LogErro>();
                var expected = dados .Where(x => x.Descricao == descricao)
                                     .Where(x => x.Ambiente == ambiente)
                                     .Where(x => x.Arquivado == false)
                                     .OrderBy(x=> x.Nivel)
                                     .ToList();

                var service = new LogErroService(context);

                var actual = service.LocalizarPorDescricaoAmbiente(descricao, ambiente, true, false);

                Assert.NotEmpty(actual);
                Assert.NotEmpty(expected);
                Assert.Equal(expected, actual, new LogErroComparer());
            }
        }


        [Theory]
        [InlineData("127.0.0.1", "Producao")]
        [InlineData("app.server.com.br", "Homologacao")]
        public void Deve_Retornar_Log_Por_Origem_e_Ambiente(string origem, string ambiente)
        {
            var fakeContext = new FakeContext("LocalizaOrigemAmbiente");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var dados = fakeContext.GetFakeData<LogErro>();
                var expected = dados.Where(x => x.Origem == origem)
                                    .Where(x => x.Ambiente == ambiente)
                                    .Where(x => x.Arquivado == false)
                                    .OrderBy(x => x.Nivel)
                                    .ToList();

                var service = new LogErroService(context);

                var actual = service.LocalizarPorOrigemAmbiente(origem, ambiente, true, false);

                Assert.NotEmpty(actual);
                Assert.NotEmpty(expected);
                Assert.Equal(expected, actual, new LogErroComparer());
            }
        }


        [Theory]
        [MemberData(nameof(_data_remover))]
        public void Deve_Excluir_Log(List<int> listaId)
        {
            if (listaId == null)
                throw new ArgumentNullException();
            var fakeContext = new FakeContext("RemoverLog");
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



        [Theory]
        [MemberData(nameof(_data_arquivar))]
        public void Deve_Arquivar_Log(List<int> listaId)
        {
            if (listaId == null)
                throw new ArgumentNullException();

            var fakeContext = new FakeContext("ArquivarLog");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var service = new LogErroService(context);

                List<LogErro> before = new List<LogErro>();


                foreach (int id in listaId)
                {
                    var log = service.FindById(id);
                    context.Entry(log).State = EntityState.Detached;
                    before.Add(log);
                }

                foreach (int id in listaId)
                {
                    service.Arquivar(id);
                }

                List<LogErro> after = new List<LogErro>();

                foreach (int id in listaId)
                {
                    var obj = service.FindById(id);
                    if (obj != null)
                        after.Add(obj);
                }

                Assert.NotEqual(before, after, new LogErroComparer());
            }
        }

        [Fact]
        public void Deve_Retornar_Log_Por_Arquivados()
        {
            var fakeContext = new FakeContext("LocalizarPorArquivados");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                var dados = fakeContext.GetFakeData<LogErro>();
                var expected = dados.Where(x => x.Arquivado == true)
                                    .ToList();

                var service = new LogErroService(context);

                var actual = service.LocalizarArquivados();

                Assert.NotEmpty(actual);
                Assert.NotEmpty(expected);
                Assert.Equal(expected, actual, new LogErroComparer());
            }
        }

        [Theory]
        [MemberData(nameof(_data_desarquivar))]
        public void Deve_Desarquivar_Log(List<int> listaId)
        {
            var fakeContext = new FakeContext("ArquivarLog");
            fakeContext.FillWith<LogErro>();

            using (var context = new ProjetoPraticoContext(fakeContext.FakeOptions))
            {
                if (listaId == null)
                    throw new ArgumentNullException();

                var service = new LogErroService(context);

                List<LogErro> before = new List<LogErro>();

                foreach (int id in listaId)
                {
                    var log = service.FindById(id);
                    context.Entry(log).State = EntityState.Detached;
                    before.Add(log);
                }

                foreach (int id in listaId)
                {
                    service.Desarquivar(id);
                }

                List<LogErro> after = new List<LogErro>();

                foreach (int id in listaId)
                {
                    var obj = service.FindById(id);
                    if (obj != null)
                        after.Add(obj);
                }

                Assert.NotEqual(before, after, new LogErroComparer());
            }
        }

        public static List<object[]> _data_desarquivar = new List<object[]>
        {
            new object[] { new List<int> { 3, 4} }
        };

        public static List<object[]> _data_arquivar = new List<object[]>
        {
            new object[] { new List<int> { 1, 2} }
        };


        public static List<object[]> _data_remover = new List<object[]>
        {
            new object[] { new List<int> { 1, 2} }
        };

    }
}

