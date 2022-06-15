using Logica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Repartidor : Persona
    {

        public string TipoVehiculo { get; set; }

        public Repartidor(string Nombre, string Apellido, string tipoVehiculo)
        {
            id = Sistema.ultimoIdPersona;
            Sistema.ultimoIdPersona++;
            nombre = Nombre;
            apellido = Apellido;
            TipoVehiculo = tipoVehiculo;
        }

        public Repartidor()
        {

        }

        public bool EsValido()
        {
            bool ret = false;
            if (nombre != "" && apellido != "" && TipoVehiculo != "")
            {
                ret = true;
            }
            return ret;
        }

        public int DevolverID() { return id; }
    }
}

