using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.WebApp.MVC.Models
{
    public class AmigoViewModel
    {
        [Key]   
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatorio")]
        [StringLength(100, ErrorMessage = "O nome deve ter ate 100 Caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Apelido é obrigatorio")]
        [StringLength(50, ErrorMessage = "O nome deve ter ate 50 Caracteres")]
        public string Apelido { get; set; }
        [Required(ErrorMessage = "O Email é obrigatorio")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
