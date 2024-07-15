using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly ServicoProduto _servicoProduto;

        public ProdutoController(ServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroProduto produto) 
        {
            var listaProduto = _servicoProduto.ObterTodos(produto);
            return Ok(listaProduto);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id) 
        {
            var produto = _servicoProduto.ObterPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Produto produto) 
        {
            _servicoProduto.Adicionar(produto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id) 
        {
            _servicoProduto.Deletar(id);
            return NoContent();
        }

        [HttpPatch]
        public IActionResult Atualizar([FromBody] Produto produto)
        {
            _servicoProduto.Atualizar(produto);
            return NoContent();
        }

    }
}
