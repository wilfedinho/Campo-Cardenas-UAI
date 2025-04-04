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

        public void AltaEvento(string Modulo, string Descripcion, int Criticidad)
        {  
            BitacoraORM490WC GestorBitacora = new BitacoraORM490WC();
            if(SesionManager490WC.GestorSesion.UsuarioSesion != null)
            {
              BitacoraBE490WC bitacora = new BitacoraBE490WC(SesionManager490WC.GestorSesion.UsuarioSesion.Username,DateTime.Now.Date,DateTime.Now.TimeOfDay,Modulo,Descripcion,Criticidad);
              GestorBitacora.Alta(bitacora);
            }
        }

        public List<BitacoraBE490WC> ObtenerBitacoraPorConsulta(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
        {
            BitacoraORM490WC GestorBitacora = new BitacoraORM490WC();
            return GestorBitacora.ObtenerEventosPorConsulta(usuarioFiltrar,moduloFiltrar,descripcionFiltrar,criticidadFiltrar,fechaInicioFiltrar,fechaFinFiltrar);
        }

    }
}
