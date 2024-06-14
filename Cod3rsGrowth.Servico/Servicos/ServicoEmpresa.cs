using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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

            try
            {
                _repositorioEmpresa.Atualizar(empresa);
            }
            catch (Exception)
            {
                throw new Exception($"Empresa com Id: {empresa.Id} não encontrado");
            }
        }

        public void Deletar(int id)
        {
            _repositorioEmpresa.Deletar(id);
        }

        public Empresa ObterPorId(int id)
        {
            return _repositorioEmpresa.ObterPorId(id);
        }

        public List<Empresa> ObterTodos(FiltroEmpresa? filtro = null)
        {
            return _repositorioEmpresa.ObterTodos(filtro);
        }
    }
}