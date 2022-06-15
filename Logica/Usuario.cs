using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Usuario : IValidacion
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }

        public Usuario(int id, string user, string pass)
        {
            idUsuario = id;
            usuario = user;
            password = pass;
        }

        public Usuario()
        {

        }

        public bool EsValido()
        {
            bool ret = false;   
            if (PasswordValida(password))
            {
                ret = true;
            }
            return ret;
        }

        public bool PasswordValida(string pass)
        {
            bool ret = false;
            bool found = false;

            if (pass.Length >= 6)
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    if (char.IsUpper(pass[i]))
                    {
                        found = true;
                    }
                }
                if (found == true)
                {
                    for (int a = 0; a < pass.Length; a++)
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
    }
}
