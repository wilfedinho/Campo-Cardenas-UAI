﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class SesionManager
    {
        private static SesionManager Instancia;

        public Usuario UsuarioSesion;

        public static SesionManager GestorSesion
        {
            get 
            {
              if(Instancia == null)
              {
                    Instancia = new SesionManager();
              }
              return Instancia;
            }
        }

        public void Login(Usuario UsuarioLoguear)
        {
            if(GestorSesion.UsuarioSesion == null)
            {
                GestorSesion.UsuarioSesion = UsuarioLoguear;
            }
        }
        public void Logout()
        {
            if(GestorSesion.UsuarioSesion != null)
            {
                GestorSesion.UsuarioSesion = null;
            }
        }
    }
}
