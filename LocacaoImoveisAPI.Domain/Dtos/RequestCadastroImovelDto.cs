using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoImoveisAPI.Domain.Dtos
{
    public class RequestCadastroImovelDto
    {
        public ImovelDto imovelDto { get; set; }
        public EnderecoDto enderecoDto { get; set; }
    }
}
