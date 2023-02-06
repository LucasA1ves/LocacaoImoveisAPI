using LocacaoImoveisAPI.Domain.Dtos;
using LocacaoImoveisAPI.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscaCepController : ControllerBase
    {
        private readonly IService _service;
        public BuscaCepController(IService service)
        {
            _service = service;
        }
        /// <summary>
        /// Busca dados correspondentes de um cep.
        /// </summary>
        [HttpGet("{cep}")]
        public async Task<IActionResult> PesquisaCep(string cep)
        {
            try
            {
                var result = _service.PesquisaCep(cep);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
