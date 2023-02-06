using LocacaoImoveisAPI.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscaCep : ControllerBase
    {
        /// <summary>
        /// Busca dados correspondentes de um cep.
        /// </summary>
        [HttpGet("{cep}")]
        public async Task<IActionResult> PesquisaCep(string cep)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
