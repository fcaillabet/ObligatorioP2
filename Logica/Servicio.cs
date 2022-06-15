using Logica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Servicio
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }

        public List<PlatosCantidad> Platos = new List<PlatosCantidad>();

        public Double PrecioFinal { get; set; }

        public string Estado { get; set; } = "Abierta";

        public string ObtenerNombreApellidoRepartidor(Delivery serv)
        {
                string nombre = serv.Repartidor.nombre;
                string apellido = serv.Repartidor.apellido;
                string nombreMin = nombre.ToLower();
                string apellidoMin = apellido.ToLower();
                return apellidoMin + " " + nombreMin;   
        }

        public void CerrarOperacion()
        {
            if (Estado == "Abierta") { 
                Estado = "Cerrada";
            }  
        }

        public Servicio CrearListaRepartidoresRangoFecha(Delivery serv, string nombre, string apellido, DateTime f1, DateTime f2)
        {
            string nombreUnido = unirNombreApellido(nombre, apellido);
            string nombreDelivery = serv.ObtenerNombreApellidoRepartidor(serv);
              
            if (nombreDelivery == nombreUnido && serv.Fecha > f1 && serv.Fecha < f2)
            {
                return serv;
            } else
            {
                return null;
            }
            
        }


        public override string ToString()
        {
            return $"{Fecha}";
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
