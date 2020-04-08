using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.Models
{
    [Table("ambiente")]
    public class Ambiente
    {
        [Column("id_ambiente")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("ds_ambiente")]
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
            
        public virtual ICollection<LogErro> Logs { get; set; }
    }
}
