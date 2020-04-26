using System;
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
            var fakeService = fakes.FakeAccelerationService().Object;
            var expected = fakes.Mapper.Map<LogErroDTO>(fakeService.FindById(id));

            var controller = new LogErroController(fakeService, fakes.Mapper);
            var result = controller.Get(id);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as LogErroDTO;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new LogErroDTOComparer());
        }


        [Theory]
        [InlineData("error", "Produção")]
        [InlineData("debug", "Homologacao")]
        public void Deve_Retornar_Ok_Pesquisa_Por_Ambiente_Nivel(string nivel, string ambiente)
        {
            var fakes = new FakeContext("LogErroControllerTest");
            var fakeService = fakes.FakeAccelerationService().Object;
            var expected = fakes.Mapper.Map<List<LogErroDTO>>(fakeService.LocalizarPorNivelAmbiente(nivel, ambiente));

            var controller = new LogErroController(fakeService, fakes.Mapper);
            var result = controller.GetNivelAmbiente(nivel, ambiente);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<LogErroDTO>;
            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new LogErroDTOComparer());
        }

        [Fact]
        public void Deve_Retornar_OK_Post()
        {
            var fakes = new FakeContext("LogErroControllerTest");
            var fakeService = fakes.FakeAccelerationService().Object;
            var expected = fakes.Get<LogErroDTO>().First();
            expected.Id = 0;

            var controller = new LogErroController(fakeService, fakes.Mapper);
            var result = controller.Post(expected);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as LogErroDTO;

            Assert.NotNull(actual);
            Assert.Equal(999, actual.Id);
            Assert.Equal(expected.Titulo, actual.Titulo);
            Assert.Equal(expected.Descricao, actual.Descricao);
            Assert.Equal(expected.Ambiente, actual.Ambiente);
            Assert.Equal(expected.Nivel, actual.Nivel);
            Assert.Equal(expected.Evento, actual.Evento);
            Assert.Equal(expected.DataCriacao, actual.DataCriacao);
            Assert.Equal(expected.IPOrigem, actual.IPOrigem);
            Assert.Equal(expected.UsuarioOrigem, actual.UsuarioOrigem);
            Assert.Equal(expected.Arquivado, actual.Arquivado);

        }
        
    }
}
