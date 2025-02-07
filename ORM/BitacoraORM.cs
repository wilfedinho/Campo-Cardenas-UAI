using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class BitacoraORM
    {
        public void Alta(BitacoraBE BitacoraAlta)
        {
            DataRow drBitacora = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Bitacora").NewRow();
            drBitacora["IdBitacora"] = BitacoraAlta.IdBitacora;
            drBitacora["Username"] = BitacoraAlta.Username;
            drBitacora["Fecha"] = BitacoraAlta.Fecha;
            drBitacora["Hora"] = BitacoraAlta.Hora;
            drBitacora["Modulo"] = BitacoraAlta.Modulo;
            drBitacora["Descripcion"] = BitacoraAlta.Descripcion;
            drBitacora["Criticidad"] = BitacoraAlta.Criticidad;
            GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Bitacora").Rows.Add(drBitacora);
            GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarGeneral();
        }

        public List<BitacoraBE> ObtenerEventosPorConsulta(string tipoConsulta = "", string itemSeleccionado = "", string itemValor = "", string itemValor2 = "")
        {
            List<BitacoraBE> ListaBitacora = new List<BitacoraBE>();
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
            dv = new DataView(GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Bitacora"), query, "", DataViewRowState.Unchanged);
            foreach (DataRowView drv in dv)
            {
                int idBitacora = int.Parse(drv[0].ToString());
                string username = drv[1].ToString();
                DateTime fecha = DateTime.Parse(drv[2].ToString()).Date;
                int hora = DateTime.Parse(drv[3].ToString()).Hour;
                string Modulo = drv[4].ToString();
                string Descripcion = drv[5].ToString();
                int Criticidad = int.Parse(drv[6].ToString());
                BitacoraBE bitacora = new BitacoraBE(username,fecha,hora,Modulo,Descripcion,Criticidad,idBitacora);
                ListaBitacora.Add(bitacora);
            }
            return ListaBitacora;
        }

    }
}
