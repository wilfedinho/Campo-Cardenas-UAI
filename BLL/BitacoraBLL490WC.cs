using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BitacoraBLL490WC
    {

        public void AltaEvento490WC(string Modulo490WC, string Descripcion490WC, int Criticidad490WC)
        {  
            BitacoraORM490WC GestorBitacora490WC = new BitacoraORM490WC();
            if(SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC != null)
            {
              BitacoraBE490WC bitacora490WC = new BitacoraBE490WC(SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Username490WC,DateTime.Now.Date,DateTime.Now.TimeOfDay,Modulo490WC,Descripcion490WC,Criticidad490WC);
              GestorBitacora490WC.Alta490WC(bitacora490WC);
            }
        }

        public List<BitacoraBE490WC> ObtenerBitacoraPorConsulta490WC(string usuarioFiltrar490WC = "", string moduloFiltrar490WC = "", string descripcionFiltrar490WC = "", string criticidadFiltrar490WC = "", DateTime? fechaInicioFiltrar490WC = null, DateTime? fechaFinFiltrar490WC = null)
        {
            BitacoraORM490WC GestorBitacora490WC = new BitacoraORM490WC();
            return GestorBitacora490WC.ObtenerEventosPorConsulta490WC(usuarioFiltrar490WC,moduloFiltrar490WC,descripcionFiltrar490WC,criticidadFiltrar490WC,fechaInicioFiltrar490WC,fechaFinFiltrar490WC);
        }

    }
}
