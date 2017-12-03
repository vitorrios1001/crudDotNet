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

        public IActionResult ListaClientes(ClienteModel cliente)
        {
            ViewBag.ListaClientes = RetornaListaClientes(cliente);
            
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View(new ClienteModel());
        }
        
        [HttpPost]
        public IActionResult InserirNovo(ClienteModel cliente)
        {
            
            
            
            
            
            return RedirectToAction("ListaClientes",cliente);
        }
        
        
        public List<ClienteModel> RetornaListaClientes(ClienteModel cliente)//Função que retorna a lista de clientes
        {

            var listaClientes = new List<ClienteModel>();
            
            listaClientes.Add(new ClienteModel
            {
                ID = 1,
                Nome = "Vitor",
                Bairro = "Sul",
                CEP = "75400000",
                Cidade = "Inhumas",
                Endereco = "Rua 02",
                Uf = "GO",
                Status = true
            });
            
            if (cliente.ID != 0)
            {
                listaClientes.Add(cliente);
            }
            
            return listaClientes;
        }
        
        
        
    }
}

