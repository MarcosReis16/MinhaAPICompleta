using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{

    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Fornecedor fornecedor)
        {
            //Validar o estado da entidade
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return false;

            //Valida se o documento está igual.
            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado");
                return false;
            }

            return await _fornecedorRepository.Adicionar(fornecedor) > 0;
        }

        public async Task<bool> Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return false;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result
                .Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return false;
            }

            return await _fornecedorRepository.Atualizar(fornecedor) > 0;
        }

        public async Task<bool> AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return false;

            return await _enderecoRepository.Atualizar(endereco) > 0;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_fornecedorRepository.ObterFornecedorProdutosEnderecos(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return false;
            }

            return await _fornecedorRepository.Remover(id) > 0;

        }
        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
