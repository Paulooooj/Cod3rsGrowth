using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Testes
{
    public class EmpresaRepositorioMock : IRepositorioEmpresa
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
            var listaEmpresa = EmpresaSingleton.Instancia.ToList();
            return listaEmpresa;
        }
    }
}