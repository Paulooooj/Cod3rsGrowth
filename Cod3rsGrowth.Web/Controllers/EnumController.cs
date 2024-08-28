using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Web.MetodosAuxiliares;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : Controller
    {
        [HttpGet]
        public IActionResult ObterDescricaoRamo()
        {
            var enumEmpresa = Enum.GetValues(typeof(EnumRamoDaEmpresa))
                .Cast<EnumRamoDaEmpresa>()
                .Select(x => new { key = (int)x, Descricao = DescricaoEnum.PegarDescricaoEnum(x)})
                .ToList();

            return Ok(enumEmpresa);
        }
    }
}
