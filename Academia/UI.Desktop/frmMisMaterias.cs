using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class frmMisMaterias : Form
    {
        public frmMisMaterias()
        {
            InitializeComponent();
            lblName.Text = "Nombre Alumno a las " + DateTime.Now.ToString();
            var nuevo = new ListViewItem("Administración de Sistemas de Información (Integradora)");
            nuevo.SubItems.Add("Aprobada");
            nuevo.SubItems.Add("7");
            listView1.Items.Add(nuevo);

        }
    }
}
