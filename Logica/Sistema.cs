using System;
using System.Text;
using System.Collections.Generic;
using Logica;

namespace Dominio
{
    public class Sistema
    {
        public List<Servicio> servicios = new List<Servicio>();
        public List<Plato> platos = new List<Plato>();
        public List<Cliente> clientes = new List<Cliente>();
        public List<Mozo> mozos = new List<Mozo>();
        public List<Repartidor> repartidores = new List<Repartidor>();
        public List<Usuario> usuarios = new List<Usuario>();
        public List<Persona> personas = new List<Persona>();
        public static double PrecioMin { get; set; }
        public static int ultimoIdPersona = 1;

        private static Sistema instancia = null;

        public Sistema()
        {
            Precarga();
        }
        
        public List<Servicio> GetServiciosFecha(DateTime f1, DateTime f2, int? id)
        {
            List<Servicio> ret = new List<Servicio>();

            foreach (Servicio s in servicios)
            {
                if (s.Cliente.id.Equals(id))
                {
                    if (EnFecha(s, f1, f2))
                    {
                        ret.Add(s);
                    }
                }
            }
            return ret;
        }

        public List<Servicio> GetServiciosAbiertos(int? idLogueado)
        {
            List<Servicio> ret = new List<Servicio>();
            foreach (Servicio s in servicios)
            {
                if(s.Cliente.id == idLogueado)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }

        public static Sistema getInstancia()
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }return instancia;
        }

        public bool setPrecioMin(double monto)
        {
            bool ret = false;

            if (monto > 0)
            {
                PrecioMin = monto;
                ret = true;
            }

            return ret;
        }

        public List<Servicio> GetServicio() { return servicios; }

        public List<Plato> GetPlatos() {
            platos.Sort();
            return platos; 
        }

        public List<Cliente> GetClientes() {
            clientes.Sort();
            return clientes;
        }

        public List<Mozo> GetMozos() { return mozos; }

        public List<Repartidor> GetRepartidores() { return repartidores; }

        public static double GetPrecioMin() { return PrecioMin; }

        public bool ListaPlatosCheck()
        {
            bool ret = false;
            if (platos.Count <= 0)
            {
                ret = true;
            }
            return ret;
        }

        public bool ListaClientesCheck()
        {
            bool ret = false;
            if (clientes.Count <= 0)
            {
                ret = true;
            }
            return ret;
        }

        public Local AltaServicioLocal()
        {
            Local n = new Local();
            if (n != null)
            {
                servicios.Add(n);
                return n;
            }
            else
            {
                return null;
            }
        }

        public Plato ObtenerPlato(int platoId)
        {
            foreach (Plato p in platos)
            {
                if (p.Id == platoId)
                {
                    return p;
                }
            }return null;
        }

        public Delivery AltaServicioDelivery(string direccion, int repartidorId, double distancia, int clienteId)
        {
            Cliente c = GetClienteId(clienteId);
            Delivery n = new Delivery(direccion, GetRepartidorId(repartidorId), distancia, c);
            if (n != null)
            {
                servicios.Add(n);
                return n;
            }
            else
            {
                return null;
            }
        }

        public Cliente GetClienteId(int Id)
        {
            foreach (Cliente c in clientes)
            {
                if(c.id == Id)
                {
                    return c;
                }           
            }return null;
        }

        public Repartidor GetRepartidorId(int Id)
        {
            foreach (Repartidor r in repartidores)
            {
                if (r.id == Id)
                {
                    return r;
                }       
            }
            return null;
        }

        public Servicio GetServicioPorIdLocal(int id)
        {
            foreach (Servicio s in servicios)
            {
                if (s is Local)
                {
                    if (s.Id.Equals(id))
                    {
                        return s;
                    }
                }
            }
            return null;
        }

        public Servicio GetServicioPorIdDelivery(int id)
        {
            foreach (Servicio s in servicios)
            {
                if (s is Delivery) {
                    if (s.Id.Equals(id))
                    {
                        return s;
                    }
                }
            }
            return null;
        }


        public Servicio GetServicioPorId(int id)
        {
            foreach (Servicio s in servicios)
            {
                if (s.Id.Equals(id))
                {
                    return s;
                }             
            }
            return null;
        }

