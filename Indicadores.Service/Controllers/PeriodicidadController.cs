using Indicadores.BL.Class;
using Indicadores.DA.Interface;
using Indicadores.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indicadores.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodicidadController : ControllerBase
    {

        private PeriodicidadBL periodicidadBL;
        public PeriodicidadController(IPeriodicidadDA periodicidadDA)
        {
            this.periodicidadBL = new PeriodicidadBL(periodicidadDA);
        }

        [Authorize]
        [HttpPost]
        [Route("ListarPeriodicidad")]
        public async Task<IActionResult> ListarPeriodicidad()
        {
            try
            {
                var respuesta = await periodicidadBL.ListarPeriodicidad();

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
