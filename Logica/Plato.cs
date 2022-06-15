using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Plato : IValidacion, IComparable<Plato>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public int likes { get; set; }

        public Plato(int id, string nombre, double precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            likes = 0;
        }

        public Plato()
        {

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

        public int CompareTo([AllowNull] Plato other)
        {
            if (Nombre.CompareTo(other.Nombre) > 0)
            {
                return 1;
            }
            else if (Nombre.CompareTo(other.Nombre) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }   
        }
    }
}
