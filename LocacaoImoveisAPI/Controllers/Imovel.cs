using LocacaoImoveisAPI.Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastraImovel : ControllerBase
    {
        /// <summary>
        /// Busca todos os imóveis cadastrados na base.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetImoveis()
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
        /// Busca o registro de um único imóvel.
        /// </summary>
        [HttpGet("{idImovel}")]
        public async Task<IActionResult> GetImovel(int idImovel)
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
        /// Cria um novo registro de imóvel.
        /// </summary>
        [HttpPost]
        public IActionResult PostImovel([FromBody] RequestCadastroImovelDto dadosCadastroDtoPost)
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
        public async Task<IActionResult> UpdateImovel(int idUser, [FromBody] RequestCadastroImovelDto dadosCadastroDto)
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
        /// Deleta o registro de imóvel.
        /// </summary>
        [HttpDelete("{idUser}")]
        public IActionResult DeleteImovel(int ididImovelUser)
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
