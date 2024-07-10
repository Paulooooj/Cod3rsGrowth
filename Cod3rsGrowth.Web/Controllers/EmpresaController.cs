using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Microsoft.AspNetCore.Http;
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
        public IActionResult ObterTodos() {throw new NotImplementedException();}

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id) { throw new NotImplementedException();}

        [HttpPost]
        public IActionResult Adicionar(Empresa empresa) { throw new NotImplementedException();}

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id) { throw new NotImplementedException();}

        [HttpPut]
        public IActionResult Atualizar(Empresa empresa) { throw new NotImplementedException();}

    }
}
