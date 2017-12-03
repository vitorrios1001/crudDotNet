using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CadastroCliente.Data;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> InserirCliente(
            [Bind("Nome,Endereco,Bairro,CEP,Cidade,Uf,Status")]ClienteModel cliente)
        {
            using (var ctx = new ClienteContexto())
            {
                await ctx.Clientes.AddAsync(cliente);
                await ctx.SaveChangesAsync();

            }
            ViewBag.ListaClientes = RetornaListaClientes();
            
            return RedirectToAction("ListaClientes");
        }
        
        public async Task<IActionResult> EditarCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var c = FiltraCliente((int)id).First();

            if (c == null)
            {
                return NotFound();
            }
            
            ViewBag.ClienteEdicao = c;

            return View(c);
        }
        
        
        /*
        public async Task<IActionResult> EditarCliente(int id)
        {
            ClienteModel cliente = FiltraCliente(id).First();

            ViewBag.ClienteEdicao = cliente;
            
            return View(cliente);
        }
        */
        
        [HttpPost]
        public async Task<IActionResult> EditarCliente(
            [Bind("Nome,Endereco,Bairro,CEP,Cidade,Uf,Status")]ClienteModel cliente)
        {
            
            if (cliente == null)
            {
                return NotFound();
            }

            clienteContexto.Clientes.Update(cliente);
            
            ViewBag.ListaClientes = RetornaListaClientes();
            
            return View("ListaClientes");

        }
        
        
        
        
        //Rota
        public async Task<IActionResult> ExcluirCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var c = FiltraCliente((int)id).First();

            if (c == null)
            {
                return NotFound();
            }
            
            ViewBag.DetalheCliente = c;

            return View("DetalheCliente",c);
        }
        //Função
        [HttpPost]
        public async Task<IActionResult> ExcluirCLiente(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var c = FiltraCliente(id).First();

            if (c == null)
            {
                return NotFound();
            }
            
            using (var ctx = new ClienteContexto())
            {
                ctx.Clientes.Remove(c);
                await ctx.SaveChangesAsync();
                
            }
            
            ViewBag.ListaClientes = RetornaListaClientes();
            
            return RedirectToAction("ListaClientes");

        }
        
        
        public IEnumerable<ClienteModel> RetornaListaClientes()//Função que retorna a lista de clientes
        {

            using (var ctx = new ClienteContexto())
            {
                return  ctx.Clientes.ToList();
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

        public IEnumerable<ClienteModel> FiltraCliente(int id)
        {
            using (var ctx = new ClienteContexto())
            {
                return ctx.Clientes.Where(c => c.ID == id).ToList();
            }
            
        }
        
    }
}

