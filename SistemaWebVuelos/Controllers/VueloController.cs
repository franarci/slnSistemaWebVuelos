using SistemaWebVuelos.Admin;
using SistemaWebVuelos.Data;
using SistemaWebVuelos.Filter;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Controllers
{
    [BeforeAfterFilter]
    public class VueloController : Controller
    {
        //static VueloDbContext context = new VueloDbContext();
        // GET: Vuelo
        public ActionResult Index(string destino)
        {
            List<Vuelo> vuelos;
            if (string.IsNullOrEmpty(destino))
            {
                 vuelos= AdmVuelo.Listar();
            }
            else {
                vuelos = AdmVuelo.Listar(destino);
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
                AdmVuelo.Insertar(vuelo);
                return RedirectToAction("Index");
            }
            return View("Create", vuelo);
        }

        public ActionResult Detail(int id)
        {
            Vuelo vuelo= AdmVuelo.BuscarPorId(id);
            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }
            return HttpNotFound();
        }

        public ActionResult Edit(int id)
        {
            Vuelo vuelo = AdmVuelo.BuscarPorId(id);
            if (vuelo == null)
                return HttpNotFound();

            return View("Edit", vuelo);
        }

        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {

           AdmVuelo.Modificar(vuelo);

           return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Vuelo vuelo = AdmVuelo.BuscarPorId(id);

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
            Vuelo vuelo = AdmVuelo.BuscarPorId(v.Id);
            
            if (vuelo!=null)
            {
                AdmVuelo.Eliminar(vuelo);
            }
            return RedirectToAction("Index");
            
        }
    }
}