using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;

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
                .Length(14)
                .WithMessage("O CNPJ tem que ter 14 caracteres")
                .Must((x, _) => ValidarSeECNPJ(x.CNPJ))
                .WithMessage("CNPJ inválido!!");

            RuleFor(x => x.Ramo)
                .IsInEnum()
                .WithMessage("Ramo inválido")
                .Must((x, _) => VerificarSeOEnumEstaVazio(x.Ramo)).WithMessage("O campo enum é obrigatório");
        }

        private static bool ValidarSeECNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito); 
        }

        public static bool VerificarSeOEnumEstaVazio(EnumRamoDaEmpresa enumRamoEmpresa)
        {
            return !(enumRamoEmpresa == EnumRamoDaEmpresa.NaoDefinido);
        }
    }
}