using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using System.Linq;

namespace Cod3rsGrowth.Servico.Validacao
{
    public class EmpresaValidacao : AbstractValidator<Empresa>
    {
        private readonly IRepositorioEmpresa _repositorioEmpresa;

        public EmpresaValidacao(IRepositorioEmpresa repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;

            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.RazaoSocial)
                .NotEmpty()
                .WithMessage("O campo Razão Social é obrigatorio")
                .MaximumLength(20)
                .WithMessage("Número máximo de caracteres atingido")
                .Must((x, _) => _repositorioEmpresa.verificarSeTemNomeRepetido(x.RazaoSocial))
                .WithMessage("Esse nome já existe");

            RuleFor(x => x.CNPJ).Cascade(CascadeMode.Stop)
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
            return cnpj.All(char.IsDigit);
        }

        public static bool VerificarSeOEnumEstaVazio(EnumRamoDaEmpresa enumRamoEmpresa)
        {
            return !(enumRamoEmpresa == EnumRamoDaEmpresa.NaoDefinido);
        }
    }
}