using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LecturaDeArchivos
{
    public partial class FrmLog : Form
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = this.Text = value; }
        }

        private string _bodyText;
        public string BodyText
        {
            get
            {
                return _bodyText;
            }
            set
            {
                _bodyText = richTextBox.Text = value;
            }
        }

        public FrmLog()
        {
            InitializeComponent();
        }



        public List<ToolStripMenuItem> ObtenerMenus()
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();

            foreach (ToolStripMenuItem item in menuPrincipal.Items)
            {
                items.Add(item);
                items.AddRange(ObtenerItemsHijos(item));
            }

            return items;
        }



        private IEnumerable<ToolStripMenuItem> ObtenerItemsHijos(ToolStripMenuItem pToolStripMenuItem)
        {
            foreach (ToolStripMenuItem dropDownItem in pToolStripMenuItem.DropDownItems)
            {
                foreach (ToolStripMenuItem subitem in ObtenerItemsHijos(dropDownItem)) yield return subitem;

                yield return dropDownItem;
            }
        }



        public void FiltrarItems(List<Dictionary<string, Action>> pItems)
        {
            ObtenerMenus().ForEach(item =>
            {
                var currentItem = pItems.SelectMany(d => d)
                                        .FirstOrDefault(i => i.Key.Equals(item.Name));

                if (string.IsNullOrEmpty(currentItem.Key))
                {
                    item.Visible = false;
                }
                else
                {
                    if (currentItem.Value != null)
                    {
                        item.Click += (s, e) => currentItem.Value();
                    }
                }
            });
        }



        private void btnAceptar_Click(object sender, EventArgs e) => this.Close();
    }
}