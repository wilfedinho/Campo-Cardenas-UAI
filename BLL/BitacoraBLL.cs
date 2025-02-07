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
              BitacoraBE bitacora = new BitacoraBE(SesionManager.GestorSesion.UsuarioSesion.Username,DateTime.Now.Date,DateTime.Now.Hour,Modulo,Descripcion,Criticidad);
              GestorBitacora.Alta(bitacora);
            }
            else
            {
                BitacoraBE bitacora = new BitacoraBE("Sistema", DateTime.Now.Date, DateTime.Now.Hour, Modulo, Descripcion, Criticidad);
                GestorBitacora.Alta(bitacora);
            }
        }

        public List<BitacoraBE> ObtenerBitacoraPorConsulta(string tipoConsulta = "", string itemSeleccionado = "", string itemValor = "", string itemValor2 = "")
        {
            BitacoraORM GestorBitacora = new BitacoraORM();
            return GestorBitacora.ObtenerEventosPorConsulta(tipoConsulta,itemSeleccionado,itemValor,itemValor2);
        }

    }
}
