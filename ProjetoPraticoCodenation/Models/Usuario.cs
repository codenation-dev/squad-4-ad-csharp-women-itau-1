using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("id_usuario")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("nm_usuario")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("nm_login")]
        [Required]
        [StringLength(30)]
        public string Login { get; set; }

        [Column("ds_senha")]
        [StringLength(255)]
        [Required]
        public string Senha { get; set; }

        [Column("cd_token")]
        [StringLength(255)]
        public string Token { get; set; }
    }
}
