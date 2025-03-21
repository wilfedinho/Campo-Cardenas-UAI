﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Traductor
    {
        public static Traductor Instance;
        public static Traductor TraductorSG
        {
            get 
            {
                if(Instance == null)
                {
                    Instance = new Traductor();
                }
                return Instance;
            }
        }
        List<iObserverLenguaje> ListaFormularios = new List<iObserverLenguaje>();
        Dictionary<string, string> Lenguaje = new Dictionary<string, string>();
       
        string jsonFilePath;
        //C:\Users\William Càrdenas\Desktop\TESIS 2025\Campo-Cardenas-UAI\gui\bin\Debug\Lenguajes\Español.json

        //File.Exists(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lenguajes", $"{nuevoLenguaje}.json")))

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
            // Obtiene todos los archivos con extensión .json en la ruta especificada.
            string[] archivos = Directory.GetFiles("C:\\Users\\William Càrdenas\\Desktop\\TESIS 2025\\Campo-Cardenas-UAI\\gui\\bin\\Debug\\Lenguajes", "*.json");

            // Guarda los nombres de archivo sin ruta ni extensión.
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
        public string Traducir(string TextoATraducir) //Funcion Principal
        {
            try
            {
                if (Lenguaje.Count == 0) CargarTraducciones(SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario);
                string translation = "";
                return translation = Lenguaje[TextoATraducir];
            }
            catch (Exception ex) { return TextoATraducir; }
        }

        public void Notificar()
        {
            foreach(iObserverLenguaje Iob in ListaFormularios)
            {
                Iob.ActualizarLenguaje();
            }
        }

        public void Suscribir(iObserverLenguaje nNuevoObserver)
        {
            this.ListaFormularios.Add(nNuevoObserver);
        }

        public void Desuscribir(iObserverLenguaje nObserverBorrar)
        {
            if(this.ListaFormularios.Contains(nObserverBorrar))
            {
              this.ListaFormularios.Remove(nObserverBorrar);
            }
        }

    }
}
