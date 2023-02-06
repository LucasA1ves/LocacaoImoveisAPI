using LocacaoImoveisAPI.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace LocacaoImoveisAPI.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Imovel> Imoveis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin_General_CP1_CI_AS");

            modelBuilder.Entity<Imovel>(entity =>
            {
                entity.ToTable("imovel");

                entity.HasKey(p => p.ID);

                entity.Property(p => p.Nome).IsRequired().HasMaxLength(255);

                entity.Property(p => p.isAlocado).IsRequired().HasColumnType("INT"); ;

                entity.Property(p => p.Tipo).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.HasKey(p => p.ID);

                entity.Property(p => p.Rua).IsRequired().HasMaxLength(255);

                entity.Property(p => p.Numero).IsRequired().HasColumnType("INT");

                entity.Property(p => p.Bairro).IsRequired().HasMaxLength(100);

                entity.Property(p => p.Cidade).IsRequired().HasMaxLength(100);

                entity.Property(p => p.Cep).IsRequired().HasMaxLength(10);

                entity.Property(p => p.IdImovel).IsRequired().HasColumnType("INT");
            });
        }
    }
}
