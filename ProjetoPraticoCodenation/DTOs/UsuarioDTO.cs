using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPraticoCodenation.DTOs
{
    public class UsuarioDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        public string Token { get; set; }

    }
}
