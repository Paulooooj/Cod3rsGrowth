﻿using Cod3rsGrowth.Dominio.Entidades;
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
            _repositorioEmpresa.Adicionar(empresa);
        }

        public void Atualizar(Empresa empresa)
        {
            try
            {
                _empresaValidacao.ValidateAndThrow(empresa);
                _repositorioEmpresa.Atualizar(empresa);
            }
            catch (ValidationException ve)
            {
                throw new ValidationException(ve.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}. + {ex.StackTrace}.");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _repositorioEmpresa.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

            public Empresa ObterPorId(int id)
            {
                return _repositorioEmpresa.ObterPorId(id)
                        ?? throw new Exception($"Empresa com Id: {id} não encontrado");
            }

            public List<Empresa> ObterTodos(FiltroEmpresa? filtro = null)
            {
                return _repositorioEmpresa.ObterTodos(filtro);
            }
        }
    }