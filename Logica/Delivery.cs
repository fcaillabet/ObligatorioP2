using Logica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Delivery : Servicio
    {
        public string DireccionEnvio { get; set; }
        public double Distancia { get; set; }

        public Repartidor Repartidor { get; set; }

        public Delivery(string direccion, Repartidor repartidor, double distancia, Cliente cliente)
        {
            Id = UltimoId;
            UltimoId++;
            DireccionEnvio = direccion;
            Repartidor = repartidor;    
            Distancia = distancia;
            Cliente = cliente;
            Estado = "Abierta";
            PrecioFinal = 0;
            Fecha = DateTime.Now;
        }

        public Delivery()
        {

        }        

        public override double CalcularPrecio()
        {
            double total = 0;
            for (int i = 0; i <= Platos.Count; i++)
            {
                double precioSumar = Platos[i].PlatoLocal.Precio;
                precioSumar *= (Platos[i].CantidadLocal);
                total += precioSumar;
            }
            if (Distancia < 2)
            {
                total += 50;
            } else
            {
                int precioDistancia = 50;
                for (int i = 2; i < Distancia; i++)
                {
                    precioDistancia += 10;
                    if (precioDistancia == 100)
                    {
                        i = int.MaxValue;
                    }
                }
                total += precioDistancia;
            }
            return total;
        }

        public override string ToString()
        {
            return $"{Fecha} {Repartidor.nombre}";
        }
    }
}
