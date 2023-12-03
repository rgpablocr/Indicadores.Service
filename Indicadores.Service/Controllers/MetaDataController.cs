using Indicadores.BL.Class;
using Indicadores.DA.Class;
using Indicadores.DA.Interface;
using Indicadores.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indicadores.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaDataController : ControllerBase
    {
        private MetaDataBL metaDataBL;

        public MetaDataController(IMetaDataDA metaDataDA)
        {
            this.metaDataBL = new MetaDataBL(metaDataDA);
        }


        [HttpPost]
        [Route("ListarMetadata")]
        public async Task<IActionResult> ListarMetadata()
        {
            try
            {
                var respuesta = await metaDataBL.ListarMetadata();

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("InsertarMetadata")]
        public async Task<IActionResult> InsertarMetadata([FromBody] MetaData metaData)
        {
            try
            {
                var respuesta = await metaDataBL.InsertarMetadata(metaData);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("EliminarMetadata")]
        public async Task<IActionResult> EliminarMetadata([FromBody] int idMetaData)
        {
            try
            {
                var respuesta = await metaDataBL.EliminarMetadata(idMetaData);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("ModificarMetadata")]
        public async Task<IActionResult> ModificarMetadata([FromBody] MetaData metaData)
        {
            try
            {
                var respuesta = await metaDataBL.ModificarMetadata(metaData);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("ConsultarMetadata")]
        public async Task<IActionResult> ConsultarMetadata([FromBody] int idMetaData)
        {
            try
            {
                var respuesta = await metaDataBL.ConsultarMetadata(idMetaData);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
