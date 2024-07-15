using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Filtros;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        public EmpresaController(ServicoEmpresa servicoEmpresa)
        {
            _servicoEmpresa = servicoEmpresa;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] FiltroEmpresa filtro) 
        {
            var listaDeEmpresas =_servicoEmpresa.ObterTodos(filtro);
            return Ok(listaDeEmpresas);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id) 
        {
            var empresa = _servicoEmpresa.ObterPorId(id);
            return Ok(empresa);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Empresa empresa) 
        { 
            _servicoEmpresa.Adicionar(empresa);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id) 
        {
            _servicoEmpresa.Deletar(id);
            return NoContent();
        }

        [HttpPatch]
        public IActionResult Atualizar([FromBody] Empresa empresa) 
        {
            _servicoEmpresa.Atualizar(empresa);
            return NoContent();
        }

    }
}
