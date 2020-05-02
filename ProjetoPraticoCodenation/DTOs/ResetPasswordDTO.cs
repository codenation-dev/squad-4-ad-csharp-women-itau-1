using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPraticoCodenation.DTOs
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserId { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Code { get; set; }
    }
}
