using Dominio;
using System;
using System.Collections.Generic;

namespace Interfaz
{
    public class Program 
    {
        private static void Main(string[] args)
        {
             
            Sistema s = new Sistema();

            int op = -1;
            while (op != 0)
            {

                MostrarMenu();
                op = Int32.Parse(Console.ReadLine());

                switch (op)
                {

                    case 1:
                        foreach (Plato p in s.GetPlatos())
                        {
                            Console.WriteLine(p);
                        }
                        Console.ReadKey();
                        break;

                    case 2:

                        foreach (Cliente c in s.GetClientes())
                        {

                            Console.WriteLine(c);
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el apellido y nombre de un repartidor separados con un espacio:");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Fecha de inicio");
                        DateTime f1 = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Fecha de fin");
                        DateTime f2 = DateTime.Parse(Console.ReadLine());


                        List<Servicio> ListaFiltrada = s.GetServiciosRangoFecha(nombre, f1, f2);

                        if (ListaFiltrada.Count > 0)
                        {

                            foreach (Servicio serv in ListaFiltrada)
                            {

                                Console.WriteLine(serv);
                            }
                        }
                        else {
                            Console.WriteLine("No hay registros");
                        }

                        Console.ReadKey();
                        break;


                    case 4:
                        Console.WriteLine("Ingrese un monto");
                        double monto = Double.Parse(Console.ReadLine());

                        if (monto > 0)
                        {
                            //s.PrecioMin = monto;
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido cambiar ya que el límite es 1.");
                        }

                        Console.ReadKey();
                        break;

                    case 5:

                        
                        Console.WriteLine("Alta de mozo");
                        Console.WriteLine("Ingrese id:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese nombre:");
                        string nombreMozo = Console.ReadLine();
                        Console.WriteLine("Ingrese apellido:");
                        string apellidoMozo = Console.ReadLine();
                        Console.WriteLine("Ingrese numero de funcionario:");
                        int numeroFun = int.Parse(Console.ReadLine());


                        Mozo dadoDeAltaValidado = s.AltaMozo(new Mozo(id, nombreMozo, apellidoMozo, numeroFun));

                        if (dadoDeAltaValidado != null)
                        {
                            Console.WriteLine("Mozo dado de alta correctamente");
                        }
                        else
                        {

                            Console.WriteLine("Algún dato no fue válido");
                        }
                        Console.ReadKey();
                        break;
                }

            }

        }

        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("-----SISTEMA DE RESTAURANTE-----");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("1 - Listar todos los platos");
            Console.WriteLine("2 - Listado de clientes ordenados por apellido");
            Console.WriteLine("3 - Listado de servicios hechos por un repartidor en cierta fecha");
            Console.WriteLine("4 - Modificar precio mínimo del plato");
            Console.WriteLine("5 - Alta mozo");
        }
    }
}
    

