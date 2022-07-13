using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(expression: c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(min: 2, max: 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caractéres.");

            RuleFor(expression: c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(min: 2, max: 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caractéres.");

            RuleFor(expression: c => c.Valor)
                .GreaterThan(valueToCompare:0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
