using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.Servicos
{
    public class ServicoEmpresa
    {
        private readonly IValidator<Empresa> _empresaValidacao;
        private readonly IRepositorioEmpresa _repositorioEmpresa;

        public ServicoEmpresa(IValidator<Empresa> empresavalidacao, IRepositorioEmpresa repositorioEmpresa)
        {
            _empresaValidacao = empresavalidacao;
            _repositorioEmpresa = repositorioEmpresa;
        }

        public void Adicionar(Empresa empresa)
        {
            _empresaValidacao.ValidateAndThrow(empresa);
            _repositorioEmpresa.Adicionar(empresa);
        }

        public void Atualizar(Empresa empresa)
        {
            _empresaValidacao.ValidateAndThrow(empresa);
            _repositorioEmpresa.Atualizar(empresa);
        }

        public void Deletar(int id)
        {
            _repositorioEmpresa.Deletar(id);
        }

        public Empresa ObterPorId(int id)
        {
            var empresa = _repositorioEmpresa.ObterPorId(id);
            return empresa;
        }

        public List<Empresa> ObterTodos(FiltroEmpresa? filtro = null)
        {
            var listaEmpresa = _repositorioEmpresa.ObterTodos(filtro);
            return listaEmpresa;
        }
    }
}