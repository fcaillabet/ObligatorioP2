using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Delivery : Servicio
    {
        public string DireccionEnvio { get; set; }
        //public Repartidor Repartidor { get; set; }
        public double Distancia { get; set; }

        public Repartidor GetRepartidor() { return Repartidor; }

        public Delivery(string direccion, Repartidor repartidor, double distancia, List<PlatosCantidad> platos, List<Cliente> cliente)
        {
            DireccionEnvio = direccion;
            Repartidor = repartidor;    
            Distancia = distancia;
            Platos = platos;
            Cliente = cliente;
            Fecha = DateTime.Now;
        }

        
        

        public override double CalcularPrecio()
        {
            throw new NotImplementedException();
        }
    }
}
