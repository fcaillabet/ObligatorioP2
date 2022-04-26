using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Cliente : IValidacion, IComparable<Cliente>
    {
        public static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Cliente(string nombre, string apellido, string email, string password)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }

        public List<Cliente> clienteServicio = new List<Cliente>();

        public List<Cliente> CrearListaClientes(Cliente cliente)
        {
            if (cliente != null)
            {
                clienteServicio.Clear();
                clienteServicio.Add(cliente);
            }
            return clienteServicio;
        }

        public bool emailValido(string mail)
        {
            bool ret = false;
            if (mail != null)
            {
                if (mail.Contains("@"))
                {
                    if (mail.StartsWith("@") || mail.EndsWith("@"))
                    {
                        ret = false;
                    } else 
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        public bool passwordValida(string pass)
        {
            bool ret = false;
            bool found = false;
            
            if (pass.Length >= 6)
            {
                for (int i = 1; i < pass.Length; i++)
                {
                    if (char.IsUpper(pass[i]))
                    {
                        found = true;  
                    }
                }
                if (found == true)
                {
                    for (int a = 1; a < pass.Length; a++)
                    {
                        if (char.IsLower(pass[a]))
                        {
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }

        public bool validarString(string palabra)
        {
            bool ret = false;

            if (palabra != "")
            {
            for (int i = 1; i < palabra.Length; i++)
            {
                if (char.IsNumber(palabra[i]))
                {
                    ret = true;
                }
            }
            }
            return ret;
        }

        public bool EsValido()
        {
            bool ret = false;
            if (validarString(Nombre) && validarString(Apellido) && emailValido(Email) && passwordValida(Password))
            {
                ret = true;
            }
            return ret;
        }

       
        public override string ToString()
        {
            return $"{Id} {Apellido} {Nombre}";
        }

        public int CompareTo(Cliente other)
        {
            if (Apellido.CompareTo(other.Apellido) > 0)
            {
                return 1;
            }
            else if (Apellido.CompareTo(other.Apellido) < 0)
            {
                return -1;
            }
            else
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
}
