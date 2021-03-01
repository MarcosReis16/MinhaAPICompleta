using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context)
        {

        }
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await _db.Fornecedores
                .AsNoTracking()
                .Include(f => f.Endereco)
                .FirstAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEnderecos(Guid id)
        {
            return await _db.Fornecedores
                .AsNoTracking()
                .Include(f => f.Endereco)
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
