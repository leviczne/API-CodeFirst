using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastroAPI.Models;
using SistemaDeCadastroAPI.Repositorios.Intefaces;

namespace SistemaDeCadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet] 
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes()
        {
            List<ClienteModel>cliente = await _clienteRepositorio.BuscarTodosClientes();
            return Ok(cliente);

        }
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Cadastrar([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepositorio.Adicionar(clienteModel);
            return Ok(cliente);

        }
    }
}
