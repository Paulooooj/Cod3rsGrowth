using FluentValidation;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servico.Validacao
{
    public class ProdutoValidacao : AbstractValidator<Produto>
    {
        public ProdutoValidacao()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O campo id é obrigatorio");

            RuleFor(x => x.Nome).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("O campo Razão Social é obrigatorio").
                MaximumLength(50).WithMessage("Não atingiu o número máximo de caracteres");

            RuleFor(x => x.ValorDoProduto).NotEmpty().WithMessage("O campo valor é obrigatorio").PrecisionScale(10, 2, false);

            RuleFor(x => x.DataCadastro).NotEmpty().WithMessage("É necessário informar a data de cadastro").
                LessThan(DateTime.Today).WithMessage("Data de cadastro tem que ser a atual");

            RuleFor(x => x.TemDataValida).NotEmpty().WithMessage("Campo obrigatorio");

            RuleFor(x => x.DataValidade);

            RuleFor(x => x.EmpresaId).NotEmpty().WithMessage("O campo Empresa Id é obrigatorio");
        }

    }
}
