using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Testes
{
    public class EmpresaRepositorioMock : IRepositorioEmpresa
    {
        private readonly EmpresaSingleton _instanciaEmpresaSingleton = EmpresaSingleton.Instancia;

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
            var empresa = _instanciaEmpresaSingleton.Where(x=> x.Id == id).FirstOrDefault()
                ?? throw new Exception($"O ID {id} não foi encontrado");
            return empresa;
        }

        public List<Empresa> ObterTodos()
        {
            return _instanciaEmpresaSingleton;
        }
    }
}