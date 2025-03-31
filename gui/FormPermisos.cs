using BE;
using BLL;
using Microsoft.VisualBasic;
using SERVICIOS;
using System;
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
    public partial class FormPermisos : Form, iObserverLenguaje
    {
        string adminRolNombre = "AdminSistema";
       
        public FormPermisos()
        {
            InitializeComponent();
            RecargarTodasLasVistas();
        }
        #region Carga del Formulario
        private void RecargarTodasLasVistas() 
        {
            CB_Familias.SelectedIndex = -1;
            CargarPermisos();
            CargarArbol();
            CargarFamilias();
        }
        public void CargarPermisos() 
        {
            listaPermisos.Items.Clear();
            PermisoBLL GestorPermiso = new PermisoBLL();
            var permisos = GestorPermiso.ObtenerTodoSinRoles();
            listaPermisos.Items.AddRange(permisos.Select(p => p.obtenerPermisoNombre()).Where(nombre => nombre != adminRolNombre).ToArray());
        }

      
         public void CargarArbol() 
         {
             vistaPermisosArbol.Nodes.Clear();
             PermisoBLL GestorPermiso = new PermisoBLL();
             var permisosRaiz = GestorPermiso.ObtenerPermisosArbol();
             foreach(var permiso in permisosRaiz) 
             {
                 var nodo = new TreeNode(permiso.obtenerPermisoNombre());
                 vistaPermisosArbol.Nodes.Add(nodo);
                 CargarArbolRecursivo((PermisoCompuesto)permiso,nodo);
             }

         }

         public void CargarArbolRecursivo(PermisoCompuesto permisoActual, TreeNode nodoPadre) 
         {
             foreach(var permiso in permisoActual.PermisosIncluidos()) 
             {
                 var nodoInterno = new TreeNode(permiso.obtenerPermisoNombre());
                 nodoPadre.Nodes.Add(nodoInterno);
                 if(permiso is PermisoCompuesto permisoCompuesto) 
                 {
                     CargarArbolRecursivo(permisoCompuesto,nodoInterno);
                 }
             }
         }
        public void CargarFamilias() 
        {
           CB_Familias.Items.Clear();
           PermisoBLL GestorPermiso = new PermisoBLL();
           var permisosCompuestos = GestorPermiso.ObtenerPermisosCompuestos();
            CB_Familias.Items.AddRange(permisosCompuestos.Select(p => p.obtenerPermisoNombre()).Where(nombre => nombre != "AdminSistema").ToArray());
        }


        #endregion


        #region Comportamiento del Combobox Familia

        private void CB_Familias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CB_Familias.SelectedItem !=  null) 
            {
                if(CB_Familias.SelectedItem.ToString() == SesionManager.GestorSesion.UsuarioSesion.Rol) 
                {
                    MessageBox.Show(labelErrorRolSesion.Text);
                    CB_Familias.SelectedIndex = -1;
                }
                else 
                {
                    LimpiarTodasSeleccionesPermisos();
                    if(CB_Familias.SelectedItem != null) 
                    {
                        PermisoBLL GestorPermiso = new PermisoBLL();
                        List<Permiso> permisosRaices = GestorPermiso.ObtenerPermisosArbol();
                        Permiso seleccionado = permisosRaices.Find(x => x.obtenerPermisoNombre() == CB_Familias.SelectedItem.ToString());
                        if(seleccionado is PermisoCompuesto permisoCompuesto) 
                        {
                            ChequearPermisosEnLista(permisoCompuesto);
                        }
                    }
                }
            }
        }
        public void ChequearPermisosEnLista(PermisoCompuesto Raiz) 
        {
            foreach(Permiso p in Raiz.PermisosIncluidos()) 
            {
                int indice = listaPermisos.Items.IndexOf(p.obtenerPermisoNombre());
                if(indice != -1) 
                {
                    listaPermisos.SetItemChecked(indice,true);
                }
                if(p is PermisoCompuesto permisoCompuesto) 
                {
                    ChequearPermisosEnLista(permisoCompuesto);
                }
            }
        
        }


        public void LimpiarTodasSeleccionesPermisos() 
        {
            for(int i = 0; i < listaPermisos.Items.Count; i++) 
            {
                listaPermisos.SetItemChecked(i,false);
            }
        }
        #endregion


        #region Botones

        public void CrearPermisoCompuesto(string nombrePermiso, bool esRol) 
        {
            List<string> items = GenerarLista();
            PermisoBLL GestorPermiso = new PermisoBLL();
            if(GestorPermiso.AgregarPermisoCompuesto(nombrePermiso,items,true) == false) 
            {
                MessageBox.Show(labelErrorPermisoDuplicado.Text);
            }
            else 
            {
                MessageBox.Show(labelPermisoCreado.Text);
            }
        }
        

        public List<string> GenerarLista() 
        {
            List<string> items = new List<string>();
            foreach (var CI in listaPermisos.CheckedItems)
            {
                items.Add(CI.ToString());
            }
            return items;

        }
        private void BT_ElimiarSeleccionado_Click(object sender, EventArgs e)
        {
            if(CB_Familias.SelectedItem.ToString() == adminRolNombre) 
            {
                MessageBox.Show(labelNoSePuedeSeleccionarElRolAdmin.Text);
            }
            else 
            {
                string cuestion = labelDeseaBorrarLaFamilia.Text;
                cuestion = cuestion.Replace("{CB_Familias.SelectedItem.ToString()}", CB_Familias.SelectedItem.ToString());
                DialogResult resultado = MessageBox.Show(cuestion, "",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(resultado == DialogResult.Yes) 
                {
                   PermisoBLL GestorPermiso = new PermisoBLL();
                    if(GestorPermiso.BorrarPermiso(CB_Familias.SelectedItem.ToString()) == true) 
                    {
                        BitacoraBLL GestorBitacora = new BitacoraBLL();
                        GestorBitacora.AltaEvento("Gestion de Permisos","Se borro un permiso", 5);
                    }
                    RecargarTodasLasVistas();
                }
            }
        }


        #endregion

        private void BT_ModificarNombre_Click(object sender, EventArgs e)
        {
            if (CB_Familias.SelectedItem.ToString() == adminRolNombre)
            {
                MessageBox.Show(labelNoSePuedeSeleccionarElRolAdmin.Text);
            }
            else 
            {
                string nuevoNombre = Interaction.InputBox(labelIngreseElNuevoNombre.Text);
                if(!(nuevoNombre == null || string.IsNullOrEmpty(nuevoNombre) || string.IsNullOrWhiteSpace(nuevoNombre))) 
                {
                    PermisoBLL GestorPermiso = new PermisoBLL();
                    GestorPermiso.ModificarPermiso(CB_Familias.SelectedItem.ToString(), nuevoNombre);
                    RecargarTodasLasVistas();
                }
            
            
            }
        }

        private void BT_CrearRol_Click(object sender, EventArgs e)
        {
            if(TB_NuevoNombre.Text == "" || TB_NuevoNombre.Text == null) 
            {
            }
            else 
            {
                BitacoraBLL GestorBitacora = new BitacoraBLL();
                GestorBitacora.AltaEvento("Gestion de Permisos", $"Se ha creado el Rol {TB_NuevoNombre}",5);
                CrearPermisoCompuesto(TB_NuevoNombre.Text,true);
                RecargarTodasLasVistas();
            }
            TB_NuevoNombre.Clear();
        }

        private void BT_CrearGrupoDePermisos_Click(object sender, EventArgs e)
        {
            if (TB_NuevoNombre.Text == "" || TB_NuevoNombre.Text == null)
            {
            }
            else 
            {
                BitacoraBLL GestorBitacora = new BitacoraBLL();
                GestorBitacora.AltaEvento("Gestion de Permisos", $"Se ha creado un Grupo De Permisos ", 3);
                CrearPermisoCompuesto(TB_NuevoNombre.Text, false);
                RecargarTodasLasVistas();
            }
        }

        private void BT_GuardarCambios_Click(object sender, EventArgs e)
        {
            if(CB_Familias.Text == "") 
            {
            }
            else 
            {
                DialogResult resultado = MessageBox.Show("","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(resultado == DialogResult.Yes) 
                {
                    List<string> items = GenerarLista();
                    if(items.Contains(CB_Familias.Text))
                    {
                    }
                    PermisoBLL GestorPermiso = new PermisoBLL();
                    if(GestorPermiso.ModificarPermisoCompuesto(CB_Familias.Text,items)) 
                    {
                        BitacoraBLL GestorBitacora = new BitacoraBLL();
                        GestorBitacora.AltaEvento("Gestion de Permisos","Se han modificado los permisos de una familia",5);
                    }
                    RecargarTodasLasVistas();
                }
            
            }
        }

        public void ActualizarLenguaje()
        {
            RecorrerControles(this);
        }

        public void RecorrerControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if ((c is TextBox tb) == false)
                {
              
                    c.Text = Traductor.TraductorSG.Traducir(c.Name);

        
                    if (c.HasChildren)
                    {
                        RecorrerControles(c);
                    }
                }
            }
        }
    }
}
