using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Mozo : IValidacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumeroFuncionario { get; set; }

        public Mozo(int id, string nombre, string apellido, int numeroFuncionario)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NumeroFuncionario = numeroFuncionario;
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
            if (validarString(Nombre) && validarString(Apellido))
            {
                ret = true;
            }
            return ret;
        }
    }
}
