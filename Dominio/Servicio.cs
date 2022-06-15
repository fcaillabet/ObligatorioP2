using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Servicio 
    {
        public List<Cliente> Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<PlatosCantidad> Platos { get; set; }

        public Repartidor Repartidor { get; set; }

        public Servicio CrearListaRepartidoresRangoFecha(Servicio serv, string nombre, string apellido, DateTime f1, DateTime f2)
        {
            nombre = unirNombreApellido(nombre, apellido);
            string nombreDelivery = serv.Repartidor.Nombre;
              
            if (nombreDelivery == nombre && serv.Fecha > f1 && serv.Fecha < f2)
            {
                return serv;
            } else
            {
                return null;
            }
            
        }

        


        public string unirNombreApellido(string nombre, string apellido)
        {
            string nombreMin = nombre.ToLower();
            string apellidoMin = apellido.ToLower();
            return apellidoMin + " " + nombreMin;
        }

        public abstract double CalcularPrecio();
    }
}
