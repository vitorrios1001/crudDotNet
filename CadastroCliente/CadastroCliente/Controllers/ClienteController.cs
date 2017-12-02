using System.Collections.Generic;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Controllers
{
    public class ClienteController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaClientes()
        {
            ViewBag.ListaClientes = RetornaListaClientes();
            
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult InserirNovo(ClienteModel cliente)
        {
            
            return View("ListaClientes");
        }

        public List<ClienteModel> RetornaListaClientes()//Função que retorna a lista de clientes
        {

            var listaClientes = new List<ClienteModel>();

            



            return listaClientes;
        }
        
        
        
    }
}

