using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Content;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SupplierController : Controller
    {

        #region [ Propriedades ] 
        private EFContexto contexto = new EFContexto(); 
        #endregion



        #region [ Actions ]
        // GET: Fornecedor
        public ActionResult Index()
        {
            var fornecedor = contexto.Fornecedores.OrderBy(s => s.Name);
            return View(fornecedor);
        }



        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier fornecedor)
        {
            contexto.Fornecedores.Add(fornecedor);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET
        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var fornecedor = contexto.Fornecedores.Find(id);

            if(fornecedor == null)
                return HttpNotFound();

            return View(fornecedor);


        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier fornecedor)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(fornecedor).State = EntityState.Modified;
                contexto.SaveChanges();

                return View(fornecedor);
            }
        }



        #endregion





    }
}