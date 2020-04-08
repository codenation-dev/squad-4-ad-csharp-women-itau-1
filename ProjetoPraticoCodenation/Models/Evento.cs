using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.Models
{
    [Table("evento")]
    public class Evento
    {
        [Column("id_evento")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("cd_evento")]
        [Required]
        public int Codigo { get; set; }

        [Column("ds_evento")]
        [Required]
        [StringLength(250)]
        public string Descricao { get; set; }

        public virtual ICollection<LogErro> Logs { get; set; }
    }
}
