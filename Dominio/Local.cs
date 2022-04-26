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
        public double PrecioCubierto { get; set; }

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

        

        public Local(int numeroMesa, Mozo mozo, int cantidadComensales, double precioCubierto, List<PlatosCantidad> platos, List<Cliente> cliente)
        {
            NumeroMesa = numeroMesa;
            Mozo = mozo;
            CantidadComensales = cantidadComensales;
            PrecioCubierto = precioCubierto;
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
