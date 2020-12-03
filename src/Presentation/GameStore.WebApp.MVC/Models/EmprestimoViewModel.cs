using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.WebApp.MVC.Models
{
    public class EmprestimoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid AmigoId { get; set; }
        public AmigoViewModel Amigo { get; set; }
        public Guid JogoId { get; set; }
        public JogoViewModel Jogo { get; set; }
    }
}
