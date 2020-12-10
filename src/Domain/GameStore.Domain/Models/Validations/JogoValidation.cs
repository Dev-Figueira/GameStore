using FluentValidation;

namespace GameStore.Domain.Models.Validations
{
    public class JogoValidation : AbstractValidator<Jogo>
    {
        public JogoValidation()
        {
            RuleFor(j => j.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(j => j.Genero)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
