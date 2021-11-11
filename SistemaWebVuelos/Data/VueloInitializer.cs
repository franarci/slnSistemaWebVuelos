using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Data
{
    public class VueloInitializer : DropCreateDatabaseAlways<VueloDbContext>
    {
        protected override void Seed(VueloDbContext context)
        {
            var vuelos = new List<Vuelo>
            {
               new Vuelo
               {
                  Fecha= new DateTime(2021,5,5),
                  Destino = "Moscu",
                  Origen = "Buenos Aires",
                  Matricula=666,
               },
               new Vuelo
               {
                  Fecha= Convert.ToDateTime("12/05/2022"),
                  Destino = "Lima",
                  Origen = "Buenos Aires",
                  Matricula=746,
               }
            };
            vuelos.ForEach(b => context.Vuelos.Add(b));
            context.SaveChanges();
        }
    }
}