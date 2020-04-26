using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ProjetoPraticoCodenation.Models;

namespace ProjetoPraticoCodenation.test.Model
{
    public class UsuarioModelTest : ModelBaseTest
    {
        public UsuarioModelTest() : base(new ProjetoPraticoContext())
        {
            base.Table = "Usuario";
            base.Model = "ProjetoPraticoCodenation.Models.Usuario";
        }

        [Fact]
        public void Devera_Ter_tabela()
        {
            AssertTable();
        }

        [Fact]
        public void Devera_Ter_Primary_Key()
        {
            CompararPrimaryKeys("id_usuario");
        }

        [Theory]
        [InlineData("id_usuario", false, typeof(int), null)]
        [InlineData("nm_usuario", false, typeof(string), 100)]
        [InlineData("nm_login", false, typeof(string), 30)]
        [InlineData("ds_senha", false, typeof(string), 255)]
        [InlineData("cd_token", true, typeof(string), 255)]

        public void Devera_Ter_Campos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            CompararCampos(campoNome, ehNulo, campoTipo, campoTamanho);
        }

    }
}

