using Logica;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Cliente : Persona, IValidacion, IComparable<Cliente>
    {

        public string Email { get; set; }

        public Cliente(string Nombre, string Apellido, string email)
        {
            id = Sistema.ultimoIdPersona;
            Sistema.ultimoIdPersona++;
            nombre = Nombre;
            apellido = Apellido;
            Email = email;
        }

        public Cliente()
        {

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

        

        public bool validarString(string palabra)
        {
            bool ret = false;

            if (palabra != "")
            {
                ret = true;
            for (int i = 1; i < palabra.Length; i++)
            {
                if (char.IsNumber(palabra[i]))
                {
                    ret = false;
                }
            }
            }
            return ret;
        }

        public bool EsValido()
        {
            bool ret = false;
            if (validarString(nombre) && validarString(apellido) && emailValido(Email))
            {
                ret = true;
            }
            return ret;
        }

       
        public override string ToString()
        {
            return $"{id} {apellido} {nombre}";
        }

        public int CompareTo(Cliente other)
        {
            if (apellido.CompareTo(other.apellido) > 0)
            {
                return 1;
            }
            else if (apellido.CompareTo(other.apellido) < 0)
            {
                return -1;
            }
            else
            {
                if (nombre.CompareTo(other.nombre) > 0)
                {
                    return 1;
                }
                else if (nombre.CompareTo(other.nombre) < 0)
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
