using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategorieController : Controller
    {

        private IList<Categorie> ListaCategoria = new List<Categorie>()
        {
            new Categorie() {Id=01, Name="Cobaia01" },
            new Categorie() {Id=02, Name="Cobaia02" },
            new Categorie() {Id=03, Name="Cobaia03" },
            new Categorie() {Id=04, Name="Cobaia04" },
            new Categorie() {Id=05, Name="Cobaia05" },

        };


        // GET: Categoria
        public ActionResult Index()
        {
            return View(ListaCategoria.OrderBy(c => c.Name));
        }


        public ActionResult Edit(int Id)
        {
            var categorie = ListCategorie.Where(c => c.Id == Id).First();
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie categ)
        {
            var categorie = ListCategorie.Where(c => c.Id == categ.Id).First();
            return RedirectToAction("Index");
        }


        public ActionResult Detalis(long Id)
        {
            var categoria = ListaCategoria.Where(c => c.Id == Id).First();
            return View(categoria);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie categ)
        {
            ListaCategoria.Add(categ);
            categ.Id = ListaCategoria.Select(c => c.Id).Max()+1;
            return RedirectToAction("Index");
        }

        //GET

        public ActionResult Delete(long id)
        {
            var categoria = ListaCategoria.Where(c => c.Id == id).First();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categorie categ)
        {

            var cat = ListaCategoria.Where(c => c.Id == categ.Id).First();
            ListaCategoria.Remove(cat);
            return RedirectToAction("Index");
        }

        private ActionResult VaiParaCategoriaView(long id)
        {
            var categoria = ListaCategoria.Where(c => c.Id == id).First();
            return View(categoria);
        }


        private Categorie LerCategoria(long id)
        {
            return ListaCategoria.First(c => c.Id.Equals(id));
        }


    }
}