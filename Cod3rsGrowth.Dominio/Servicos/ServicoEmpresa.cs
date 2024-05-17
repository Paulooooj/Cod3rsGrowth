using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class ServicoEmpresa : IServicoEmpresa
    {
        public List<Empresa> ObterTodos()
        {
            var listaEmpresas = new List<Empresa>();
            listaEmpresas.Add(new Empresa { Id = 1, RazaoSocial = "InventSoftware", CNPJ = "123456789", Ramo = EnumRamoDaEmpresa.Servico });
            listaEmpresas.Add(new Empresa { Id = 2, RazaoSocial = "EmpresaTeste", CNPJ = "987654321", Ramo = EnumRamoDaEmpresa.Industria });
            listaEmpresas.Add(new Empresa { Id = 3, RazaoSocial = "TesteEmpresa", CNPJ = "543216789", Ramo = EnumRamoDaEmpresa.Comercio });

            return listaEmpresas;
        }
    }
}
