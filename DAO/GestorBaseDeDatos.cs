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
        public GestorBaseDeDatos GestorBaseDeDatosSG 
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
        private DataSet ds;
        
        private Dictionary<string, SqlDataAdapter> DiccionarioDeAdaptadores = new Dictionary<string, SqlDataAdapter>();
        public GestorBaseDeDatos()
        {
            ds = new DataSet();
            using (SqlConnection cone = new SqlConnection("Data Source=.;Initial Catalog=AndSalesForAll_DB;Integrated Security=True"))
            {
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
                    adapter.Fill(ds, $"{Row["TABLE_NAME"]}");
                    int CantidadRegistros = ds.Tables[$"{Row["TABLE_NAME"]}"].Rows.Count;
                    //Este If chequea los casos cuando sea una Tabla Normal y Una Tabla Intermedia, por estandar todas las tablas intermedias
                    //deben tener como maximo 2 registros que serian las PK de las 2 tablas que esten relacionadas
                    if (CantidadRegistros == 2)
                    {
                        ds.Tables[$"{"TABLE_NAME"}"].PrimaryKey = new DataColumn[] { ds.Tables[$"{Row["TABLE_NAME"]}"].Columns[0], ds.Tables[$"{Row["TABLE_NAME"]}"].Columns[1] };
                    }
                    else
                    {
                        ds.Tables[$"{"TABLE_NAME"}"].PrimaryKey = new DataColumn[] { ds.Tables[$"{Row["TABLE_NAME"]}"].Columns[0] };
                    }
                    DiccionarioDeAdaptadores.Add((Row["TABLE_NAME"] as string), adapter);
                }
            }
        }


    }
}
