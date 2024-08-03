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
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UI.Desktop.Area
{
    public partial class frmActionArea : Form
    {
        private Mode mode;
        public Domain.Model.Area area;
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

            var service = new Domain.Services.AreaService();
            this.area = service.GetById(id);
            txtId.Text = area.Id.ToString();
            txtAreaName.Text = area.Description;
            //area = await Business.Area.FindOne(id);
            //this area = area.Description;
        }
        private async void CreateArea(Entities.Area newArea)
        {

            try
            {
                var newDescription = txtAreaName.Text.Trim();
                if (newDescription != null) {
                    area = new Domain.Model.Area{ Description = newDescription };
                    var service = new Domain.Services.AreaService();
                    service.Create(area);
                    MessageBox.Show(area.Description + " creada correctamente");
                    this.Dispose();
                
                }

                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }

        }

        private async void  EditArea(Entities.Area newArea) {
            string newDescription = txtAreaName.Text.Trim();
            if (newDescription != null) { 
                this.area.Description = newDescription;
                var service = new Domain.Services.AreaService();
                service.Update(this.area);
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
