using System;
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
    public class UsuarioORM
    {
        private static UsuarioORM Instancia;
        public static UsuarioORM GestorUsuarioORM 
        {
            get 
            {
                if(Instancia== null)
                {
                    Instancia = new UsuarioORM();
                }
                return Instancia;
            }
        }
        public void Alta(Usuario UsuarioAlta)
        {
            DataRow nuevaFila = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario").NewRow();
            nuevaFila["ID"] = UsuarioAlta.ID_Usuario;
            nuevaFila["Nombre"] = UsuarioAlta.Nombre;
            nuevaFila["Apellido"] = UsuarioAlta.Apellido;
            nuevaFila["DNI"] = UsuarioAlta.DNI;
            nuevaFila["Contrasena"] = UsuarioAlta.Contraseña;
            nuevaFila["Email"] = UsuarioAlta.Email;
            nuevaFila["Rol"] = UsuarioAlta.Rol;
            nuevaFila["Intentos"] = UsuarioAlta.Intentos;
            nuevaFila["IsBloqueado"] = UsuarioAlta.IsBloqueado;
            GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario").Rows.Add(nuevaFila);
            ActualizarGeneral();
        }
        //La baja de los usuarios seria logica por eso no se elimina el registro si no que activamos la variable bool "IsBloqueado"
        public void Baja(Usuario UsuarioEliminar)
        {
            GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario").Rows.Find(UsuarioEliminar.ID_Usuario).SetField<int>(8,1);
            ActualizarGeneral();
        }
        public void Modificar(Usuario UsuarioModdificado)
        {
            GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario").Rows.Find(UsuarioModdificado.ID_Usuario).ItemArray = new object[] 
            {
                UsuarioModdificado.ID_Usuario,
                UsuarioModdificado.Nombre,
                UsuarioModdificado.Apellido,
                UsuarioModdificado.DNI,
                UsuarioModdificado.Contraseña,
                UsuarioModdificado.Email,
                UsuarioModdificado.Rol,
                UsuarioModdificado.Intentos,
                UsuarioModdificado.IsBloqueado,
            };
            ActualizarGeneral();
        }
        public List<Usuario> DevolverLosUsuariosPorConsulta(string query = "")
        {
            List<Usuario> ListaUsuario = new List<Usuario>();
            DataView dv;
            if(query != "")
            {
                dv = new DataView(GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario"),query,"",DataViewRowState.Unchanged);
                foreach(DataRowView drv in dv)
                {
                    int id = int.Parse(drv[0].ToString());
                    string nombre = drv[1].ToString();
                    string apellido = drv[2].ToString();
                    string dni = drv[3].ToString();
                    string contrasena = drv[4].ToString();
                    string email = drv[5].ToString();
                    string rol = drv[6].ToString(); //Cuando se implemente el patron Composite para los patrones se deberá cambiar el mapeado del rol en si
                    int intentos = int.Parse(drv[7].ToString());
                    bool isbloqueado = bool.Parse(drv[8].ToString());
                    Usuario usuario = new Usuario(id,nombre,apellido,dni,contrasena,email,rol,intentos,isbloqueado);
                    ListaUsuario.Add(usuario);
                }
            }
            else
            {
                dv = new DataView(GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario"),"", "", DataViewRowState.Unchanged);
                foreach (DataRowView drv in dv)
                {
                    int id = int.Parse(drv[0].ToString());
                    string nombre = drv[1].ToString();
                    string apellido = drv[2].ToString();
                    string dni = drv[3].ToString();
                    string contrasena = drv[4].ToString();
                    string email = drv[5].ToString();
                    string rol = drv[6].ToString(); //Cuando se implemente el patron Composite para los patrones se deberá cambiar el mapeado del rol en si
                    int intentos = int.Parse(drv[7].ToString());
                    bool isbloqueado = bool.Parse(drv[8].ToString());
                    Usuario usuario = new Usuario(id, nombre, apellido, dni, contrasena, email, rol, intentos, isbloqueado);
                    ListaUsuario.Add(usuario);
                }
            }
            return ListaUsuario;
        }
        public void ActualizarGeneral()
        {
            GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarGeneral();
        }
    }
}
