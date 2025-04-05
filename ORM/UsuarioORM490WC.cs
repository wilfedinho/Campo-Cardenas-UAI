﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace ORM
{
    public class UsuarioORM490WC
    {
        private static UsuarioORM490WC Instancia490WC;
        public static UsuarioORM490WC GestorUsuarioORM490WC 
        {
            get 
            {
                if(Instancia490WC== null)
                {
                    Instancia490WC = new UsuarioORM490WC();
                }
                return Instancia490WC;
            }
        }
        public void Alta490WC(Usuario490WC UsuarioAlta490WC)
        {
            DataRow nuevaFila490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Usuario490WC").NewRow();
            nuevaFila490WC["ID490WC"] = UsuarioAlta490WC.ID_Usuario490WC;
            nuevaFila490WC["Username490WC"] = UsuarioAlta490WC.Username490WC;
            nuevaFila490WC["Nombre490WC"] = UsuarioAlta490WC.Nombre490WC;
            nuevaFila490WC["Apellido490WC"] = UsuarioAlta490WC.Apellido490WC;
            nuevaFila490WC["DNI490WC"] = UsuarioAlta490WC.DNI490WC;
            nuevaFila490WC["Contraseña490WC"] = UsuarioAlta490WC.Contraseña490WC;
            nuevaFila490WC["Email490WC"] = UsuarioAlta490WC.Email490WC;
            nuevaFila490WC["Rol490WC"] = UsuarioAlta490WC.Rol490WC;
            nuevaFila490WC["IdiomaUsuario490WC"] = UsuarioAlta490WC.IdiomaUsuario490WC;
            nuevaFila490WC["Intentos490WC"] = UsuarioAlta490WC.Intentos490WC;
            nuevaFila490WC["IsBloqueado490WC"] = UsuarioAlta490WC.IsBloqueado490WC;
            GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Usuario490WC").Rows.Add(nuevaFila490WC);
            ActualizarGeneral490WC();
        }
        public void Baja490WC(Usuario490WC UsuarioEliminar490WC)
        {
            GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Usuario490WC").Rows.Find(UsuarioEliminar490WC.ID_Usuario490WC).Delete();
            ActualizarGeneral490WC();
        }
        public void Modificar490WC(Usuario490WC UsuarioModdificado490WC)
        {
            GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Usuario490WC").Rows.Find(UsuarioModdificado490WC.ID_Usuario490WC).ItemArray = new object[] 
            {
                UsuarioModdificado490WC.ID_Usuario490WC,
                UsuarioModdificado490WC.Username490WC,
                UsuarioModdificado490WC.Nombre490WC,
                UsuarioModdificado490WC.Apellido490WC,
                UsuarioModdificado490WC.DNI490WC,
                UsuarioModdificado490WC.Contraseña490WC,
                UsuarioModdificado490WC.Email490WC,
                UsuarioModdificado490WC.Rol490WC,
                UsuarioModdificado490WC.IdiomaUsuario490WC,
                UsuarioModdificado490WC.Intentos490WC,
                UsuarioModdificado490WC.IsBloqueado490WC,
            };
            ActualizarGeneral490WC();
        }
        public List<Usuario490WC> ObtenerUsuariosPorConsulta490WC(string tipoConsulta490WC = "", string itemSeleccionado490WC = "", string itemValor490WC = "", string itemValor2490WC = "")
        {
            List<Usuario490WC> ListaUsuario490WC = new List<Usuario490WC>();
            DataView dv490WC;
            string query490WC = "";
            switch (tipoConsulta490WC)
            {
                case "Simple490WC":
                    query490WC = $"{itemSeleccionado490WC} = '{itemValor490WC}'";
                    break;
                case "D-H490WC":
                    query490WC = $"{itemSeleccionado490WC} >= '{itemValor490WC}' AND {itemSeleccionado490WC} <= '{itemValor2490WC}'";
                    break;
                case "Incremental490WC":
                    query490WC = $"{itemSeleccionado490WC} LIKE '{itemValor490WC}%'";
                    break;
            }
            dv490WC = new DataView(GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Usuario490WC"),query490WC,"",DataViewRowState.Unchanged);
            foreach(DataRowView drv490WC in dv490WC)
            {
              int id490WC = int.Parse(drv490WC[0].ToString());
              string username490WC = drv490WC[1].ToString();
              string nombre490WC = drv490WC[2].ToString();
              string apellido490WC = drv490WC[3].ToString();
              string dni490WC = drv490WC[4].ToString();
              string contrasena490WC = drv490WC[5].ToString();
              string email490WC = drv490WC[6].ToString();
              string rol490WC = drv490WC[7].ToString(); 
              string idioma490WC = drv490WC[8].ToString(); 
              int intentos490WC = int.Parse(drv490WC[9].ToString());
              bool isbloqueado490WC = bool.Parse(drv490WC[10].ToString());
              Usuario490WC usuario490WC = new Usuario490WC(id490WC,username490WC, nombre490WC,apellido490WC,dni490WC,contrasena490WC,email490WC,rol490WC,idioma490WC,intentos490WC,isbloqueado490WC);
              ListaUsuario490WC.Add(usuario490WC);
            }
            return ListaUsuario490WC;
        }
        public void ActualizarGeneral490WC()
        {
            GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.ActualizarGeneral490WC();
        }
    }
}
