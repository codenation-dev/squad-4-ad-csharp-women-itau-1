using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProjetoPraticoCodenation.DTOs;
using ProjetoPraticoCodenation.Controllers;

namespace ProjetoPraticoCodenation.test.Model
{
    public class LogErroControllerTest
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Deve_Retornar_Ok_Pesquisa_Por_Id(int id)
        {
            var fakes = new FakeContext("LogErroControllerTest");
            var fakeService = fakes.FakeLogErroService().Object;
            var expected = fakes.Mapper.Map<LogErroDTO>(fakeService.FindById(id));

            var controller = new LogErroController(fakeService, fakes.Mapper);
            var result = controller.Get(id);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as LogErroDTO;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new LogErroDTOComparer());
        }

        [Theory]
        [InlineData("Erro 504 Gateway Timeout", "Producao")]
        [InlineData("404 nao encontrado.", "Producao")]
        public void Deve_Retornar_Ok_Pesquisa_Por_Descricao_Ambiente(string descricao, string ambiente)
        {
            var fakes = new FakeContext("LogErroControllerTestDescricao");
            var fakeService = fakes.FakeLogErroService().Object;
            var expected = fakes.Mapper.Map<List<LogErroDTO>>(fakeService.LocalizarPorDescricaoAmbiente(descricao, ambiente, true, false));

            var controller = new LogErroController(fakeService, fakes.Mapper);
            var result = controller.GetDescricaoAmbiente(descricao, ambiente, true, false);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<LogErroDTO>;
            Assert.NotEmpty(actual);
            Assert.Equal(expected, actual, new LogErroDTOComparer());
        }

        [Theory]
        [InlineData("error", "Producao")]
        [InlineData("warning", "Desenvolvimento")]
        public void Deve_Retornar_Ok_Pesquisa_Por_Nivel_Ambiente(string nivel, string ambiente)
        {
            var fakes = new FakeContext("LogErroControllerTestNivel");

            var fakeService = fakes.FakeLogErroService().Object;

            var expected = fakes.Mapper.Map<List<LogErroDTO>>(fakeService.LocalizarPorNivelAmbiente(nivel, ambiente, true, false));

            var controller = new LogErroController(fakeService, fakes.Mapper);
            var result = controller.GetNivelAmbiente(nivel, ambiente, true, false);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<LogErroDTO>;
            Assert.NotEmpty(actual);
            Assert.Equal(expected, actual, new LogErroDTOComparer());
        }

        [Theory]
        [InlineData("127.0.0.1", "Producao")]
        [InlineData("app.server.com.br", "Homologacao")]
        public void Deve_Retornar_Ok_Pesquisa_Por_Origem_Ambiente(string origem, string ambiente)
        {
            var fakes = new FakeContext("LogErroControllerTestOrigem");

            var fakeService = fakes.FakeLogErroService().Object;

            var expected = fakes.Mapper.Map<List<LogErroDTO>>(fakeService.LocalizarPorOrigemAmbiente(origem, ambiente, true, false));

            var controller = new LogErroController(fakeService, fakes.Mapper);
            var result = controller.GetOrigemAmbiente(origem, ambiente, true, false);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<LogErroDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new LogErroDTOComparer());
        }

        [Fact]
        public void Deve_Retornar_OK_Post()
        {
            var fakes = new FakeContext("LogErroControllerTest");
            var fakeService = fakes.FakeLogErroService().Object;
            var expected = fakes.Get<LogErroDTO>().ToList();

            for (int i = 0; i <= expected.Count - 1; i++)
            {
                expected[i].Id = 0;
                expected[i].Arquivado = false;
            }

            var controller = new LogErroController(fakeService, fakes.Mapper);
            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<LogErroDTO>;

            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i <= actual.Count - 1; i++)
            {
                Assert.Equal(999, actual[i].Id);

                Assert.Equal(expected[i].Titulo, actual[i].Titulo);
                Assert.Equal(expected[i].Descricao, actual[i].Descricao);
                Assert.Equal(expected[i].Ambiente, actual[i].Ambiente);
                Assert.Equal(expected[i].Nivel, actual[i].Nivel);
                Assert.Equal(expected[i].Evento, actual[i].Evento);
                Assert.Equal(expected[i].DataCriacao, actual[i].DataCriacao);
                Assert.Equal(expected[i].Origem, actual[i].Origem);
                Assert.Equal(expected[i].UsuarioOrigem, actual[i].UsuarioOrigem);

            }
        }

    }
}
