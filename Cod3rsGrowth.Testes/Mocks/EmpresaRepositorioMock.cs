using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Testes
{
    public class EmpresaRepositorioMock : IEmpresaRepositorio
    {
        public void Adicionar(Empresa empresa)
        {

            throw new NotImplementedException();
        }

        public void Atualizar(Empresa empresa)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Empresa empresa)
        {
            throw new NotImplementedException();
        }

        public Empresa ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Empresa> ObterTodos()
        {
            throw new NotImplementedException();
        }
     
        public void CriarLista()
        {
            var listaEmpresa = new List<Empresa>
            {
                new Empresa
                {
                   Id = 1,
                   RazaoSocial = "Invent Software",
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
                   RazaoSocial = "Lojas Americanas",
                   CNPJ = "543216789",
                   Ramo = EnumRamoDaEmpresa.Comercio
                },
            };
            EmpresaSingleton.Instancia.AddRange(listaEmpresa);
        }
    }
}