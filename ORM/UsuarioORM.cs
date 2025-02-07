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
            nuevaFila["Username"] = UsuarioAlta.Username;
            nuevaFila["Nombre"] = UsuarioAlta.Nombre;
            nuevaFila["Apellido"] = UsuarioAlta.Apellido;
            nuevaFila["DNI"] = UsuarioAlta.DNI;
            nuevaFila["Contraseña"] = UsuarioAlta.Contraseña;
            nuevaFila["Email"] = UsuarioAlta.Email;
            nuevaFila["Rol"] = UsuarioAlta.Rol;
            nuevaFila["Intentos"] = UsuarioAlta.Intentos;
            nuevaFila["IsBloqueado"] = UsuarioAlta.IsBloqueado;
            GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario").Rows.Add(nuevaFila);
            ActualizarGeneral();
        }
        public void Baja(Usuario UsuarioEliminar)
        {
            GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario").Rows.Find(UsuarioEliminar.ID_Usuario).Delete();
            ActualizarGeneral();
        }
        public void Modificar(Usuario UsuarioModdificado)
        {
            GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario").Rows.Find(UsuarioModdificado.ID_Usuario).ItemArray = new object[] 
            {
                UsuarioModdificado.ID_Usuario,
                UsuarioModdificado.Username,
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
        public List<Usuario> ObtenerUsuariosPorConsulta(string tipoConsulta = "", string itemSeleccionado = "", string itemValor = "", string itemValor2 = "")
        {
            List<Usuario> ListaUsuario = new List<Usuario>();
            DataView dv;
            string query = "";
            switch (tipoConsulta)
            {
                case "Simple":
                    query = $"{itemSeleccionado} = '{itemValor}'";
                    break;
                case "D-H":
                    query = $"{itemSeleccionado} >= '{itemValor}' AND {itemSeleccionado} <= '{itemValor2}'";
                    break;
                case "Incremental":
                    query = $"{itemSeleccionado} LIKE '{itemValor}%'";
                    break;
            }
            dv = new DataView(GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Usuario"),query,"",DataViewRowState.Unchanged);
            foreach(DataRowView drv in dv)
            {
              int id = int.Parse(drv[0].ToString());
              string username = drv[1].ToString();
              string nombre = drv[2].ToString();
              string apellido = drv[3].ToString();
              string dni = drv[4].ToString();
              string contrasena = drv[5].ToString();
              string email = drv[6].ToString();
              string rol = drv[7].ToString(); //Cuando se implemente el patron Composite para los patrones se deberá cambiar el mapeado del rol en si
              int intentos = int.Parse(drv[8].ToString());
              bool isbloqueado = bool.Parse(drv[9].ToString());
              Usuario usuario = new Usuario(id,username, nombre,apellido,dni,contrasena,email,rol,intentos,isbloqueado);
              ListaUsuario.Add(usuario);
            }
            return ListaUsuario;
        }
        public void ActualizarGeneral()
        {
            GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarGeneral();
        }
    }
}
