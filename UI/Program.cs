using Dominio;
using System;
using System.Collections.Generic;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
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
                            Console.Clear();
                            Console.WriteLine("ID  Nombre  Precio");
                            Console.WriteLine("-------------------");
                            if (s.ListaPlatosCheck())
                            {
                            Console.WriteLine("No existen platos.");
                            } else {
                            foreach (Plato p in s.GetPlatos())
                            {
                                Console.WriteLine(p);
                            }
                            }
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Precione cualquier tecla para volver al menú.");
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("ID  Apellido  Nombre");
                            Console.WriteLine("-------------------");
                            if (s.ListaClientesCheck())
                            {
                                Console.WriteLine("No existen clientes.");
                            }
                            else
                            {
                            foreach (Cliente c in s.GetClientes())
                            {
                                Console.WriteLine(c);
                            }
                            }
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Precione cualquier tecla para volver al menú.");
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("///////////////////BUSQUEDA/////////////////////");
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Ingrese el id de un repartidor:");
                            int idRepartidor = int.Parse(Console.ReadLine());
                        

                            Console.WriteLine("Ingrese fecha de inicio:");
                            DateTime f1 = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese fecha de fin:");
                            DateTime f2 = DateTime.Parse(Console.ReadLine());


                            List<Servicio> ListaFiltrada = s.GetServiciosRangoFecha(idRepartidor, f1, f2);

                            if (ListaFiltrada.Count > 0)
                            {
                                foreach (Servicio serv in ListaFiltrada)
                                {
                                    Console.Clear();
                                    Console.WriteLine("///////////////////BUSQUEDA/////////////////////");
                                    Console.WriteLine("----------------------------------------------");
                                    Console.WriteLine(serv);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("///////////////////BUSQUEDA/////////////////////");
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("No hay registros.");
                            }
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Precione cualquier tecla para volver al menú.");
                            Console.ReadKey();
                            break;


                        case 4:
                            Console.Clear();
                            Console.WriteLine("/////////////CAMBIO PRECIO MÍNIMO/////////////////");
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Ingrese un monto:");
                            double monto = Double.Parse(Console.ReadLine());

                            if (s.setPrecioMin(monto))
                            {
                                Console.Clear();
                                Console.WriteLine("/////////////CAMBIO PRECIO MÍNIMO/////////////////");
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("Precio mínimo cambiado a " + monto);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("/////////////CAMBIO PRECIO MÍNIMO/////////////////");
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("No se ha podido cambiar.");
                            }
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Precione cualquier tecla para volver al menú.");
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine("//////////////////ALTA MOZO///////////////////");
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("");
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
                                Console.Clear();
                                Console.WriteLine("//////////////////ALTA MOZO///////////////////");
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("Mozo dado de alta correctamente.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("//////////////////ALTA MOZO///////////////////");
                                Console.WriteLine("----------------------------------------------");
                                Console.WriteLine("Algún dato no fue válido.");
                            }
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Precione cualquier tecla para volver al menú.");
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
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Sistema creado por Felipe Caillabet");
            }
        }
    }




