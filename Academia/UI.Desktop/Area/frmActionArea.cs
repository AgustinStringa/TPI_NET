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
        public Entities.Area area;
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
            }
        }
        public frmActionArea(Mode mode, int id)
        {
            this.mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Edit:
                    btnActionArea.Text = "Guardar Especialidad";
                    lblId.Visible = true;
                    txtId.Visible = true;
                    txtId.Text = id.ToString();
                    GetArea(id);
                    break;
            }

        }


        private async void GetArea(int id){
            area = await Business.Area.FindOne(id);
            txtAreaName.Text = area.Name;
            txtId.Text = area.IdArea.ToString();
        }
        private async void CreateArea(Entities.Area newArea)
        {

                var newAreaResult = await Business.Area.Create(newArea);
                MessageBox.Show(newAreaResult.Name+ " creada correctamente");
                this.Dispose();   
        }

        private async void  EditArea(Entities.Area newArea) {
            var updatedAreaResult = await Business.Area.Update(new Entities.Area(newArea.Name, area.IdArea));
            MessageBox.Show(updatedAreaResult.Name + " actualizada correctamente");
            this.Dispose();

        }

        private void txtAreaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //CreateArea();
                btnActionArea.PerformClick();
            }
        }

        private async void btnActionArea_Click(object sender, EventArgs e)
        {
            string areaName = txtAreaName.Text;
            if (String.IsNullOrEmpty(areaName.Trim()))
            {
                //finalizar ejecucion
            }
            else {
                if (mode == Mode.Create)
                {
                    CreateArea(new Entities.Area(areaName.Trim()));
                }
                else if (mode == Mode.Edit)
                {
                    EditArea(new Entities.Area(areaName.Trim()));
                }
            }

        }
    }
}
