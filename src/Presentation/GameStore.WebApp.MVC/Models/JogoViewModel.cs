using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameStore.WebApp.MVC.Models
{
    public class JogoViewModel
    {
        [Required(ErrorMessage = "O Jogo é obrigatorio")]
        public Guid Id { get; set; }
        [Display(Name = "Jogo")]
        public string Nome { get; set; }
        public string Genero { get; set; }
    }
}
