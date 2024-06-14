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
            var resultado = _empresaValidacao.Validate(empresa, options => options.IncludeRuleSets("Adicionar", "default"));
            if (!resultado.IsValid)
            {
                throw new ValidationException(resultado.Errors);
            }
            _repositorioEmpresa.Adicionar(empresa);
        }

        public void Atualizar(Empresa empresa)
        {
            _empresaValidacao.ValidateAndThrow(empresa);

            try
            {
                _repositorioEmpresa.Atualizar(empresa);
            }
            catch (Exception e)
            {
                if (e.Message.StartsWith("Index was out of rang"))
                {
                    throw new Exception($"Empresa com Id: {empresa.Id} não encontrado");
                }
                Console.WriteLine("Erro: " + e.Message);
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