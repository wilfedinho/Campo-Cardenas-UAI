using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GestorBaseDeDatos
    {
        private static GestorBaseDeDatos Instancia;
        public static GestorBaseDeDatos GestorBaseDeDatosSG 
        {
            get
            {
                if(Instancia == null)
                {
                    Instancia = new GestorBaseDeDatos();
                }
                return Instancia;
            }
        }
        private DataSet BaseDeDatosEnMemoria;
        private SqlConnection cone;
        private Dictionary<string, SqlDataAdapter> DiccionarioDeAdaptadores = new Dictionary<string, SqlDataAdapter>();
        public GestorBaseDeDatos()
        {
                BaseDeDatosEnMemoria = new DataSet();
                cone = new SqlConnection("Data Source=.;Initial Catalog=BD_PROYECTO_2025;Integrated Security=True");
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                SqlDataAdapter Adaptador = new SqlDataAdapter(query, cone);
                DataTable TablaNombreDeLasTablas = new DataTable();
                Adaptador.Fill(TablaNombreDeLasTablas);
                foreach (DataRow Row in TablaNombreDeLasTablas.Rows)
                {
                    string queryDiccionario = $"SELECT * FROM {Row["TABLE_NAME"]}";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryDiccionario, cone);
                    SqlCommandBuilder ConstructorDeComando = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = ConstructorDeComando.GetInsertCommand();
                    adapter.DeleteCommand = ConstructorDeComando.GetDeleteCommand();
                    adapter.UpdateCommand = ConstructorDeComando.GetUpdateCommand();
                    adapter.Fill(BaseDeDatosEnMemoria, $"{Row["TABLE_NAME"]}");
                    int CantidadColumna = BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns.Count;
                    //Este If chequea los casos cuando sea una Tabla Normal y Una Tabla Intermedia, por estandar todas las tablas intermedias
                    //deben tener como maximo 2 registros que serian las PK de las 2 tablas que esten relacionadas
                    if (CantidadColumna == 2)
                    {
                        BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].PrimaryKey = new DataColumn[] { BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[0], BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[1] };
                    }
                    else
                    {
                        BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].PrimaryKey = new DataColumn[] { BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[0] };
                    }
                    DiccionarioDeAdaptadores.Add((Row["TABLE_NAME"] as string), adapter);
                }
        }
        public DataTable DevolverTabla(string NombreTabla)
        {
            return BaseDeDatosEnMemoria.Tables[NombreTabla];
        }
        public void ActualizarGeneral()
        {
           foreach (KeyValuePair<string, SqlDataAdapter> ClaveValor in DiccionarioDeAdaptadores)
           {
              ClaveValor.Value.SelectCommand.Connection = cone;
              ClaveValor.Value.Update(BaseDeDatosEnMemoria, ClaveValor.Key);
              BaseDeDatosEnMemoria.Tables[ClaveValor.Key].Clear();
              DiccionarioDeAdaptadores[ClaveValor.Key].Fill(BaseDeDatosEnMemoria, ClaveValor.Key);  
           }
        }
        public void ActualizarPorTabla(string NombreTabla)
        {
            DiccionarioDeAdaptadores[NombreTabla].Update(BaseDeDatosEnMemoria, NombreTabla);
            BaseDeDatosEnMemoria.Tables[NombreTabla].Clear();
            DiccionarioDeAdaptadores[NombreTabla].Fill(BaseDeDatosEnMemoria, NombreTabla);
        }
        public void RechazarGeneral()
        {
            BaseDeDatosEnMemoria.RejectChanges();
        }
        public void RechazarPorTabla(string NombreTabla)
        {
            BaseDeDatosEnMemoria.Tables[NombreTabla].RejectChanges();
        }
        public void RechazarPorRegistro(DataRow Registro)
        {
            Registro.RejectChanges();
        }
    }
}
