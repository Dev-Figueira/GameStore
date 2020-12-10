using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.WebApp.MVC.Models
{
    public class JogoViewModel
    {
        [Key]
        [Required(ErrorMessage = "O Jogo é obrigatorio")]
        public Guid Id { get; set; }

        [Display(Name = "Jogo")]
        [StringLength(200, ErrorMessage = "O nome deve ter ate 200 Caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição/Gênero")]
        [StringLength(100, ErrorMessage = "O nome deve ter ate 100 Caracteres")]
        public string Genero { get; set; }

        [DisplayName("Emprestado?")]
        public bool Emprestado { get; set; }

    }
}
