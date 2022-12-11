using System;
using System.Collections.Generic;

namespace SistemaDeCadastroAPI.Models
{
    public partial class ClienteModel
    {
        public ClienteModel()
        {
            Pedidos = new HashSet<PedidoModel>();
        }

        public int IdCliente { get; set; }
        public string? Name { get; set; }
        public string? Senha { get; set; }

        public virtual ICollection<PedidoModel> Pedidos { get; set; }
    }
}
