using System;
using System.IO;
using System.IO.Compression;

namespace Attendees
{
    public class Attendee
    {
        public void WriteToDirectory(ZipArchiveEntry entry, string destDirectory)
        {
            // Combina el directorio de destino con el nombre completo del archivo
            string destFileName = Path.Combine(destDirectory, entry.FullName);

            // Obtén la ruta completa y normalizada para evitar traversión de directorios
            string fullPath = Path.GetFullPath(destFileName);

            // Asegúrate de que el directorio de destino es parte del camino completo
            if (!fullPath.StartsWith(Path.GetFullPath(destDirectory), StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Intento de traversión de directorios detectado");
            }

            // Crear el directorio si no existe
            string destFileDirectory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(destFileDirectory))
            {
                Directory.CreateDirectory(destFileDirectory);
            }

            // Extraer el archivo
            entry.ExtractToFile(fullPath);
        }
        
        public bool AddAttendee(string added)
        {
            if (added == "exists") {
                return true;
            }
            return false;
        }      
    }
}
