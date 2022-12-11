using SistemaDeCadastroAPI.Models;

namespace SistemaDeCadastroAPI.Repositorios.Intefaces
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> Adicionar(ClienteModel cliente);
    }
}
