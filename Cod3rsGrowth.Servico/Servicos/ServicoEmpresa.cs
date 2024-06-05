using Cod3rsGrowth.Dominio.Entidades;
using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class ServicoEmpresa 
    {
        public List<Empresa> CriarLista()
        {
            var listaEmpresa = new List<Empresa>
            {
                new Empresa
                {
                   Id = 1,
                   RazaoSocial = "InventSoftware",
                   CNPJ = "123456789",
                   Ramo = EnumRamoDaEmpresa.Servico
                },
                new Empresa
                {
                   Id = 2,
                   RazaoSocial = "Heinz",
                   CNPJ = "987654321",
                   Ramo = EnumRamoDaEmpresa.Industria
                },
                new Empresa
                {
                   Id = 3,
                   RazaoSocial = "LojasAmericanas",
                   CNPJ = "543216789",
                   Ramo = EnumRamoDaEmpresa.Comercio
                },
            };
            return listaEmpresa;      
        }        
    }
}