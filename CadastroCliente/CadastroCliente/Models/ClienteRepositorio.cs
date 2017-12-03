using CadastroCliente.Data;
using Microsoft.EntityFrameworkCore;


namespace CadastroCliente.Models
{
    public class ClienteRepositorio
    {

        private ClienteContexto _clienteContexto;


        public ClienteRepositorio()
        {
            _clienteContexto = new ClienteContexto();
        }





    }
}