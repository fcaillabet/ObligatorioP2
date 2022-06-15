using Logica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Mozo : Persona, IValidacion 
    {

        public int NumeroFuncionario { get; set; }

        public Mozo(string Nombre, string Apellido, int numeroFuncionario)
        {
            id = Sistema.ultimoIdPersona;
            Sistema.ultimoIdPersona++;
            nombre = Nombre;
            apellido = Apellido;
            NumeroFuncionario = numeroFuncionario;
        }

        public Mozo()
        {

        }

        public bool validarString(string palabra)
        {
            bool ret = true;

            if (palabra != "")
            {
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
            if (validarString(nombre) && validarString(apellido))
            {
                ret = true;
            }
            return ret;
        }
    }
}
