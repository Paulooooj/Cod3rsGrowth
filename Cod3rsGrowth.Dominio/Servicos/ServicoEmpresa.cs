using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class ServicoEmpresa : IServicoEmpresa
    {
        public List<Empresa> ObterTodos()
        {
            var listaEmpresas = new List<Empresa> 
            {
            new Empresa { Id = 1, RazaoSocial = "InventSoftware", CNPJ = "123456789", Ramo = EnumRamoDaEmpresa.Servico },
            new Empresa { Id = 2, RazaoSocial = "EmpresaTeste", CNPJ = "987654321", Ramo = EnumRamoDaEmpresa.Industria },
            new Empresa { Id = 3, RazaoSocial = "TesteEmpresa", CNPJ = "543216789", Ramo = EnumRamoDaEmpresa.Comercio },
            };
            return listaEmpresas;
        }
        public List<Empresa> Remover(int id)
        {
            var listaRemover = ObterTodos();
            foreach(var item in listaRemover.ToList()) { 
              if(item.Id == id)
                {
                    listaRemover.Remove(item);
                }
            }
            return listaRemover;
        }
    }
}