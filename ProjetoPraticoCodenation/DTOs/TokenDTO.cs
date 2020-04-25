using System;
using System.ComponentModel.DataAnnotations;


namespace ProjetoPraticoCodenation.DTOs
{
    public class TokenDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
