using LocacaoImoveisAPI.Domain.Dtos;

namespace LocacaoImoveisAPI.Domain.Service
{
    public interface IHttpFactory
    {
        Task<ResponseBuscaEnderecoPorCepDto> BuscarEnderecoPorCep(string cep);
    }
}
