﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
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
            EmpresaSingleton.Instancia.Clear();
        }

        [Fact]
        public void deve_retornar_o_objeto_esperado_no_metodo_obter_todos()
        {
            var listaEmpresa = CriarLista();
            var listaEmpresaRetornada = _repositorioEmpresa.ObterTodos();
            Assert.Equivalent(listaEmpresa, listaEmpresaRetornada);
        }

        [Fact]
        public void deve_retornar_o_objeto_esperado_no_metodo_obter_por_id()
        {
            var listaEmpresa = CriarLista();
            var retornoEmpresa = _repositorioEmpresa.ObterPorId(2);
            Assert.Equivalent(listaEmpresa[1], retornoEmpresa);
        }

        [Fact]
        public void dever_estourar_excecao_por_enviar_id_que_nao_existe()
        {
            var lista = CriarLista();
            Assert.Throws<Exception>(() => _repositorioEmpresa.ObterPorId(4));
        }

        [Fact]
        public void deve_adicionar_um_nova_empresa_na_lista_singleton()
        {
            var empresa = new Empresa {Id = 5, RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            _repositorioEmpresa.Adicionar(empresa);
            var retornoEmpresa = EmpresaSingleton.Instancia.FirstOrDefault() 
                ?? throw new Exception($"O ID {empresa.Id} não foi encontrado"); ;
            Assert.Equivalent(empresa, retornoEmpresa);
        }

        [Fact]
        public void deve_estourar_uma_excecao_ao_mandar_um_id_vazio()
        {
            var empresa = new Empresa {RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
        }

        [Fact]
        public void deve_estourar_uma_excecao_ao_mandar_um_razaosocial_vazia()
        {
            var empresa = new Empresa { Id = 6, CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
        }


        [Fact]
        public void deve_verificar_se_a_mensagem_apos_estourar_uma_excecao_de_enviar_um_id_vazio_esta_correta()
        {
            var empresa = new Empresa { RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
            Assert.Equal("O campo id é obrigatorio", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void  deve_estourar_excecao_caso_enum_seja_vazio()
        {
            var empresa = new Empresa { Id = 6, RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344"};
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
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