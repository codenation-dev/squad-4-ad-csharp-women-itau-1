using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.Models
{
    [Table("nivel")]
    public class Nivel
    {
        [Column("id_nivel")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("cd_nivel")]
        [Required]
        public int Codigo { get; set; }

        [Column("ds_nivel")]
        [Required]
        [StringLength(250)]
        public string Descricao { get; set; }

        public virtual ICollection<LogErro> Logs { get; set; }
    }
}
