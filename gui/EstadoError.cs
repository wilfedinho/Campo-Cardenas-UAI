﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    public class EstadoError : Estado
    {
        FormError Error;
        public override void CerrarEstado()
        {
            Error?.Dispose();
        }

        public override void EjecutarEstado()
        {
            Error = new FormError();
            Error.ShowDialog();
        }
    }
}
