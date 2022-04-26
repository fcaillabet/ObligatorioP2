using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Repartidor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoVehiculo { get; set; }

        public Repartidor(int id, string nombre, string apellido, string tipoVehiculo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            TipoVehiculo = tipoVehiculo;
        }
    }
}
