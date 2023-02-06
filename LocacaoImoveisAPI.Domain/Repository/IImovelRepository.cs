using LocacaoImoveisAPI.Domain.Dtos;
using LocacaoImoveisAPI.Domain.Model;

namespace LocacaoImoveisAPI.Domain.Repository
{
    public interface IImovelRepository
    {
        Task<List<Imovel>> GetAllImovelAsync();
        Task<Imovel> GetImovelAsync(int idImovel);
        int InsertImovelAsync(Imovel imovel);
        int UpdateImovel(Imovel imovel);
        Task DeleteImovelAsync(Imovel imovel);
    }
}

