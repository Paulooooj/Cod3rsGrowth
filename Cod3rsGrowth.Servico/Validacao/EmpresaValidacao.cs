using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacao
{
    public class EmpresaValidacao : AbstractValidator<Empresa>
    {
        public EmpresaValidacao()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O campo id é obrigatorio");

            RuleFor(x => x.RazaoSocial).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("O campo Razão Social é obrigatorio").
                MaximumLength(50).WithMessage("Não atingiu o número máximo de caracteres"); 

            RuleFor(x => x.CNPJ).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("O campo CNPJ é obrigatorio").
                Length(14).WithMessage("O CNPJ tem que ter 14 caracteres").
                Must((x, _) => ValidarSeTemCaracteres(x.CNPJ)).WithMessage("Só é permitido números");

            RuleFor(x => x.Ramo).IsInEnum().WithMessage("Ramo inválido"); // não está funcionando da forma correta
           
        }
        private bool ValidarSeTemCaracteres(string cnpj)
        {
            bool valid = cnpj.All(char.IsDigit);
            return valid;
        }

    }
}
