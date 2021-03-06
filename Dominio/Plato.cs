using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Plato : IValidacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Plato(int id, string nombre, double precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }

        public bool EsValido()
        {
            bool ret = false;
            if (Nombre != "" && Precio > Sistema.PrecioMin)
            {
                ret = true;
            }
            return ret;
        }

        public override string ToString()
        {
            return $"{Id} {Nombre} {Precio}";
        }
    }
}
