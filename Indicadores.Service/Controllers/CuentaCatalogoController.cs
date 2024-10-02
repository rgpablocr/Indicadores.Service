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
    public class CuentaCatalogoController : ControllerBase
    {
        private CuentaCatalogoBL cuentaCatalogoBL;

        public CuentaCatalogoController(ICuentaCatalogoDA cuentaCatalogoDA)
        {
            this.cuentaCatalogoBL = new CuentaCatalogoBL(cuentaCatalogoDA);
        }

        [Authorize]
        [HttpPost]
        [Route("ListarCuentaCatalogo")]
        public async Task<IActionResult> ListarCuentaCatalogo()
        {
            try
            {
                var respuesta = await cuentaCatalogoBL.ListarCuentaCatalogo();

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
