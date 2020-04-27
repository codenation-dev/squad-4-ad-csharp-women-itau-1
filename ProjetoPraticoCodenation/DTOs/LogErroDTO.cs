using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPraticoCodenation.DTOs
{
    public class LogErroDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        [Required]
        public string Evento { get; set; }

        [Required]
        public string Nivel { get; set; }

        [Required]
        public string Ambiente { get; set; }

        [Required]
        public string Origem { get; set; }

        [Required]
        public Boolean Arquivado { get; set; }

        [Required]
        public string UsuarioOrigem { get; set; }
    }
}
