using Indicadores.BL.Class;
using Indicadores.DA.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indicadores.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private EstadoBL estadoBL;

        public EstadoController(IEstadoDA estadoDA)
        {
            this.estadoBL = new EstadoBL(estadoDA);
        }

        [Authorize]
        [HttpPost]
        [Route("ListarEstado")]
        public async Task<IActionResult> ListarEstado()
        {
            try
            {
                var respuesta = await estadoBL.ListarEstado();

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
