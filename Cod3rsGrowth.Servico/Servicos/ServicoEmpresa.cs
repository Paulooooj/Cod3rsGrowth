using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using System;
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
        }

        public void Atualizar(Empresa empresa)
        {
            try
            {
                _empresaValidacao.ValidateAndThrow(empresa);
                _repositorioEmpresa.Atualizar(empresa);
            }
            catch (FluentValidation.ValidationException ve)
            {
                throw new ValidationException(ve.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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