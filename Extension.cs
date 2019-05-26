using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public static class Extension
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.AppendText(Environment.NewLine);
            box.AppendText(Environment.NewLine);
            box.SelectionColor = box.ForeColor;
        }

        public static IEnumerable<T> AllControls<T>(this Control startingPoint) where T : Control
        {
            bool hit = startingPoint is T;
            if (hit)
            {
                yield return startingPoint as T;
            }
            foreach (var child in startingPoint.Controls.Cast<Control>())
            {
                foreach (var item in AllControls<T>(child))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Obtiene todos los controles de un formulario con recursividad
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Control> GetAllControlsOfType(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(Control => GetAllControlsOfType(Control, type))
                           .Concat(controls)
                           .Where(c => c.GetType() == type)
                           ;
        }



        public static IEnumerable<Control> GetAllControls(this Control container)
        {
            IEnumerable<Control> controls = container.Controls.Cast<Control>();

            foreach (Control control in controls)
            {
                yield return control;
                GetAllControls(control);
            }
        }



        public static IEnumerable<string> ObtenerMetodos(Type tipo)
        {
            foreach (var metodo in tipo.GetMethods()) yield return metodo.Name;
        }



        public static bool esAdministrador()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                return new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

    }
}
