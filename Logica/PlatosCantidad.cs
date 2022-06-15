using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PlatosCantidad
    {
        public Plato PlatoLocal { get; set; }
        public int CantidadLocal { get; set; }

        /*public List<PlatosCantidad> platosCantidad = new List<PlatosCantidad>();

        public List<PlatosCantidad> CrearListaPlatos(PlatosCantidad platoCantidad)
        {
            if (platoCantidad != null)
            {
                platosCantidad.Clear();
                platosCantidad.Add(platoCantidad);

            }
            return platosCantidad;
        }*/


        public PlatosCantidad(Plato plato, int cantidad)
        {
            PlatoLocal = plato;
            CantidadLocal = cantidad;
        }
    }
}
