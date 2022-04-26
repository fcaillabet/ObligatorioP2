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


        public abstract double CalcularPrecio();
    }
}
