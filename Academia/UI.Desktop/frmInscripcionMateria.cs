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
    public partial class frmInscripcionMateria : Form
    {
        public frmInscripcionMateria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Info de la materia. \n Horas semanales: 123 \n horas totales: 64 \n", "Ingeniería y Calidad de Software", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }
    }
}
