using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(expression: f => f.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caractéres.");

            When(predicate: f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, action: () =>
            {
                RuleFor(expression: f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(expression: f => CpfValidacao.Validar(f.Documento)).Equal(toCompare: true)
                .WithMessage("O documento fornecido é inválido.");
            });

            When(predicate: f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, action: () =>
            {
                RuleFor(expression: f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(expression: f => CnpjValidacao.Validar(f.Documento)).Equal(toCompare: true)
                .WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}