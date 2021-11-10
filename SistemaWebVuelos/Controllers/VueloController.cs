using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Controllers
{
    public class VueloController : Controller
    {
        static VueloDbContext context = new VueloDbContext();
        // GET: Vuelo
        public ActionResult Index(string destino)
        {
            List<Vuelo> vuelos;
            if (string.IsNullOrEmpty(destino))
            {
                 vuelos= context.Vuelos.ToList();
            }
            else {
                vuelos = (from v in context.Vuelos
                          where v.Destino == destino
                          select v).ToList();
            }
            
            return View("Index", vuelos);
        }

        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();

            return View("Create", vuelo);
        }


        //Vuelo/Create --> POST
        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                context.Vuelos.Add(vuelo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", vuelo);
        }

        public ActionResult Detail(int id)
        {
            Vuelo vuelo= context.Vuelos.Find(id);
            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            return HttpNotFound();
        }

        public ActionResult Edit(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            if (vuelo == null)
                return HttpNotFound();

            return View("Edit", vuelo);
        }

        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {
            var v = context.Vuelos.Find(vuelo.Id);
            if (v != null)
            {
                context.Entry(v).State = EntityState.Detached;
                context.Entry(vuelo).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", vuelo);
        }

        public ActionResult Delete(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);

            if (vuelo != null)
            {
                return View("Delete", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(Vuelo v)
        {
            Vuelo vuelo = context.Vuelos.Find(v.Id);
            {
                if (vuelo!=null)
                {
                   //context.Vuelos.Attach(vuelo);
                   context.Vuelos.Remove(vuelo);
                   context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}