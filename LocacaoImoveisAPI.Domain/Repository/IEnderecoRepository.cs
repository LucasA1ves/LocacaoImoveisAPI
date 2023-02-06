using LocacaoImoveisAPI.Domain.Model;

namespace LocacaoImoveisAPI.Domain.Repository
{
    public interface IEnderecoRepository
    {
        Task<Endereco> GetEnderecoAsync(int idImovel);
        Endereco UpdateEndereco(Endereco endereco);
        Task DeleteEnderecoAsync(Endereco endereco);
        void InsertEnderecoAsync(Endereco endereco);
    }
}
