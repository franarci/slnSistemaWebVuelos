using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Admin
{
    public static class AdmVuelo
    {
        static VueloDbContext context = new VueloDbContext();
        
        public static Vuelo BuscarPorId(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            context.Entry(vuelo).State = EntityState.Detached;
            return vuelo;
        }

        public static List<Vuelo> Listar()
        {
           return context.Vuelos.ToList();
        }

        public static List<Vuelo> Listar(string destino)
        {
            return (from v in context.Vuelos
                    where v.Destino == destino
                    select v).ToList();
        }

        public static void Insertar(Vuelo vuelo)
        {
            context.Vuelos.Add(vuelo);
            context.SaveChanges();
            
        }

        public static void Modificar(Vuelo vuelo)
        {
            var v = BuscarPorId(vuelo.Id);
            if (v != null)
            {
                context.Vuelos.Attach(vuelo);
                context.Entry(vuelo).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Eliminar(Vuelo v)
        {
            Vuelo vuelo = BuscarPorId(v.Id);

            if (vuelo != null)
            {
                context.Vuelos.Attach(vuelo);
                context.Vuelos.Remove(vuelo);
                context.SaveChanges();
            }
        }
    }
}