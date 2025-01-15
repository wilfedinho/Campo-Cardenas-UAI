﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class FormLogin : Form
    {
        
        private bool IsLogueado;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BT_LOGIN_Click(object sender, EventArgs e)
        {
            IsLogueado = true;
            GestorForm.gestorFormSG.DefinirEstado(new EstadoMenu());
        }

        private void BT_CERRARAPP_Click(object sender, EventArgs e)
        {
            IsLogueado = false;
            GestorForm.gestorFormSG.DefinirEstado(new EstadoCerrarAplicacion());
        }
    }
}
