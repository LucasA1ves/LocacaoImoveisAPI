using LocacaoImoveisAPI.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoImoveisAPI.Domain.Dtos
{
    public class RequestImovelEndereco
    {
        public Endereco endereco { get; set; }
        public Imovel imovel { get; set; }
    }
}
