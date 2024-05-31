using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace UI.Desktop.Area
{
    public enum Mode { Edit, Create};
    public partial class frmActionArea : Form
    {
        private Mode mode;
        public frmActionArea(Mode mode)
        {
            this.mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Create:
                    btnActionArea.Text = "Crear Especialidad";
                    lblId.Visible = false;
                    txtId.Visible = false;
                    break;
                case Mode.Edit:
                    btnActionArea.Text = "Guardar Especialidad";
                    lblId.Visible = true;
                    txtId.Visible = true;
                    txtId.Text = "0";
                    break;
            }
        }

        public Entities.Area newArea;

        private void CreateArea()
        {
            string areaName = txtAreaName.Text;
            if (String.IsNullOrEmpty(areaName.Trim()))
            {
                //finalizar ejecucion
            }
            else
            {

                // la capa de negocio deberia instanciar la ENtidad
                //Business.Area = new (description)
                newArea = new Entities.Area(areaName);
                this.Dispose();
            }
        }

        private void txtAreaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //CreateArea();
                btnActionArea.PerformClick();
            }
        }

        private void btnActionArea_Click(object sender, EventArgs e)
        {
            if (mode == Mode.Create) {
                CreateArea();
            }
        }
    }
}
