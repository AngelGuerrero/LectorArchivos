using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public class Log
    {
        public static string Destino { get; set; } = Environment.CurrentDirectory;


        public static string NombreArchivo { get; set; } = "Log.txt";


        public static bool Escribir(string pCabecera, string Accion, string Servidor, string BaseDatos, string pMensaje)
        {
            bool retval = true;

            Debug.WriteLine($"Escribiendo Log: {Destino}");

            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(Destino, NombreArchivo), true))
                {
                    writer.Write($"========== {pCabecera} ==========");
                    writer.WriteLine();
                    writer.WriteLine();
                    writer.Write($"{DateTime.Now}{Environment.NewLine}");
                    writer.Write($"Acción: {Accion}{Environment.NewLine}");
                    writer.Write($"Servidor: {Servidor}{Environment.NewLine}");
                    writer.Write($"Base de datos: {BaseDatos}{Environment.NewLine}");
                    writer.Write($"Mensaje: {pMensaje}{Environment.NewLine}");
                    writer.WriteLine();
                    writer.WriteLine();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepción al escribir el Log: {ex.Message}");
                MessageBox.Show(ex.Message, "Error al escribir el log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retval = false;
            }

            return retval;
        }
    }
}
