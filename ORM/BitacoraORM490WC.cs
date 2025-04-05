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
    public class BitacoraORM490WC
    {
        public void Alta490WC(BitacoraBE490WC BitacoraAlta490WC)
        {
            DataRow drBitacora490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Bitacora490WC").NewRow();
            drBitacora490WC["IdBitacora490WC"] = BitacoraAlta490WC.IdBitacora490WC;
            drBitacora490WC["Username490WC"] = BitacoraAlta490WC.Username490WC;
            drBitacora490WC["Fecha490WC"] = BitacoraAlta490WC.Fecha490WC;
            drBitacora490WC["Hora490WC"] = BitacoraAlta490WC.Hora490WC;
            drBitacora490WC["Modulo490WC"] = BitacoraAlta490WC.Modulo490WC;
            drBitacora490WC["Descripcion490WC"] = BitacoraAlta490WC.Descripcion490WC;
            drBitacora490WC["Criticidad490WC"] = BitacoraAlta490WC.Criticidad490WC;
            GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Bitacora490WC").Rows.Add(drBitacora490WC);
            GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.ActualizarGeneral490WC();
        }

        public List<BitacoraBE490WC> ObtenerEventosPorConsulta490WC(string usuarioFiltrar490WC = "", string moduloFiltrar490WC = "", string descripcionFiltrar490WC = "", string criticidadFiltrar490WC = "", DateTime? fechaInicioFiltrar490WC = null, DateTime? fechaFinFiltrar490WC = null)
        {
            List<BitacoraBE490WC> ListaBitacora490WC = new List<BitacoraBE490WC>();
            List<string> filtros490WC = new List<string>();
            DataView dv490WC = new DataView(GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Bitacora490WC"), "", "", DataViewRowState.Unchanged);

            if (!string.IsNullOrEmpty(usuarioFiltrar490WC))
                filtros490WC.Add($"Username = '{usuarioFiltrar490WC}'");
            if (!string.IsNullOrEmpty(moduloFiltrar490WC))
                filtros490WC.Add($"Modulo = '{moduloFiltrar490WC}'");
            if (!string.IsNullOrEmpty(descripcionFiltrar490WC))
                filtros490WC.Add($"Descripcion = '{descripcionFiltrar490WC}'");
            if (!string.IsNullOrEmpty(criticidadFiltrar490WC))
                filtros490WC.Add($"Criticidad = '{criticidadFiltrar490WC}'");
            if (fechaInicioFiltrar490WC.HasValue)
                filtros490WC.Add($"Fecha >= '{fechaInicioFiltrar490WC.Value}'");
            if (fechaFinFiltrar490WC.HasValue)
                filtros490WC.Add($"Fecha <= '{fechaFinFiltrar490WC.Value}'");
            dv490WC.RowFilter = string.Join(" AND ", filtros490WC);
            foreach (DataRowView drv490WC in dv490WC)
            {
                int idBitacora490WC = int.Parse(drv490WC[0].ToString());
                string username490WC = drv490WC[1].ToString();
                DateTime fecha490WC = DateTime.Parse(drv490WC[2].ToString()).Date;
                TimeSpan hora490WC = TimeSpan.Parse(drv490WC[3].ToString());
                string Modulo490WC = drv490WC[4].ToString();
                string Descripcion490WC = drv490WC[5].ToString();
                int Criticidad490WC = int.Parse(drv490WC[6].ToString());
                BitacoraBE490WC bitacora490WC = new BitacoraBE490WC(username490WC,fecha490WC,hora490WC,Modulo490WC,Descripcion490WC,Criticidad490WC,idBitacora490WC);
                ListaBitacora490WC.Add(bitacora490WC);
            }
            return ListaBitacora490WC;
        }

    }
}
