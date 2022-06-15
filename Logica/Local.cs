using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Local : Servicio
    {
        public int NumeroMesa { get; set; }
        public Mozo Mozo { get; set; }
        public int CantidadComensales { get; set; }
        public static double PrecioCubierto { get; set; } = 50;

        public List<PlatosCantidad> platosLocal = new List<PlatosCantidad>();

        public bool CrearListaPlatosLocal(PlatosCantidad platoCantidad)
        {
            bool ret = false;
            if (platoCantidad != null) {
            platosLocal.Clear();
            platosLocal.Add(platoCantidad);
                ret = true;
            }
            return ret;
        }

        

        public Local(int numeroMesa, Mozo mozo, int cantidadComensales, Cliente cliente)
        {
            Id = UltimoId;
            UltimoId++;
            NumeroMesa = numeroMesa;
            Mozo = mozo;
            CantidadComensales = cantidadComensales;
            Cliente = cliente;
            Estado = "Abierta";
            PrecioFinal = 0;
            Fecha = DateTime.Now;
        }

        public Local()
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
            total += CantidadComensales * PrecioCubierto;
            total += ((total * 10) / 100);
            return total;
        }
    }
}
