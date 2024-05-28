﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteEmpresaRepositorioMock : TesteBase
    {
        private readonly IRepositorioEmpresa _repositorioEmpresa;

        public TesteEmpresaRepositorioMock()
        {
            _repositorioEmpresa = ServiceProvider.GetService<IRepositorioEmpresa>()
                ?? throw new Exception($"Erro ao obter servico {nameof(IRepositorioEmpresa)}");
        }
        [Fact]
        public void testar_se_o_obtertodos_retorna_o_valor_esperado()
        {
            var listaEmpresa = CriarLista();
            var listaEmpresaRetornada = _repositorioEmpresa.ObterTodos();
            Assert.Equivalent(listaEmpresa, listaEmpresaRetornada);
        }

        [Fact]
        public void testar_se_retorna_o_objeto_certo_por_id()
        {
            var listaEmpresa = CriarLista();
            var retornoEmpresa = _repositorioEmpresa.ObterPorId(2);
            Assert.Equivalent(listaEmpresa[1], retornoEmpresa);
        }

        [Fact]
        public void testar_um_id_que_não_existe()
        {
            var lista = CriarLista();
            Assert.Throws<Exception>(() => _repositorioEmpresa.ObterPorId(4));
        }

        [Fact]
        public void testa_validacao_do_id()
        {
            Empresa empresa = new Empresa {Id = 1, RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico};
            _repositorioEmpresa.Adicionar(empresa);
        }

        public List<Empresa> CriarLista()
        {
            var listaEmpresa = new List<Empresa>
            {
                new Empresa
                {
                   Id = 1,
                   RazaoSocial = "InventSoftware",
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
                   RazaoSocial = "LojasAmericanas",
                   CNPJ = "543216789",
                   Ramo = EnumRamoDaEmpresa.Comercio
                },
            };
            var listaDeEmpresasSingleton = EmpresaSingleton.Instancia;
            listaDeEmpresasSingleton.AddRange(listaEmpresa);
            return listaEmpresa;
        }
    }
}