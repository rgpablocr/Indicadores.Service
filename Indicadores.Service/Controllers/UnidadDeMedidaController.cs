using Indicadores.BL.Class;
using Indicadores.DA.Class;
using Indicadores.DA.Interface;
using Indicadores.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indicadores.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadDeMedidaController : ControllerBase
    {

        private UnidadDeMedidaBL unidadBL;

        public UnidadDeMedidaController(IUnidadDeMedidaDA unidadDA)
        {
            this.unidadBL = new UnidadDeMedidaBL(unidadDA);
        }

        [Authorize]
        [HttpPost]
        [Route("ListarUnidadesDeMedida")]
        public async Task<IActionResult> ListarUnidadMedida()
        {
            try
            {
                var respuesta = await unidadBL.ListarUnidadMedida();

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("InsertarUnidadDeMedida")]
        public async Task<IActionResult> InsertarUnidadMedida([FromBody] UnidadMedida unidadMedida)
        {
            try
            {
                var respuesta = await unidadBL.InsertarUnidadMedida(unidadMedida);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("ModificarUnidadMedida")]
        public async Task<IActionResult> ModificarUnidadMedida([FromBody] UnidadMedida unidadMedida)
        {
            try
            {
                var respuesta = await unidadBL.ModificarUnidadMedida(unidadMedida);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("EliminarUnidadMedida")]
        public async Task<IActionResult> EliminarUnidadMedida([FromBody] int idUnidadMedida)
        {
            try
            {
                var respuesta = await unidadBL.EliminarUnidadMedida(idUnidadMedida);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

