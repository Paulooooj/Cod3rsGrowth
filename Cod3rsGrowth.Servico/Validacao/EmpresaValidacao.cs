using Cod3rsGrowth.Dominio.Entidades;
using FluentValidation;

namespace Cod3rsGrowth.Servico.Validacao
{
    public class EmpresaValidacao : AbstractValidator<Empresa>
    {
        public EmpresaValidacao()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O campo id é obrigatorio");

            RuleFor(x => x.RazaoSocial)
                .NotEmpty()
                .WithMessage("O campo Razão Social é obrigatorio")
                .MaximumLength(20)
                .WithMessage("Número máximo de caracteres atingido");

            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .WithMessage("O campo CNPJ é obrigatorio")
                .Length(14)
                .WithMessage("O CNPJ tem que ter 14 caracteres")
                .Must((x, _) => ValidarSeECNPJ(x.CNPJ))
                .WithMessage("CNPJ inválido, não pode caracteres");

            RuleFor(x => x.Ramo)
                .IsInEnum()
                .WithMessage("Ramo inválido")
                .Must((x, _) => VerificarSeOEnumEstaVazio(x.Ramo)).WithMessage("O campo enum é obrigatório");
        }

        private static bool ValidarSeECNPJ(string cnpj)
        {
            var valid = cnpj.All(char.IsDigit);
            return valid;
        }

        public static bool VerificarSeOEnumEstaVazio(EnumRamoDaEmpresa enumRamoEmpresa) 
        {
            return !(enumRamoEmpresa == EnumRamoDaEmpresa.NaoDefinido);
        }
    }
}