        public void Likear(int id)
        {
            foreach(Plato p in platos)
            {
                if (p.Id.Equals(id))
                {
                    p.likes++;
                }
            }
        }

        public bool EnFecha(Servicio serv, DateTime f1, DateTime f2)
        {
            bool ret = false;
            if (serv.Fecha > f1 && serv.Fecha < f2)
            {
                ret = true;
            }
            return ret;
        }

        public bool CoincideId(Delivery serv, int id)
        {
            bool ret = false;
            if (serv.Repartidor.DevolverID() == id)
            {
                ret = true;
            }
            return ret;
        }

        public List<Servicio> GetServiciosRangoFecha(int id, DateTime f1, DateTime f2)
        {

            List<Servicio> ret = new List<Servicio>();

            foreach (Delivery serv in servicios) {
                if (EnFecha(serv, f1, f2) && CoincideId(serv, id))
                {
                    ret.Add(serv);
                }
            }
            return ret;
        }

        

        public Mozo AltaMozo(Mozo mozo, string user, string pass)
        {

            if (mozo.EsValido())
            {
                if (numeroNoExiste(mozo.NumeroFuncionario))
                {
                    personas.Add(mozo);
                    mozos.Add(mozo);
                }
                Usuario Nuevo = new Usuario(mozo.id, user, pass);
                if (Nuevo.EsValido())
                {
                    usuarios.Add(Nuevo);
                }
                return mozo;
            }
            return null;
        }

        public bool numeroNoExiste(int num)
        {
            bool ret = true;

            for (int i = 0; i < mozos.Count; i++)
            {
                int numero = mozos[i].NumeroFuncionario;
                if (num == numero)
                {
                    ret = false;
                }
            }
            return ret;
        }

        public Plato AltaPlato(Plato p)
        {
            if (p.EsValido())
            {
                platos.Add(p);
            }
            return p;
        }
        public Cliente AltaCliente(Cliente c, string user, string pass)
        {
            if (c.EsValido())
            {
                personas.Add(c);
                clientes.Add(c);
                Usuario Nuevo = new Usuario(c.id, user, pass);
                if (Nuevo.EsValido())
                {
                    usuarios.Add(Nuevo);
                }
            }
           
            return c;
        }

        public Repartidor AltaRepartidor(Repartidor r, string user, string pass)
        {
            if (r.EsValido())
            {
                personas.Add(r);
                repartidores.Add(r);
            }
            Usuario Nuevo = new Usuario(r.id, user, pass);
            if (Nuevo.EsValido())
            {
                usuarios.Add(Nuevo);
            }
            return r;
        }

        public Persona ValidarLogin(string user, string pass)
        {
            Persona p = null;
            foreach (Usuario u in usuarios)
            {
                if(u.usuario.Equals(user) && u.password.Equals(pass))
                {
                    p = GetPersona(u.idUsuario);
                }
            }return p;     
        }

        public Persona GetPersona(int idPersona)
        {
            foreach (Persona p in personas)
            {
                if (p.id.Equals(idPersona) && p is Cliente)
                {
                    return p;
                }
            }
            foreach (Persona p in personas)
            {
                if (p.id.Equals(idPersona) && p is Mozo)
                {
                    return p;
                }
            }
            foreach (Persona p in personas)
            {
                if (p.id.Equals(idPersona) && p is Repartidor)
                {
                    return p;
                }
            }
            return null;
        }

        public Cliente ValidarCliente(Cliente c, string user, string pass)
        {
            foreach (Cliente cli in personas)
            {
                if (c.nombre.Equals(cli.nombre) || c.apellido.Equals(cli.apellido) || c.Email.Equals(cli.Email))
                {
                    return null;
                }else
                {
                    foreach (Usuario u in usuarios)
                    {
                        if (user.Equals(u.usuario) || pass.Equals(u.password))
                        {
                            return null;
                        }
                    }
                }
            } return c;
        }

        public void AgregarPlato(Plato p, int c, Servicio serv)
        {
            PlatosCantidad n = new PlatosCantidad(p, c);
            if (n != null && serv.Estado.Equals("Abierta"))
            {
                serv.Platos.Add(n);
            }
        }

