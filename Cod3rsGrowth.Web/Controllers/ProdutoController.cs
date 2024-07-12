using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Servico.Servicos;
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
        public IActionResult ObterPorId(int id) { throw new NotImplementedException(); }

        [HttpPost]
        public IActionResult Adicionar(Empresa empresa) { throw new NotImplementedException(); }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id) { throw new NotImplementedException(); }

        [HttpPut]
        public IActionResult Atualizar(Empresa empresa) { throw new NotImplementedException(); }

    }
}
