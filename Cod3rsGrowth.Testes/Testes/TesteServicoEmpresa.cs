using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Singleton;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteServicoEmpresa : TesteBase
    {
        private readonly ServicoEmpresa _servicoEmpresa;

        public TesteServicoEmpresa()
        {
            _servicoEmpresa = ServiceProvider.GetService<ServicoEmpresa>()
                ?? throw new Exception($"Erro ao obter servico {nameof(ServicoEmpresa)}");
            EmpresaSingleton.Instancia.Clear();
        }

        [Fact]
        public void deve_retornar_o_objeto_esperado_no_metodo_obter_todos()
        {
            var listaEmpresa = CriarLista();
            var listaEmpresaRetornada = _servicoEmpresa.ObterTodos();
            Assert.Equivalent(listaEmpresa, listaEmpresaRetornada);
        }

        [Fact]
        public void deve_retornar_o_objeto_esperado_no_metodo_obter_por_id()
        {
            int id = 2;
            CriarLista();
            var empresaEsperada = new Empresa
            {
                Id = 2,
                RazaoSocial = "Heinz",
                CNPJ = "83748362748959",
                Ramo = EnumRamoDaEmpresa.Industria
            };
            var retornoEmpresa = _servicoEmpresa.ObterPorId(id);

            Assert.Equivalent(empresaEsperada, retornoEmpresa);
        }

        [Fact]
        public void dever_estourar_excecao_por_enviar_id_que_nao_existe()
        {
            var lista = CriarLista();
            int id = 4;
            Assert.Throws<Exception>(() => _servicoEmpresa.ObterPorId(id));
        }

        [Fact]
        public void deve_adicionar_um_nova_empresa_na_lista_singleton()
        {
            var empresaEsperada = new Empresa { Id = 5, RazaoSocial = "InventSoftwar", CNPJ = "12345678954366", Ramo = EnumRamoDaEmpresa.Servico };
            _servicoEmpresa.Adicionar(empresaEsperada);
            var empresaDoBanco = EmpresaSingleton.Instancia.Find(x=> x.Id == empresaEsperada.Id);
            Assert.Equivalent(empresaEsperada, empresaDoBanco);
        }

        [Fact]
        public void deve_estourar_uma_excecao_ao_mandar_um_cnpj_vazio()
        {
            var empresa = new Empresa { Id = 1, RazaoSocial = "EmpresaTestea", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _servicoEmpresa.Adicionar(empresa));
        }

        [Fact]
        public void deve_estourar_uma_excecao_ao_mandar_um_razaosocial_vazia()
        {
            var empresa = new Empresa { Id = 6, CNPJ = "27348926374839", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _servicoEmpresa.Adicionar(empresa));
        }

        [Fact]
        public void deve_verificar_se_a_mensagem_apos_estourar_uma_excecao_de_enviar_um_cnpj_vazio_esta_correta()
        {
            var empresa = new Empresa { Id = 1, RazaoSocial = "EmpresaTestea", Ramo = EnumRamoDaEmpresa.Servico };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoEmpresa.Adicionar(empresa));
            Assert.Equal("O campo CNPJ é obrigatorio", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_estourar_excecao_caso_enum_seja_vazio()
        {
            var empresa = new Empresa { Id = 6, RazaoSocial = "EmpresaTestea", CNPJ = "17384563927162" };
            Assert.Throws<FluentValidation.ValidationException>(() => _servicoEmpresa.Adicionar(empresa));
        }

        [Fact]
        public void deve_atualizar_um_objeto_escolhido_na_lista()
        {
            var listaRetornada = CriarLista();
            var empresa = new Empresa { Id = 2, RazaoSocial = "Heinz", CNPJ = "12345678954367", Ramo = EnumRamoDaEmpresa.Servico };
            _servicoEmpresa.Atualizar(empresa);
            var retornoEmpresa = EmpresaSingleton.Instancia.Where(x => x.Id == empresa.Id).FirstOrDefault();
            Assert.Equivalent(empresa, retornoEmpresa);
        }

        [Fact]
        public void deve_verificar_se_mandar_sem_razaosocial_vai_estourar_uma_excecao()
        {
            var listaRetornada = CriarLista();
            var empresa = new Empresa { Id = 3, CNPJ = "12345678954367", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _servicoEmpresa.Atualizar(empresa));
        }

        [Fact]
        public void deve_verificar_se_a_mensagem_apos_estourar_uma_excecao_de_enviar_um_razaosocial_vazio_no_metodo_atualizar_esta_correta()
        {
            var empresa = new Empresa { Id = 2, CNPJ = "93748374898123", Ramo = EnumRamoDaEmpresa.Servico };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _servicoEmpresa.Atualizar(empresa));
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

            _servicoEmpresa.Deletar(empresa.Id);
            Assert.DoesNotContain(EmpresaSingleton.Instancia, x => x == empresa);
        }

        [Fact]
        public void deve_retornar_o_objeto_correspondente_do_obtertodos_usando_filtro()
        {
            CriarLista();
            var listaEmpresa = new List<Empresa>
            {
                new Empresa
                {
                   Id = 1,
                   RazaoSocial = "InventSoftware",
                   CNPJ = "16274837465234",
                   Ramo = EnumRamoDaEmpresa.Servico
                }
            };
            var filtro = "inv";
            var objetoEmpresaRetornado = _servicoEmpresa.ObterTodos(new FiltroEmpresa { RazaoSocial = filtro });
            Assert.Equivalent(listaEmpresa, objetoEmpresaRetornado);
        }

        [Fact]
        public void deve_verificar_se_ao_mandar_um_filtro_invalido_ele_retorna_uma_lista_vazia()
        {
            CriarLista();
            var listaEmpresa = new List<Empresa> { };
            var filtro = "Teste";
            var tamanhoLista = 0;
            var objetoEmpresaRetornado = _servicoEmpresa.ObterTodos(new FiltroEmpresa { RazaoSocial = filtro });
            Assert.Equivalent(listaEmpresa, objetoEmpresaRetornado);
            Assert.Equal(tamanhoLista, objetoEmpresaRetornado.Count);
        }

        [Fact]
        public void deve_estourar_excecao_ao_mandar_id_que_nao_existe()
        {
            CriarLista();
            var empresa = new Empresa
            {
                Id = 10,
                RazaoSocial = "EmpresaTeste",
                CNPJ = "16274837465234",
                Ramo = EnumRamoDaEmpresa.Servico
            };
            var mensagemErro = Assert.Throws<Exception>(() => _servicoEmpresa.Atualizar(empresa));
        }

        [Fact]
        public void deve_estourar_uma_excecao_e_retornar_uma_mensagem_ao_tentar_atualizar_um_objeto_com_razaosocial_repetido()
        {
            CriarLista();
            var empresa = new Empresa
            {
                Id = 3,
                RazaoSocial = "InventSoftware",
                CNPJ = "12346754325678",
                Ramo = EnumRamoDaEmpresa.Servico
            };
            var mensagem = Assert.Throws<FluentValidation.ValidationException>(() => _servicoEmpresa.Atualizar(empresa));
            Assert.Equal("Essa Razão Social já existe", mensagem.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_atualizar_a_lista_usando_o_mesmo_nome_se_tiver_o_mesmo_id()
        {
            CriarLista();
            var empresa = new Empresa
            {
                Id = 1,
                RazaoSocial = "InventSoftware",
                CNPJ = "12346754325678",
                Ramo = EnumRamoDaEmpresa.Servico
            };
            _servicoEmpresa.Atualizar(empresa);
            var retornoEmpresa = EmpresaSingleton.Instancia.Find(x => x.Id == empresa.Id);
            Assert.Equivalent(empresa, retornoEmpresa);
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