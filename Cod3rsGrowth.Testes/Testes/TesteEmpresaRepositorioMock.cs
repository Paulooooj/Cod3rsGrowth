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
        public void testa_verificar_se_esta_sendo_adicionado_um_novo_objeto_no_metodo_adicionar()
        {
            var empresa = new Empresa {Id = 5, RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            _repositorioEmpresa.Adicionar(empresa);
            var retornoEmpresa = EmpresaSingleton.Instancia.Where(x => x.Id == empresa.Id).FirstOrDefault() 
                ?? throw new Exception($"O ID {empresa.Id} não foi encontrado"); ;
            Assert.Equivalent(empresa, retornoEmpresa);
        }

        [Fact]
        public void _testar_se_enviar_o_id_vazio_no_objeto_o_adicionar_vai_funcionar_ou_vai_aconter_erro()
        {
            var empresa = new Empresa {RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
        }

        [Fact]
        public void _testar_se_enviar_o_id_vazio_a_mensagem_do_erro_vai_ser_igual_a_esperada()
        {
            var empresa = new Empresa { RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioEmpresa.Adicionar(empresa));
            Assert.Equal("O campo id é obrigatorio", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void _testar_se_enviar_o_razaosocial_vazio_no_objeto_o_adicionar_vai_funcionar_ou_vai_aconter_erro()
        {
            var empresa = new Empresa { Id = 6, CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
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