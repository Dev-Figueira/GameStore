using FluentValidation;

namespace GameStore.Domain.Models.Validations
{
    public class EmprestimoValidation : AbstractValidator<Emprestimo>
    {
        public EmprestimoValidation()
        {
            RuleFor(e => e.Amigo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(e => e.Jogo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }
    }
}
