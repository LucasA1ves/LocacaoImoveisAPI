namespace LocacaoImoveisAPI.Domain.Model
{
    public class Imovel : BaseEntity
    {
        public string Nome { get; set; }
        public bool isAlocado { get; set; }
        public string Tipo { get; set; }
    }
}
