using LocacaoImoveisAPI.Domain.Dtos;
using LocacaoImoveisAPI.Domain.Model;
using LocacaoImoveisAPI.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace LocacaoImoveisAPI.Repository
{
    public class ImovelRepository : IImovelRepository
    {
        protected readonly DbContextOptions<Context> _DbOptions;
        protected readonly ConnStrings _connStrings;

        public ImovelRepository(ConnStrings connStrings)
        {
            _connStrings = connStrings;
            _DbOptions = new DbContextOptionsBuilder<Context>().UseSqlServer(_connStrings.SqlConnectionString).Options;
        }

        public async Task<List<Imovel>> GetAllImovelAsync()
        {
            using (var Db = new Context(_DbOptions))
            {
                List<Imovel> imoveis = Db.Imoveis.ToList();
                return imoveis;
            }
        }

        public async Task<Imovel> GetImovelAsync(int idImovel)
        {
            using (var Db = new Context(_DbOptions))
            {
                var imovel = await Db.Imoveis.FirstOrDefaultAsync(p => p.ID == idImovel);

                return imovel;
            }
        }

        public int InsertImovelAsync(Imovel imovel)
        {
            using (var Db = new Context(_DbOptions))
            {
                Db.Imoveis.Add(imovel);
                Db.SaveChangesAsync();
            }
            return imovel.ID;
        }

        public int UpdateImovel(Imovel imovel)
        {
            using (var Db = new Context(_DbOptions))
            {
                Db.Imoveis.Update(imovel);
                Db.SaveChanges();
            }
            return imovel.ID;
        }

        public async Task DeleteImovelAsync(Imovel imovel)
        {
            using (var Db = new Context(_DbOptions))
            {
                Db.Imoveis.Remove(imovel);
                Db.SaveChanges();
            }
        }
    }
}

