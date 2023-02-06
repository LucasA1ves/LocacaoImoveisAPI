using LocacaoImoveisAPI.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Endereco : ControllerBase
    {
        /// <summary>
        /// Busca o registro de um único endereço através do id do imóvel.
        /// </summary>
        [HttpGet("{idImovel}")]
        public async Task<IActionResult> GetEndereco(int idImovel)
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

        /// <summary>
        /// Cria um novo registro de endereço.
        /// </summary>
        [HttpPost]
        public IActionResult PostEndereco([FromBody] RequestCadastroImovelDto dadosCadastroDtoPost)
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

        /// <summary>
        /// Atualiza o registro de um imóvel.
        /// </summary>
        [HttpPut("{idUser}")]
        public async Task<IActionResult> UpdateEndereco(int idUser, [FromBody] RequestCadastroImovelDto dadosCadastroDto)
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
