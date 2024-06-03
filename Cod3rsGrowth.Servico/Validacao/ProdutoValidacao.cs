using FluentValidation;
using Cod3rsGrowth.Dominio.Entidades;

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
                .NotEmpty().WithMessage("Campo obrigatorio");
           
            RuleFor(x => x.DataValidade)
                .Must(x => x > DateTime.Today)
                .WithMessage("Tem que ser a data de hoje");

            RuleFor(x => x.EmpresaId)
                .NotNull().WithMessage("O Id não pode ser nulo")
                .NotEmpty()
                .WithMessage("O campo Empresa Id é obrigatorio");
                
        }
    }
}