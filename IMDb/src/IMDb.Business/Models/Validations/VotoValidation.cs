using FluentValidation;

namespace IMDb.Business.Models.Validations
{
    public class VotoValidation : AbstractValidator<Voto>
    {
        public VotoValidation()
        {
            RuleFor(f => f.Nota)
                .InclusiveBetween(0, 4);
        }
    }
}
