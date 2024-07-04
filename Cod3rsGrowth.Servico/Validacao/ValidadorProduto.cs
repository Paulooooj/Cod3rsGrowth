using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;
using System;

namespace Cod3rsGrowth.Servico.Validacao
{
    public class ValidadorProduto : AbstractValidator<Produto>
    {
        public ValidadorProduto()
        {
            ClassLevelCascadeMode = CascadeMode.Continue;

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatorio")
                .MaximumLength(20).WithMessage("Número máximo de caracteres atingido");

            RuleFor(x => x.ValorDoProduto)
                .NotEmpty().WithMessage("O campo valor é obrigatorio")
                .PrecisionScale(10, 2, false)
                .WithMessage("Tamanho máximo atingido");

            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("É necessário informar a data de cadastro")
                .Must(x => x == DateTime.Today)
                .WithMessage("Data de cadastro tem que ser a atual");

            RuleFor(x => x.TemDataValidade)
                .NotNull().WithMessage("campo obrigatorio");

            RuleFor(x => x)
                .Must(x => x.DataValidade >= x.DataCadastro.AddMonths(3) || x.DataValidade == null)
                .WithMessage("O produto deve ter data de validade de no mínimo três meses");
        }
    }
}