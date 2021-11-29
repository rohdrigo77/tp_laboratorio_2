using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Generics;
using Excepciones;



namespace Entidades
{
    public class GestorDeArchivos<T> : IGuardar<T>
    {
        
        public GestorDeArchivos()
        {
            
        }
        public string GenerarRutaCompleta
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            }
        }

        public bool ExisteArchivo(string nombreArchivo)
        {

            return File.Exists(this.GenerarRutaCompleta + nombreArchivo);
        }

        public void Guardar(string archivo, T objeto)
        {
            string rutaCompleta = GenerarRutaCompleta + archivo;
            StreamWriter streamWriter = new StreamWriter(rutaCompleta, true);


            try
            {
                string json = JsonSerializer.Serialize<T>(objeto);
                streamWriter.WriteLine();
            }
            catch (Exception ex)
            {
                throw new ErrorArchivosException("Error al guardar el archivo.", ex);
            }

        }

        public void Leer(string nombreArchivo, out T objeto)
        {
            string rutaCompleta = GenerarRutaCompleta + nombreArchivo;

            try
            {
                string json = File.ReadAllText(rutaCompleta);
                objeto = JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                throw new ErrorArchivosException("Error al leer el archivo.", ex);
            }

        }

    }

}