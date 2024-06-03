using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Curriculum;

namespace UI.Desktop
{
    public partial class frmMain : Form
    {
        private bool administrative = false;
        public frmMain()
        {
            InitializeComponent();
        }


        private void frmSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //especialidadesToolStripMenuItem.Visible = !administrative;
            //frmMain appLogin = new frmMain();
            //if (appLogin.ShowDialog() != DialogResult.OK)
            //{
            //    this.Dispose();
            //}
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAreas appLogin = new frmAreas();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void planesDeEstudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurriculum appCurr = new frmCurriculum();
            if (appCurr.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
    }
}
