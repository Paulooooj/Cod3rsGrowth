using Cod3rsGrowth.Dominio.Entidades;
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
            var empresa = new Empresa { Id = 5, RazaoSocial = "EmpresaTestea", CNPJ = "12345678954366", Ramo = EnumRamoDaEmpresa.Servico };
            _repositorioEmpresa.Adicionar(empresa);
            var retornoEmpresa = EmpresaSingleton.Instancia.FirstOrDefault();
            Assert.Equivalent(empresa, retornoEmpresa);
        }

        [Fact]
        public void deve_estourar_uma_excecao_ao_mandar_um_cnpj_vazio()
        {
            var empresa = new Empresa { Id = 1, RazaoSocial = "EmpresaTestea", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
        }

        [Fact]
        public void deve_estourar_uma_excecao_ao_mandar_um_razaosocial_vazia()
        {
            var empresa = new Empresa { Id = 6, CNPJ = "27348926374839", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
        }

        [Fact]
        public void deve_verificar_se_a_mensagem_apos_estourar_uma_excecao_de_enviar_um_cnpj_vazio_esta_correta()
        {
            var empresa = new Empresa { Id = 1, RazaoSocial = "EmpresaTestea", Ramo = EnumRamoDaEmpresa.Servico };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
            Assert.Equal("O campo CNPJ é obrigatorio", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_estourar_excecao_caso_enum_seja_vazio()
        {
            var empresa = new Empresa { Id = 6, RazaoSocial = "EmpresaTestea", CNPJ = "17384563927162" };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
        }

        [Fact]
        public void deve_atualizar_um_objeto_escolhido_na_lista()
        {
            var listaRetornada = CriarLista();
            var empresa = new Empresa { Id = 2, RazaoSocial = "EstudioMusical", CNPJ = "12345678954367", Ramo = EnumRamoDaEmpresa.Servico };
            _repositorioEmpresa.Atualizar(empresa);
            var retornoEmpresa = EmpresaSingleton.Instancia.Where(x => x.Id == empresa.Id).FirstOrDefault();
            Assert.Equivalent(empresa, retornoEmpresa);
        }

        [Fact]
        public void deve_verificar_se_mandar_sem_razaosocial_vai_estourar_uma_excecao()
        {
            var listaRetornada = CriarLista();
            var empresa = new Empresa { Id = 3, CNPJ = "12345678954367", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Atualizar(empresa));
        }

        [Fact]
        public void deve_verificar_se_a_mensagem_apos_estourar_uma_excecao_de_enviar_um_razaosocial_vazio_no_metodo_atualizar_esta_correta()
        {
            var empresa = new Empresa { Id = 2, CNPJ = "93748374898123", Ramo = EnumRamoDaEmpresa.Servico };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Atualizar(empresa));
            Assert.Equal("O campo Razão Social é obrigatorio", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_remover_um_objeto_escolhido_na_lista()
        {
            CriarLista();
            var empresa = new Empresa
            {
                Id = 1,
                RazaoSocial = "InventSoftware",
                CNPJ = "16274837465234",
                Ramo = EnumRamoDaEmpresa.Servico
            };

            _repositorioEmpresa.Deletar(empresa.Id);
            Assert.DoesNotContain(EmpresaSingleton.Instancia, x => x == empresa);
        }

        [Fact]
        public void dever_estourar_excecao_ao_mandar_um_id_invalido()
        {
            CriarLista();
            int idInvalido = 5;
            Assert.Throws<Exception>(() => _repositorioEmpresa.Deletar(idInvalido));
        }

        [Fact]
        public void deve_verificar_se_ao_mandar_um_id_invalido_retorna_a_mensagem_correta()
        {
            CriarLista();
            int idInvalido = 5;
            var mensagemDeErro = Assert.Throws<System.Exception>(() => _repositorioEmpresa.Deletar(idInvalido));
            Assert.Equal($"Empresa com Id: {idInvalido} não encontrado", mensagemDeErro.Message);
        }

        public List<Empresa> CriarLista()
        {
            var listaEmpresa = new List<Empresa>
            {
                new Empresa
                {
                   Id = 1,
                   RazaoSocial = "InventSoftware",
                   CNPJ = "16274837465234",
                   Ramo = EnumRamoDaEmpresa.Servico
                },
                new Empresa
                {
                   Id = 2,
                   RazaoSocial = "Heinz",
                   CNPJ = "83748362748959",
                   Ramo = EnumRamoDaEmpresa.Industria
                },
                new Empresa
                {
                   Id = 3,
                   RazaoSocial = "LojasAmericanas",
                   CNPJ = "17238765364783",
                   Ramo = EnumRamoDaEmpresa.Comercio
                },
            };
            var listaDeEmpresasSingleton = EmpresaSingleton.Instancia;
            listaDeEmpresasSingleton.AddRange(listaEmpresa);
            return listaEmpresa;
        }
    }
}