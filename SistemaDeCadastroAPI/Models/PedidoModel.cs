using System;
using System.Collections.Generic;

namespace SistemaDeCadastroAPI.Models
{
    public partial class PedidoModel
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public string Pedido { get; set; } = null!;
        public int NumeroDoPedido { get; set; }

        public virtual ClienteModel IdClienteNavigation { get; set; } = null!;
    }
}
