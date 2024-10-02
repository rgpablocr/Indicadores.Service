using Indicadores.BL.Class;
using Indicadores.DA.Interface;
using Indicadores.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indicadores.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosValorController : ControllerBase
    {
        private PosValorBL posValorBL;

        public PosValorController(IPosValorDA posValorDA)
        {
            this.posValorBL = new PosValorBL(posValorDA);
        }

        [Authorize]
        [HttpPost]
        [Route("ListarPosValores")]
        public async Task<IActionResult> ListarPosValores()
        {
            try
            {
                var respuesta = await posValorBL.ListarPosValores();

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("InsertarPosValor")]
        public async Task<IActionResult> InsertarPosValor([FromBody] PosValor posValor)
        {
            try
            {
                var respuesta = await posValorBL.InsertarPosValor(posValor);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("ModificarPosValor")]
        public async Task<IActionResult> ModificarPosValor([FromBody] PosValor posValor)
        {
            try
            {
                var respuesta = await posValorBL.ModificarPosValor(posValor);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("EliminarPosValor")]
        public async Task<IActionResult> EliminarPosValor([FromBody] int idPosValor)
        {
            try
            {
                var respuesta = await posValorBL.EliminarPosValor(idPosValor);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
