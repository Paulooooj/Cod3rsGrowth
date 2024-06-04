using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;
using System.Reflection.Emit;

namespace Cod3rsGrowth.Servico.Validacao
{
    public class ProdutoValidacao : AbstractValidator<Produto>
    {
        public ProdutoValidacao()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O campo id é obrigatorio");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatorio")
                .MaximumLength(20).WithMessage("Número máximo de caracteres atingido");
            
            RuleFor(x => x.ValorDoProduto)
                .NotEmpty().WithMessage("O campo valor é obrigatorio")
                .PrecisionScale(10, 2, false)
                .WithMessage("Tamanho máximo atingido");
            
            RuleFor(x => x.DataCadastro)
                .NotEmpty().WithMessage("É necessário informar a data de cadastro")
                .Must(x => x == DateTime.Today).WithMessage("Data de cadastro tem que ser a atual");

            RuleFor(x => x.TemDataValida)
                .NotNull().WithMessage("campo obrigatorio");

            RuleFor(x => x)
                .Must(x => x.DataValidade >= x.DataCadastro.AddMonths(3) || x.DataValidade == null)
                .WithMessage("O produto deve ter data de validade de no mínimo três meses");

            RuleFor(x => x.EmpresaId)
                .NotNull().WithMessage("O Id não pode ser nulo")
                .NotEmpty()
                .WithMessage("O campo Empresa Id é obrigatorio");
        }
    }
}