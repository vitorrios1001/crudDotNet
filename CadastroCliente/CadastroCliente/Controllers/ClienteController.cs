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
        
        //Rota Lista de Clientes
        public IActionResult ListaClientes()
        {
            ViewBag.ListaClientes = RetornaListaClientes();

            return View();
        }
        
        //Rota Inserir
        public IActionResult CadastroCliente()
        {
            return View(new ClienteModel());
        }
   
        //Função Inserir
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InserirCliente(
            [Bind("Nome,Endereco,Bairro,CEP,Cidade,Uf,Status")]ClienteModel cliente)
        {

            if (ModelState.IsValid)
            {
                using (var ctx = new ClienteContexto())
                {
                    await ctx.Clientes.AddAsync(cliente);
                    await ctx.SaveChangesAsync();

                }
                ViewBag.ListaClientes = RetornaListaClientes();
            
                return RedirectToAction("ListaClientes");
            }
            return View("CadastroCliente", cliente);

        }
        
        
        //Rota Editar
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
            
            return View(c);
        }
        //Funcao Editar
        [HttpPost]
        public async Task<IActionResult> EditarCliente(
            [Bind("ID,Nome,Endereco,Bairro,CEP,Cidade,Uf,Status")]ClienteModel cliente)
        {

            var c = FiltraCliente(cliente.ID).First();
            
            if (c == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var ctx = new ClienteContexto())
                {
                    c.Nome = cliente.Nome;
                    c.Bairro = cliente.Bairro;
                    c.CEP = cliente.CEP;
                    c.Cidade = cliente.Cidade;
                    c.Endereco = cliente.Endereco;
                    c.Status = cliente.Status;
                    c.Uf = cliente.Uf;
                
                
                    ctx.Clientes.Update(c);
                    await ctx.SaveChangesAsync();

                }
            
            
                ViewBag.ListaClientes = RetornaListaClientes();
            
                return RedirectToAction("ListaClientes");
            }

            return View(c);

        }
        
        
        
        
        //Rota Excluir
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
        //Função Excluir
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

