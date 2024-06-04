using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using FluentValidation;

namespace Cod3rsGrowth.Testes
{
    public class EmpresaRepositorioMock : IRepositorioEmpresa
    {
        private readonly EmpresaSingleton _instanciaEmpresaSingleton;
        private readonly IValidator<Empresa> _empresaValidacao;

        public EmpresaRepositorioMock(IValidator<Empresa> empresavalidacao)
        {
            _instanciaEmpresaSingleton = EmpresaSingleton.Instancia;
            _empresaValidacao = empresavalidacao;
        }

        public void Adicionar(Empresa empresa)
        {
            _empresaValidacao.ValidateAndThrow(empresa);
            _instanciaEmpresaSingleton.Add(empresa);
        }

        public void Atualizar(Empresa empresaAtualizada)
        {
            _empresaValidacao.ValidateAndThrow(empresaAtualizada);
            var verificacaoSeTemID = _instanciaEmpresaSingleton.Find(x => x.Id == empresaAtualizada.Id) 
                ?? throw new Exception($"Empresa com Id: {empresaAtualizada.Id} não encontrado"); 
            var posicao = _instanciaEmpresaSingleton.FindIndex(x => x.Id == empresaAtualizada.Id);
            _instanciaEmpresaSingleton[posicao] = empresaAtualizada;
        }

        public void Deletar(int id)
        {
            var objetoASerRemovido = _instanciaEmpresaSingleton.Find(x => x.Id == id)
                ?? throw new Exception($"Empresa com Id: {id} não encontrado");
            _instanciaEmpresaSingleton.Remove(objetoASerRemovido);
        }

        public Empresa ObterPorId(int id)
        {
            var empresa = _instanciaEmpresaSingleton.Where(x => x.Id == id).FirstOrDefault()
                ?? throw new Exception($"Empresa com Id: {id} não encontrado");
            return empresa;
        }

        public List<Empresa> ObterTodos()
        {
            return _instanciaEmpresaSingleton;
        }
    }
}