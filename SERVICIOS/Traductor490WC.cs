using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Traductor490WC : ISujeto490WC
    {
        public static Traductor490WC Instance;
        public static Traductor490WC TraductorSG
        {
            get 
            {
                if(Instance == null)
                {
                    Instance = new Traductor490WC();
                }
                return Instance;
            }
        }
        List<iObserverLenguaje490WC> ListaFormularios = new List<iObserverLenguaje490WC>();
        Dictionary<string, string> Lenguaje = new Dictionary<string, string>();
       
        string jsonFilePath;
        public void CargarTraducciones(string nuevoLenguaje)
        {
            
            if (File.Exists(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes", $"{nuevoLenguaje}.json"))))
            {
                jsonFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes", $"{nuevoLenguaje}.json"));
                string jsonContent = File.ReadAllText(jsonFilePath);
                Lenguaje.Clear();
                Lenguaje = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
            }
        }

        public List<string> DevolverIdiomasDisponibles()
        {
            List<string> ListaIdiomas = new List<string>();
          
            string[] archivos = Directory.GetFiles("C:\\Users\\William Càrdenas\\Desktop\\TESIS 2025\\Campo-Cardenas-UAI\\gui\\bin\\Debug\\Lenguajes", "*.json");

          
            List<string> nombresDeIdiomas = archivos
                .Select(archivo => Path.GetFileNameWithoutExtension(archivo))
                .ToList();

            return nombresDeIdiomas;

        }

        public void Actualizar(string lenguajeActual)
        {
            CargarTraducciones(lenguajeActual);
            Notificar();
            Lenguaje.Clear();
        }
        public string Traducir(string TextoATraducir) 
        {
           try
            {
                if (Lenguaje.Count == 0) CargarTraducciones(SesionManager490WC.GestorSesion.UsuarioSesion.IdiomaUsuario);
                string translation = "";
                return translation = Lenguaje[TextoATraducir];
            }
            catch (Exception ex) { return TextoATraducir; }
        }

        public void Notificar()
        {
            foreach(iObserverLenguaje490WC Iob in ListaFormularios)
            {
                Iob.ActualizarLenguaje();
            }
        }

        public void Suscribir(iObserverLenguaje490WC nNuevoObserver)
        {
            this.ListaFormularios.Add(nNuevoObserver);
        }

        public void Desuscribir(iObserverLenguaje490WC nObserverBorrar)
        {
            if(this.ListaFormularios.Contains(nObserverBorrar))
            {
              this.ListaFormularios.Remove(nObserverBorrar);
            }
        }

    }
}
