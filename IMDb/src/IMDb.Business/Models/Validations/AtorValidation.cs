using FluentValidation;

namespace IMDb.Business.Models.Validations
{
    public class AtorValidation : AbstractValidator<Ator>
    {
        public AtorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 255)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
