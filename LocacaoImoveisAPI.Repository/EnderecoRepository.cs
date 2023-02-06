using LocacaoImoveisAPI.Domain.Dtos;
using LocacaoImoveisAPI.Domain.Model;
using LocacaoImoveisAPI.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace LocacaoImoveisAPI.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        protected readonly DbContextOptions<Context> _DbOptions;
        protected readonly ConnStrings _connStrings;

        public EnderecoRepository(ConnStrings connStrings)
        {
            _connStrings = connStrings;
            _DbOptions = new DbContextOptionsBuilder<Context>().UseSqlServer(_connStrings.SqlConnectionString).Options;
        }

        public async Task<Endereco> GetEnderecoAsync(int idImovel)
        {
            using (var Db = new Context(_DbOptions))
            {
                return await Db.Enderecos.FirstOrDefaultAsync(p => p.ID == idImovel);
            }
        }

        public void InsertEnderecoAsync(Endereco endereco)
        {
            using (var Db = new Context(_DbOptions))
            {
                Db.Enderecos.Add(endereco);
                Db.SaveChangesAsync();
            }
        }

        public Endereco UpdateEndereco(Endereco endereco)
        {
            using (var Db = new Context(_DbOptions))
            {
                Db.Enderecos.Update(endereco);
                Db.SaveChanges();
            }
            return endereco;
        }

        public async Task DeleteEnderecoAsync(Endereco endereco)
        {
            using (var Db = new Context(_DbOptions))
            {
                Db.Enderecos.Remove(endereco);
                Db.SaveChanges();
            }
        }
    }
}
