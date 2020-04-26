using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;


namespace ProjetoPraticoCodenation.test.Model
{
    public abstract class ModelBaseTest
    {
        private DbContext context;

        protected string Model { get; set; }

        protected string Table { get; set; }

        public ModelBaseTest(DbContext context)
        {
            this.context = context;
        }

        public IEntityType GetEntity()
        {
            return context.Model.FindEntityType(Model);
        }

        protected string GetTableName(IEntityType entity)
        {
            var annotation = entity.FindAnnotation("Relational:TableName");
            return annotation?.Value?.ToString();
        }

        protected string GetFieldName(IProperty property)
        {
            var annotation = property.FindAnnotation("Relational:ColumnName");
            return annotation?.Value?.ToString();
        }

        public void AssertTable()
        {
            var entity = GetEntity();
            Assert.NotNull(entity);
            var actual = this.GetTableName(entity);
            Assert.Equal(Table, actual);
        }

        public void CompararCampos(string campoNome, bool ehNulo, Type campoTipo, int? campoTamanho)
        {
            // buscar tipo da entidade
            var entity = GetEntity();
            //comparar se entidade é nula
            Assert.NotNull(entity);
            //comparar nome esperado nos nomes recuperados
            Assert.Contains(campoNome, GetNomesCampos(entity));

            //procurar propriedade atraves da entidade e o campo, para gerar objeto recuperado
            var propriedade = ProcurarCampo(entity, campoNome);

            // criar objeto esperado
            var esperado = new
            {
                tipo = campoTipo,
                nulo = ehNulo,
                tamanho = campoTamanho.HasValue ? campoTamanho.Value : 0
            }.ToString();

            // criar objeto recuperado
            var atual = new
            {
                tipo = propriedade.ClrType,
                nulo = propriedade.IsNullable,
                tamanho = campoTamanho.HasValue ? GetTamanhoCampo(propriedade) : 0
            }.ToString();

            //comparar o campo esperado com recuperado
            Assert.Equal(esperado, atual);
        }

        private IEnumerable<string> GetNomesCampos(IEntityType entity)
        {
            //procurar as propriedades através da entidade respectiva
            var propriedades = entity.GetProperties();

            //retornar a campos/colunas através das propriedades recuperadas 
            return propriedades?.Select(x => this.GetNomeCampo(x)).ToList();
        }

        private string GetNomeCampo(IProperty property)
        {
            //procurar  a proriedade coluna através da proriedade respectiva
            var annotation = property.FindAnnotation("Relational:ColumnName");

            //retornar valor como string
            return annotation?.Value?.ToString();
        }

        private int GetTamanhoCampo(IProperty propriedade)
        {
            //retornar o tamanho da proriedade respectiva
            return propriedade.GetMaxLength().Value;
        }

        private IProperty ProcurarCampo(IEntityType entity, string campoNome)
        {
            //procurar as propriedades através da entidade respectiva
            var propriedades = entity.GetProperties();

            //retornar o campo esperado (vindo da comparação dos campos das propriedades e o campo esperado)  com  através das propriedades recuperadas
            return propriedades.FirstOrDefault(x => this.GetNomeCampo(x) == campoNome);
        }

        private IEnumerable<string> GetPrimaryKeys(IEntityType entity)
        {
            var chave = entity.FindPrimaryKey();
            return chave?.Properties.Select(x => this.GetNomeCampo(x)).ToList();
        }

        protected void CompararPrimaryKeys(params string[] keys)
        {
            var entity = GetEntity();
            Assert.NotNull(entity);

            var chavesAtuais = GetPrimaryKeys(entity);
            Assert.NotNull(chavesAtuais);
            Assert.Contains(keys, x => chavesAtuais.Contains(x));
        }

    }
}
