using System;
using System.Text;
using System.Collections.Generic;

namespace Dominio
{
    public class Sistema
    {       
        private List<Servicio> servicios = new List<Servicio>();
        private List<Plato> platos = new List<Plato>();
        private List<Cliente> clientes = new List<Cliente>();
        public List<Mozo> mozos = new List<Mozo>();
        private List<Repartidor> repartidores = new List<Repartidor>();
        public static double PrecioMin { get; set; }

        public Sistema()
        {
            Precarga();
        }

        public List<Servicio> GetServicio() { return servicios; }
        public List<Plato> GetPlatos() { return platos; }
        public List<Cliente> GetClientes() {
            clientes.Sort();
            return clientes; 
        }
        public List<Mozo> GetMozos() { return mozos; }
        public List<Repartidor> GetRepartidor() { return repartidores; }

        public static double GetPrecioMin() { return PrecioMin; }

        public List<Servicio> GetServiciosRangoFecha(string nombre, DateTime f1, DateTime f2)
        {

            List<Servicio> ret = new List<Servicio>();
            foreach (Servicio serv in servicios)
            {
                string nombreDelivery = "";
                if (nombreDelivery == nombre && serv.Fecha > f1 && serv.Fecha < f2)
                {
                    ret.Add(serv);
                }
            }
            return ret;

        }

        public Mozo AltaMozo(Mozo mozo)
        {

            if (mozo.esValido())
            {
                mozos.Add(mozo);
                return mozo;
            }
            return null;
        }

        private void Precarga()
        {

            //Precarga platos
            Plato p1 = new Plato(1, "Milanesa", 500);
            platos.Add(p1);
            Plato p2 = new Plato(2, "Asado", 900);
            platos.Add(p2);
            Plato p3 = new Plato(3, "Canelones", 650);
            platos.Add(p3);
            Plato p4 = new Plato(4, "Pizza", 550);
            platos.Add(p4);
            Plato p5 = new Plato(5, "Ñoquis", 700);
            platos.Add(p5);
            Plato p6 = new Plato(6, "Sopa", 700);
            platos.Add(p6);
            Plato p7 = new Plato(7, "Pescado", 970);
            platos.Add(p7);
            Plato p8 = new Plato(8, "Papas Fritas", 400);
            platos.Add(p8);
            Plato p9 = new Plato(9, "Faina", 350);
            platos.Add(p9);
            Plato p10 = new Plato(10, "Empanada", 70);
            platos.Add(p10);

            //Precarga clientes
            Cliente c1 = new Cliente("Juan", "Lopez", "LopezJuan@gmail.com", "Juan123");
            Cliente c2 = new Cliente("Clara", "Garcia", "GarciaClara@gmail.com", "Clara123");
            Cliente c3 = new Cliente("Felipe", "Gomez", "GomezFelipe@gmail.com", "Felipe123");
            Cliente c4 = new Cliente("Franca", "Sosa", "SosaFranca@gmail.com", "123");
            Cliente c5 = new Cliente("Walter", "White", "WhiteWalter@gmail.com", "Walter123");
            clientes.Add(c1);
            clientes.Add(c2);
            clientes.Add(c3);
            clientes.Add(c4);
            clientes.Add(c5);

            //Precarga mozos
            Mozo m1 = new Mozo(1, "Moninca", "Mernes", 1);
            Mozo m2 = new Mozo(2, "José", "DaSilva", 2);
            Mozo m3 = new Mozo(3, "Mateo", "Manchez", 3);
            Mozo m4 = new Mozo(4, "Rodrigo", "Pequeño", 4);
            Mozo m5 = new Mozo(5, "Matias", "Otero", 5);
            mozos.Add(m1);
            mozos.Add(m2);
            mozos.Add(m3);
            mozos.Add(m4);
            mozos.Add(m5);

            //Precarga repartidores
            Repartidor r1 = new Repartidor(1, "Mario", "Lanterna", "Moto");
            Repartidor r2 = new Repartidor(2, "David", "Zurbano", "Bicicleta");
            Repartidor r3 = new Repartidor(3, "Rocio", "Gimenez", "Moto");
            Repartidor r4 = new Repartidor(4, "Mauro", "Bisbal", "Auto");
            Repartidor r5 = new Repartidor(5, "Valentina", "Turner", "Moto");
            repartidores.Add(r1);
            repartidores.Add(r2);
            repartidores.Add(r3);
            repartidores.Add(r4);
            repartidores.Add(r5);

            //PrecargaListaPlatos
            PlatosCantidad pc1 = new PlatosCantidad(p1, 2);
            PlatosCantidad pc2 = new PlatosCantidad(p2, 4);
            PlatosCantidad pc3 = new PlatosCantidad(p3, 1);
            PlatosCantidad pc4 = new PlatosCantidad(p4, 6);
            PlatosCantidad pc5 = new PlatosCantidad(p5, 3);
            PlatosCantidad pc6 = new PlatosCantidad(p6, 1);
            PlatosCantidad pc7 = new PlatosCantidad(p7, 5);
            PlatosCantidad pc8 = new PlatosCantidad(p8, 2);
            PlatosCantidad pc9 = new PlatosCantidad(p9, 4);
            PlatosCantidad pc10 = new PlatosCantidad(p10, 3);

            //Precarga serviciosLocal  
            Servicio l1 = new Local(1, m1, 3, 70, pc6.CrearListaPlatos(pc6), c1.CrearListaClientes(c1));
            servicios.Add(l1);
            Servicio l2 = new Local(2, m2, 2, 70, pc7.CrearListaPlatos(pc7), c2.CrearListaClientes(c2));
            servicios.Add(l2);
            Servicio l3 = new Local(3, m3, 1, 70, pc8.CrearListaPlatos(pc8), c3.CrearListaClientes(c3));
            servicios.Add(l3);
            Servicio l4 = new Local(4, m4, 5, 70, pc9.CrearListaPlatos(pc9), c4.CrearListaClientes(c4));
            servicios.Add(l4);
            Servicio l5 = new Local(5, m5, 4, 70, pc10.CrearListaPlatos(pc10), c5.CrearListaClientes(c5));                 
            servicios.Add(l5);

            //Precarga serviciosDelivery 

            Servicio d1 = new Delivery("La paz 765", r1, 22, pc1.CrearListaPlatos(pc1), c1.CrearListaClientes(c1));
            servicios.Add(d1);
            Servicio d2 = new Delivery("Paysandú 1030", r1, 10, pc2.CrearListaPlatos(pc2), c2.CrearListaClientes(c2));
            servicios.Add(d2);
            Servicio d3 = new Delivery("Montevideo 945", r1, 40, pc3.CrearListaPlatos(pc3), c3.CrearListaClientes(c3));
            servicios.Add(d3);
            Servicio d4 = new Delivery("Herrera 450", r1, 5, pc4.CrearListaPlatos(pc4), c4.CrearListaClientes(c4));
            servicios.Add(d4);
            Servicio d5 = new Delivery("Benito 321", r1, 60, pc5.CrearListaPlatos(pc5), c5.CrearListaClientes(c5));
            servicios.Add(d5);
        }
    }
}