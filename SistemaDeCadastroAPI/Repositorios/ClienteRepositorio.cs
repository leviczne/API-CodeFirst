using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroAPI.Data;
using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Repositorios.Intefaces;

namespace SistemaDeCadastroAPI.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DB_testeContext _dbContext;

        public ClienteRepositorio( DB_testeContext db_TesteContext)
        {
            _dbContext = db_TesteContext;
        }

        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

       
    }
}
