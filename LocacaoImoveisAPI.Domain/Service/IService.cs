using LocacaoImoveisAPI.Domain.Dtos;
using LocacaoImoveisAPI.Domain.Model;

namespace LocacaoImoveisAPI.Domain.Service
{
    public interface IService
    {
        Task<List<Imovel>> GetAllImovelAsync();
        Task<RequestImovelEndereco> GetImovelAsync(int idImovel);
        void CadastrarImovel(RequestCadastroImovelDto requestCadastroImovelDto);
        void AtualizarImovel(RequestCadastroImovelDto requestCadastroImovelDto);
        Task DeletarImovel(int idImovel);

        Task<ResponseBuscaEnderecoPorCepDto> PesquisaCep(string cep);
    }
}
