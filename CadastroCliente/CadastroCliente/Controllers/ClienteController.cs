using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CadastroCliente.Data;
using CadastroCliente.Data.Interface;
using CadastroCliente.Data.Repository;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace CadastroCliente.Controllers
{
    public class ClienteController : Controller
    {

        protected readonly ClienteRepository dbContextCliente;
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        //Rota Lista de Clientes
        public IActionResult ListaClientes()
        {
            ViewBag.ListaClientes = dbContextCliente.GetAll();

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
        public IActionResult InserirCliente(
            [Bind("Nome,Endereco,Bairro,CEP,Cidade,Uf,Status")]ClienteModel cliente)
        {

            if (ModelState.IsValid)
            {
                dbContextCliente.Save(cliente);
                
                ViewBag.ListaClientes = dbContextCliente.GetAll();
            
                return RedirectToAction("ListaClientes");
            }
            return View("CadastroCliente", cliente);

        }
        
        
        //Rota Editar
        public IActionResult EditarCliente(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            
            var c = dbContextCliente.GetById(id);

            if (c == null)
            {
                return NotFound();
            }
            
            return View(c);
        }
        //Funcao Editar
        [HttpPost]
        public IActionResult EditarCliente(
            [Bind("ID,Nome,Endereco,Bairro,CEP,Cidade,Uf,Status")]ClienteModel cliente)
        {

            var c = dbContextCliente.GetById(cliente.ID);
            
            if (c == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dbContextCliente.Save(cliente);            
            
                ViewBag.ListaClientes = dbContextCliente.GetAll();
            
                return RedirectToAction("ListaClientes");
            }

            return View(c);

        }
               
        
        //Rota Excluir
        public IActionResult ExcluirCliente(int id)
        {
            if (id == 0)
                return NotFound();
                        
            var c = dbContextCliente.GetById(id);

            if(c == null)
                return NotFound();

            ViewBag.DetalheCliente = c;

            return View("DetalheCliente",c);
        }
        //Função Excluir
        [HttpPost]
        public IActionResult ExcluirCLiente(int id)
        {                 
            
            dbContextCliente.Delete(id);
            
            ViewBag.ListaClientes = dbContextCliente.GetAll();
            
            return RedirectToAction("ListaClientes");

        }
        
    }
}

