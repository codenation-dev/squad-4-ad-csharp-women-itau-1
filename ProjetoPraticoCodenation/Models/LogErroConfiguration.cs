using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPraticoCodenation.Models
{
    class LogErroConfiguration : IEntityTypeConfiguration<LogErro>
    {
        public void Configure(EntityTypeBuilder<LogErro> builder)
        {
            builder.HasKey(x => new { x.UsuarioId});
        }
    }
}
