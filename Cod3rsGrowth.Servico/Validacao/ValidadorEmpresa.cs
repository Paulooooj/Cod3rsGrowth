using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using System.Linq;

namespace Cod3rsGrowth.Servico.Validacao
{
    public class ValidadorEmpresa : AbstractValidator<Empresa>
    {
        private readonly IRepositorioEmpresa _repositorioEmpresa;

        public ValidadorEmpresa(IRepositorioEmpresa repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;

            ClassLevelCascadeMode = CascadeMode.Continue;

            RuleFor(x => x.RazaoSocial)
                .NotEmpty()
                .WithMessage("O campo Razão Social é obrigatorio")
                .MaximumLength(20)
                .WithMessage("Número máximo de caracteres atingido");


            RuleFor(x => x)
                .Must(x => _repositorioEmpresa.EhNomeExistenteNoBanco(x))
                .WithMessage("Essa Razão Social já existe");

            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .WithMessage("O campo CNPJ é obrigatorio")
                .Must((x, _) => ValidarCNPJ(x.CNPJ))
                .WithMessage("CNPJ inválido");

            RuleFor(x => x.Ramo)
                .IsInEnum()
                .WithMessage("Ramo inválido")
                .Must((x, _) => VerificarSeOEnumEstaVazio(x.Ramo)).WithMessage("O campo enum é obrigatório");
        }

        private static bool ValidarCNPJ(string cnpj)
        {
            if (cnpj == null) return false;
             
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            if (cnpj.All(c => c == cnpj[0]))
                return false;

            int[] pesosPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int somaPrimeiroDigito = cnpj.Take(12).Select((c, i) => (c - '0') * pesosPrimeiroDigito[i]).Sum();
            int restoPrimeiroDigito = somaPrimeiroDigito % 11;
            int digitoVerificador1 = restoPrimeiroDigito < 2 ? 0 : 11 - restoPrimeiroDigito;

            int[] pesosSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int somaSegundoDigito = cnpj.Take(13).Select((c, i) => (c - '0') * pesosSegundoDigito[i]).Sum();
            int restoSegundoDigito = somaSegundoDigito % 11;
            int digitoVerificador2 = restoSegundoDigito < 2 ? 0 : 11 - restoSegundoDigito;

            return cnpj.EndsWith($"{digitoVerificador1}{digitoVerificador2}");
        }

        public static bool VerificarSeOEnumEstaVazio(EnumRamoDaEmpresa enumRamoEmpresa)
        {
            return !(enumRamoEmpresa == EnumRamoDaEmpresa.NaoDefinido);
        }
    }
}