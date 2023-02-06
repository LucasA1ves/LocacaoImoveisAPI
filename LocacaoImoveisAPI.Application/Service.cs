using LocacaoImoveisAPI.Domain.Dtos;
using LocacaoImoveisAPI.Domain.Model;
using LocacaoImoveisAPI.Domain.Repository;
using LocacaoImoveisAPI.Domain.Service;

namespace LocacaoImoveisAPI.Application
{
    public class Service : IService
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IHttpFactory _httpFactory;


        public Service(IImovelRepository imovelRepository, IEnderecoRepository enderecoRepository, IHttpFactory httpFactory)
        {
            _imovelRepository = imovelRepository;
            _enderecoRepository = enderecoRepository;
            _httpFactory = httpFactory;
        }

        //Imovel

        public async Task<RequestImovelEndereco> GetImovelAsync(int idImovel)
        {
            try
            {
                var imovel = await _imovelRepository.GetImovelAsync(idImovel);
                var endereco = await _enderecoRepository.GetEnderecoAsync(idImovel);

                return new RequestImovelEndereco()
                {
                    imovel = imovel,
                    endereco = endereco
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Imovel>> GetAllImovelAsync()
        {
            try
            {
                return await _imovelRepository.GetAllImovelAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CadastrarImovel(RequestCadastroImovelDto requestCadastroImovelDto)
        {
            try
            {
                int idImovel = _imovelRepository.InsertImovelAsync(ImovelDtoToImovel(requestCadastroImovelDto.imovelDto));
                _enderecoRepository.InsertEnderecoAsync(EnderecoDtoToEndereco(requestCadastroImovelDto.enderecoDto, idImovel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarImovel(RequestCadastroImovelDto requestCadastroImovelDto)
        {
            try
            {
                int idImovel = _imovelRepository.UpdateImovel(ImovelDtoToImovel(requestCadastroImovelDto.imovelDto));
                _enderecoRepository.UpdateEndereco(EnderecoDtoToEndereco(requestCadastroImovelDto.enderecoDto, idImovel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Apaga endereço e imovel
        public async Task DeletarImovel(int idImovel)
        {
            try
            {
                var imovel = _imovelRepository.GetImovelAsync(idImovel).Result;
                var endereco = _enderecoRepository.GetEnderecoAsync(idImovel).Result;

                await _imovelRepository.DeleteImovelAsync(imovel);
                await _enderecoRepository.DeleteEnderecoAsync(endereco);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        //Endereço

        public async Task<Endereco> GetEnderecoAsync(int idImovel)
        {
            try
            {
                return await _enderecoRepository.GetEnderecoAsync(idImovel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Pesquisa Cep
        public async Task<ResponseBuscaEnderecoPorCepDto> PesquisaCep(string cep)
        {
            try
            {
                var result = await _httpFactory.BuscarEnderecoPorCep(cep);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private Imovel ImovelDtoToImovel(ImovelDto imovelDto)
        {
            return new Imovel()
            {
                isAlocado = imovelDto.isAlocado,
                Nome = imovelDto.Nome,
                Tipo = imovelDto.Tipo
            };
        }

        private Endereco EnderecoDtoToEndereco(EnderecoDto enderecoDto, int idImovel)
        {
            var result = _httpFactory.BuscarEnderecoPorCep(enderecoDto.Cep).Result;
            return new Endereco()
            {
                Rua = result.logradouro,
                Bairro = result.bairro,
                Numero = enderecoDto.Numero,
                Cidade = result.localidade,
                Estado = result.uf,
                Cep = enderecoDto.Cep,
                IdImovel = idImovel
            };
        }
    }
}