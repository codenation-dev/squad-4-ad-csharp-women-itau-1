using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ProjetoPraticoCodenation.Models;
using ProjetoPraticoCodenation.Data;

namespace ProjetoPraticoCodenation.test.Model
{
    public class LogErroModelTest : ModelBaseTest
    {
        public LogErroModelTest() : base(new ProjetoPraticoContext())
        {
            base.Table = "log_erros";
            base.Model = "ProjetoPraticoCodenation.Models.LogErro";
        }

        [Fact]
        public void Devera_Ter_tabela()
        {
            AssertTable();
        }

        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            CompararPrimaryKeys("id_log");
        }

        [Theory]
        [InlineData("id_log", false, typeof(int), null)]
        [InlineData("ds_titulo_log", false, typeof(string), 250)]
        [InlineData("ds_log", false, typeof(string), 8000)]
        [InlineData("dt_criacao", false, typeof(DateTime), null)]
        [InlineData("cd_evento", false, typeof(string), 50)]
        [InlineData("cd_nivel", false, typeof(string), 50)]
        [InlineData("ds_ambiente", false, typeof(string), 50)]
        [InlineData("ds_origem", false, typeof(string), 50)]
        [InlineData("fl_arquivado", false, typeof(Boolean), null)]
        [InlineData("nm_usuario_origem", false, typeof(string), 50)]
        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

    }
}

