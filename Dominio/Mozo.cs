using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Mozo : Sistema
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

        public bool esValido()
        {
            bool ret = false;
            if (validarString(Nombre) && validarString(Apellido) && numeroNoExiste(NumeroFuncionario))
            {
                ret = true;
            }
            return ret;
        }
    }
}