        private void Precarga()
        {

            //Precarga platos
            Plato p1 = new Plato(1, "Milanesa", 500);
            AltaPlato(p1);
            Plato p2 = new Plato(2, "Asado", 900);
            AltaPlato(p2);
            Plato p3 = new Plato(3, "Canelones", 650);
            AltaPlato(p3);
            Plato p4 = new Plato(4, "Pizza", 550);
            AltaPlato(p4);
            Plato p5 = new Plato(5, "Ñoquis", 700);
            AltaPlato(p5);
            Plato p6 = new Plato(6, "Sopa", 700);
            AltaPlato(p6);
            Plato p7 = new Plato(7, "Pescado", 970);
            AltaPlato(p7);
            Plato p8 = new Plato(8, "Papas Fritas", 400);
            AltaPlato(p8);
            Plato p9 = new Plato(9, "Faina", 350);
            AltaPlato(p9);
            Plato p10 = new Plato(10, "Empanada", 70);
            AltaPlato(p10);

            //Precarga clientes
            Cliente c1 = new Cliente("Juan", "Lopez","LopezJuan@gmail.com");
            Cliente c2 = new Cliente("Clara", "Garcia", "GarciaClara@gmail.com");
            Cliente c3 = new Cliente("Felipe", "Gomez", "GomezFelipe@gmail.com");
            Cliente c4 = new Cliente("Franca", "Sosa", "SosaFranca@gmail.com");
            Cliente c5 = new Cliente("Walter", "White", "WhiteWalter@gmail.com");
            AltaCliente(c1, "Juan", "Juan123");
            AltaCliente(c2, "Clara", "Clara123");
            AltaCliente(c3, "Felipe", "Felipe123");
            AltaCliente(c4, "Franca", "Franca123");
            AltaCliente(c5, "Walter", "Walter123");

            //Precarga mozos
            Mozo m1 = new Mozo("Moninca", "Mernes", 1);
            Mozo m2 = new Mozo("José", "DaSilva", 2);
            Mozo m3 = new Mozo("Mateo", "Manchez", 3);
            Mozo m4 = new Mozo("Rodrigo", "Pequeño", 4);
            Mozo m5 = new Mozo("Matias", "Otero", 5);
            AltaMozo(m1, "Monica", "Monica123");
            AltaMozo(m2, "Jose", "Jose123");
            AltaMozo(m3, "Mateo", "Mateo123");
            AltaMozo(m4, "Rodrigo", "Rodrigo123");
            AltaMozo(m5, "Matias", "Matias123");

            //Precarga repartidores
            Repartidor r1 = new Repartidor("Mario", "Lanterna", "Moto");
            Repartidor r2 = new Repartidor("David", "Zurbano", "Bicicleta");
            Repartidor r3 = new Repartidor("Rocio", "Gimenez", "Moto");
            Repartidor r4 = new Repartidor("Mauro", "Bisbal", "Auto");
            Repartidor r5 = new Repartidor("Valentina", "Turner", "Moto");
            AltaRepartidor(r1, "Mario", "Mario123");
            AltaRepartidor(r2, "David", "David123");
            AltaRepartidor(r3, "Rocio", "Rocio123");
            AltaRepartidor(r4, "Mauro", "Mauro123");
            AltaRepartidor(r5, "Valentina", "Valentina123");

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
            Local l1 = new Local(1, m1, 3, c1);
            servicios.Add(l1);
            Local l2 = new Local(2, m2, 2, c2);
            servicios.Add(l2);
            Local l3 = new Local(3, m3, 1, c3);
            servicios.Add(l3);
            Local l4 = new Local(4, m4, 5, c4);
            servicios.Add(l4);
            Local l5 = new Local(5, m5, 4, c5);                 
            servicios.Add(l5);

            //Precarga serviciosDelivery 

            Delivery d1 = new Delivery("La paz 765", r1, 22, c1);
            servicios.Add(d1);
            Delivery d2 = new Delivery("Paysandú 1030", r2, 10, c2);
            servicios.Add(d2);
            Delivery d3 = new Delivery("Montevideo 945", r3, 40, c3);
            servicios.Add(d3);
            Delivery d4 = new Delivery("Herrera 450", r4, 5, c4);
            servicios.Add(d4);
            Delivery d5 = new Delivery("Benito 321", r5, 60, c5);
            servicios.Add(d5);
        }
    }
}