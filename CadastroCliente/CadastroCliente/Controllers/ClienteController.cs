using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using CadastroCliente.Data;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;

namespace CadastroCliente.Controllers
{
    public class ClienteController : Controller
    {

        private ClienteContexto clienteContexto;
        
        
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
            return View(new ClienteModel());
        }

    
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InserirNovo(
            [Bind("Nome,Endereco,Bairro,CEP,Cidade,Uf,Status")]ClienteModel cliente)
        {
            
            
            
            
            return RedirectToAction("ListaClientes",cliente);
        }
        
        
        public IEnumerable<ClienteModel> RetornaListaClientes()//Função que retorna a lista de clientes
        {

            //clienteContexto = new ClienteContexto();

            
            //var listaClientes =  clienteContexto.Clientes.ToList();

            using (var ctx = new ClienteContexto())
            {
                //var logger = _loggerFactory.CreateLogger("Debug");
                //logger.LogInformation("Solicitou lista de eventos");
                var teste = ctx.Clientes.ToList();
                return teste;
            }
            
            
            
            
            
            
            //return listaClientes;
            /*
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
            */
            
            
            
        }
        
        
        
    }
}

