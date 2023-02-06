namespace LocacaoImoveisAPI.Domain.Model
{
    public class Endereco : BaseEntity
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int IdImovel { get; set; }
    }
}
