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
    public class BitacoraBLL
    {

        public void AltaEvento(string Modulo, string Descripcion, int Criticidad)
        {  
            BitacoraORM GestorBitacora = new BitacoraORM();
            if(SesionManager.GestorSesion.UsuarioSesion != null)
            {
              BitacoraBE bitacora = new BitacoraBE(SesionManager.GestorSesion.UsuarioSesion.Username,DateTime.Now.Date,DateTime.Now.TimeOfDay,Modulo,Descripcion,Criticidad);
              GestorBitacora.Alta(bitacora);
            }
        }

        public List<BitacoraBE> ObtenerBitacoraPorConsulta(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
        {
            BitacoraORM GestorBitacora = new BitacoraORM();
            return GestorBitacora.ObtenerEventosPorConsulta(usuarioFiltrar,moduloFiltrar,descripcionFiltrar,criticidadFiltrar,fechaInicioFiltrar,fechaFinFiltrar);
        }

    }
}
