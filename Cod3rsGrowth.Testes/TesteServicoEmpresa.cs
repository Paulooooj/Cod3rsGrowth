using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

namespace Cod3rsGrowth.Testes
{
    public class TesteServicoEmpresa : TesteBase
    {
        private readonly IServicoEmpresa _servicoEmpresa;
        public TesteServicoEmpresa()
        {
            _servicoEmpresa = ServiceProvider.GetService<IServicoEmpresa>()
                ?? throw new Exception($"Erro ao obter servico {nameof(IServicoEmpresa)}");
        }
        [Fact]
        public void testar_se_o_que_esta_retornando_da_lista__em_obter_todos_e_igual_da_lista_de_teste()
        {
           var valorEsperado = new List<Empresa> {
           new Empresa { Id = 1, RazaoSocial = "InventSoftware", CNPJ = "123456789", Ramo = EnumRamoDaEmpresa.Servico },
           new Empresa { Id = 2, RazaoSocial = "EmpresaTeste", CNPJ = "987654321", Ramo = EnumRamoDaEmpresa.Industria },
           new Empresa { Id = 3, RazaoSocial = "TesteEmpresa", CNPJ = "543216789", Ramo = EnumRamoDaEmpresa.Comercio },
        };
            var resultadoRetornado = _servicoEmpresa.ObterTodos();
            Assert.Equivalent(resultadoRetornado, valorEsperado);
        }
        [Fact]
        public void testar_se_tem_na_lista_o_valor_do_id_mandado()
        {
            int[] vetorIdEsperado = {1, 2, 3, 4};
            var resultadoRetornado = _servicoEmpresa.ObterTodos();
            Assert.Equal(resultadoRetornado[0].Id, vetorIdEsperado[0]);
            Assert.Equal(resultadoRetornado[1].Id, vetorIdEsperado[1]);
            Assert.Equal(resultadoRetornado[2].Id, vetorIdEsperado[2]);
        }
        [Fact]
        public void testar_se_a_lista_e_do_tipo_empresa()
        {
            var resultadoRetornado = _servicoEmpresa.ObterTodos();
            var verificarTipoLista = resultadoRetornado.GetType().Equals(typeof(List<Empresa>));
            Assert.True(verificarTipoLista);
        }
        [Fact]

        public void remover_item_por_id()
        {
            var listaRemovida = _servicoEmpresa.Remover(1);
            var tamanhoAtualList = listaRemovida.Count();

            Assert.Equal(tamanhoAtualList, 2);
            
        }

    }
}