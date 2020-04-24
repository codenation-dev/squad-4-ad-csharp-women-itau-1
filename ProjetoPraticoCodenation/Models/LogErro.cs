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

        [Column("cd_evento")]
        [Required]
        [StringLength(50)]
        public string Evento { get; set; }

        [Column("cd_nivel")]
        [Required]
        [StringLength(50)]
        public string Nivel { get; set; }

        [Column("ds_ambiente")]
        [Required]
        [StringLength(50)]
        public string Ambiente { get; set; }

        [Column("nr_ip_origem")]
        [Required]
        [StringLength(50)]
        public string IPOrigem { get; set; }

        [Column("fl_arquivado")]
        [Required]
        public Boolean Arquivado { get; set; }

        [Column("nm_usuario_origem")]
        [Required]
        [StringLength(50)]
        public string UsuarioOrigem { get; set; }

    }
}
