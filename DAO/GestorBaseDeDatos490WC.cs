using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GestorBaseDeDatos490WC
    {
        private static GestorBaseDeDatos490WC Instancia490WC;
        public static GestorBaseDeDatos490WC GestorBaseDeDatosSG490WC 
        {
            get
            {
                if(Instancia490WC == null)
                {
                    Instancia490WC = new GestorBaseDeDatos490WC();
                }
                return Instancia490WC;
            }
        }
        private DataSet BaseDeDatosEnMemoria490WC;
        private SqlConnection cone490WC;
        private Dictionary<string, SqlDataAdapter> DiccionarioDeAdaptadores490WC = new Dictionary<string, SqlDataAdapter>();
        public GestorBaseDeDatos490WC()
        {
                BaseDeDatosEnMemoria490WC = new DataSet();
                cone490WC = new SqlConnection("Data Source=.;Initial Catalog=BD_PROYECTO_2025490WC;Integrated Security=True");
                string query490WC = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                SqlDataAdapter Adaptador490WC = new SqlDataAdapter(query490WC, cone490WC);
                DataTable TablaNombreDeLasTablas490WC = new DataTable();
                Adaptador490WC.Fill(TablaNombreDeLasTablas490WC);
                foreach (DataRow Row490WC in TablaNombreDeLasTablas490WC.Rows)
                {
                    string queryDiccionario490WC = $"SELECT * FROM {Row490WC["TABLE_NAME"]}";
                    SqlDataAdapter adapter490WC = new SqlDataAdapter(queryDiccionario490WC, cone490WC);
                    SqlCommandBuilder ConstructorDeComando490WC = new SqlCommandBuilder(adapter490WC);
                    adapter490WC.InsertCommand = ConstructorDeComando490WC.GetInsertCommand();
                    adapter490WC.DeleteCommand = ConstructorDeComando490WC.GetDeleteCommand();
                    adapter490WC.UpdateCommand = ConstructorDeComando490WC.GetUpdateCommand();
                    adapter490WC.Fill(BaseDeDatosEnMemoria490WC, $"{Row490WC["TABLE_NAME"]}");
                    int CantidadColumna490WC = BaseDeDatosEnMemoria490WC.Tables[$"{Row490WC["TABLE_NAME"]}"].Columns.Count;
                    if (CantidadColumna490WC == 2)
                    {
                        BaseDeDatosEnMemoria490WC.Tables[$"{Row490WC["TABLE_NAME"]}"].PrimaryKey = new DataColumn[] { BaseDeDatosEnMemoria490WC.Tables[$"{Row490WC["TABLE_NAME"]}"].Columns[0], BaseDeDatosEnMemoria490WC.Tables[$"{Row490WC["TABLE_NAME"]}"].Columns[1] };
                    }
                    else
                    {
                        BaseDeDatosEnMemoria490WC.Tables[$"{Row490WC["TABLE_NAME"]}"].PrimaryKey = new DataColumn[] { BaseDeDatosEnMemoria490WC.Tables[$"{Row490WC["TABLE_NAME"]}"].Columns[0] };
                    }
                    DiccionarioDeAdaptadores490WC.Add((Row490WC["TABLE_NAME"] as string), adapter490WC);
                }
        }
        public DataTable DevolverTabla490WC(string NombreTabla490WC)
        {
            return BaseDeDatosEnMemoria490WC.Tables[NombreTabla490WC];
        }
        public void ActualizarGeneral490WC()
        {
           foreach (KeyValuePair<string, SqlDataAdapter> ClaveValor490WC in DiccionarioDeAdaptadores490WC)
           {
              ClaveValor490WC.Value.SelectCommand.Connection = cone490WC;
              ClaveValor490WC.Value.Update(BaseDeDatosEnMemoria490WC, ClaveValor490WC.Key);
              BaseDeDatosEnMemoria490WC.Tables[ClaveValor490WC.Key].Clear();
              DiccionarioDeAdaptadores490WC[ClaveValor490WC.Key].Fill(BaseDeDatosEnMemoria490WC, ClaveValor490WC.Key);  
           }
        }
        public void ActualizarPorTabla490WC(string NombreTabla490WC)
        {
            DiccionarioDeAdaptadores490WC[NombreTabla490WC].Update(BaseDeDatosEnMemoria490WC, NombreTabla490WC);
            BaseDeDatosEnMemoria490WC.Tables[NombreTabla490WC].Clear();
            DiccionarioDeAdaptadores490WC[NombreTabla490WC].Fill(BaseDeDatosEnMemoria490WC, NombreTabla490WC);
        }
        public void RechazarGeneral490WC()
        {
            BaseDeDatosEnMemoria490WC.RejectChanges();
        }
        public void RechazarPorTabla490WC(string NombreTabla490WC)
        {
            BaseDeDatosEnMemoria490WC.Tables[NombreTabla490WC].RejectChanges();
        }
        public void RechazarPorRegistro490WC(DataRow Registro490WC)
        {
            Registro490WC.RejectChanges();
        }
    }
}
