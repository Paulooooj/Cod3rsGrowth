using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Servico.Validacao;
using FluentValidation;

namespace Cod3rsGrowth.Testes
{
    public class EmpresaRepositorioMock : IRepositorioEmpresa
    {
        private readonly EmpresaSingleton _instanciaEmpresaSingleton = EmpresaSingleton.Instancia;
        private readonly EmpresaValidacao _empresaValidacao = new();
        //private readonly IValidator<Empresa> _empresaValidacao;

        public void Adicionar(Empresa empresa)

        {
            _empresaValidacao.ValidateAndThrow(empresa);
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