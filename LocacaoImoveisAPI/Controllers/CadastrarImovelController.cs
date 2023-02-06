using LocacaoImoveisAPI.Domain.Dtos;
using LocacaoImoveisAPI.Domain.Model;
using LocacaoImoveisAPI.Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoImoveisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastrarImovelController : ControllerBase
    {
        private readonly IService _service;
        public CadastrarImovelController(IService service)
        {
            _service = service;
        }

        /// <summary>
        /// Busca o imóvel cadastrado na base por seu ID.
        /// </summary>
        [HttpGet("{idImovel}")]
        public IActionResult GetImovel(int idImovel)
        {
            try
            {
                var result = _service.GetImovelAsync(idImovel).Result;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca todos os imóveis cadastrados na base.
        /// </summary>
        [HttpGet]
        public IActionResult GetImoveis()
        {
            try
            {
                var result = _service.GetAllImovelAsync().Result;
                return Ok(result);
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
                _service.CadastrarImovel(dadosCadastroDtoPost);
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
        [HttpPut]
        public IActionResult UpdateImovel([FromBody] RequestCadastroImovelDto dadosCadastroDtoPost)
        {
            try
            {
                _service.AtualizarImovel(dadosCadastroDtoPost);
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
        public IActionResult DeleteImovel(int idImovel)
        {
            try
            {
                _service.DeletarImovel(idImovel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
