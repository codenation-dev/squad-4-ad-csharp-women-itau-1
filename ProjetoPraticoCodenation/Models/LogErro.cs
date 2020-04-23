using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.Models
{
    [Table("log_erros")]
    public class LogErro
    {
        [Column("id_log")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("ds_titulo_log")]
        [Required]
        [StringLength(250)]
        public string Titulo { get; set; }

        [Column("ds_log")]
        [Required]
        [StringLength(8000)]
        public string Descricao { get; set; }

        [Column("dt_criacao")]
        [Required]
        public DateTime DataCriacao { get; set; }

        [Column("id_evento")]
        [Required]
        public int EventoId { get; set; }

        [Column("nivel")]
        [Required]
        public string Nivel { get; set; }

        [Column("id_usuario")]
        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [Column("ambiente")]
        [Required]
        public string Ambiente { get; set; }

        [Column("ip")]
        [Required]
        public string ip { get; set; }


        [Column("arquivo")]
        [Required]
        public int arquivo { get; set; }

    }
}
