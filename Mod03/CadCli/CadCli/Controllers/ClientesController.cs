using CadCli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadCli.Controllers
{
    public class ClientesController : Controller
    {
        //string[] nomes = new string[] { "fabiano", "daniel" };

        //private List<Cliente> _clientes = new List<Cliente>() { 
        
        //    new Cliente(){Id=1,Nome="Fabiano",Idade=38},
        //    new Cliente(){Id=2,Nome="Raphael",Idade=18},
        //    new Cliente(){Id=3,Nome="Priscila",Idade=39},
        //    new Cliente(){Id=4,Nome="Nair",Idade=120}
        //};

        private CadCliDataContext _ctx = new CadCliDataContext();
        public ActionResult Index()
        {
            return View(_ctx.Clientes.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Cliente cliente)
        {
            _ctx.Clientes.Add(cliente);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var cliente = _ctx.Clientes.Find(id);
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {

            //var data = _ctx.Clientes.Find(cliente.Id);
            //data.Nome = cliente.Nome;
            //data.Idade = cliente.Idade;
            
            _ctx.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cliente = _ctx.Clientes.Find(id);
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(Cliente cliente)
        {
            var data = _ctx.Clientes.Find(cliente.Id);
            _ctx.Clientes.Remove(data);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
