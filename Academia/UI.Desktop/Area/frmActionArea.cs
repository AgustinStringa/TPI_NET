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
using Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UI.Desktop.Area
{
    public partial class FrmActionArea : Form
    {
        private Mode mode;
        private Domain.Model.Area area;
        public FrmActionArea(Mode mode)
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
        public FrmActionArea(Mode mode, Domain.Model.Area area)
        {
            this.mode = mode;
            this.area = area;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Edit:
                    btnActionArea.Text = "Guardar Especialidad";
                    lblId.Visible = true;
                    lblIdValue.Visible = true;
                    lblIdValue.Text = area.Id.ToString();
                    txtId.Visible = false;
                    txtAreaName.Text = area.Description.ToString();
                    break;
            }
        }

        private async void CreateArea(Domain.Model.Area newArea)
        {
            try
            {
                var service = new Domain.Services.AreaService();
                await service.Create(newArea);
                MessageBox.Show("Especialidad " + newArea.Description + " creada correctamente.", "Crear especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch (Exception e)
            {
                if (e.HResult == -2146233088)
                {
                    MessageBox.Show("Nombre de especialidad existente.", "No se ha podido crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void EditArea(string areaDescription)
        {
            try
            {
                this.area.Description = areaDescription;
                var service = new Domain.Services.AreaService();
                await service.Update(this.area);
                this.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
        }

        private void txtAreaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnActionArea.PerformClick();
            }
        }

        private async void btnActionArea_Click(object sender, EventArgs e)
        {
            string areaDescription = txtAreaName.Text.Trim();
            if (String.IsNullOrEmpty(areaDescription))
            {
                return;
            }
            else
            {
                if (mode == Mode.Create)
                {
                    CreateArea(new Domain.Model.Area { Description = areaDescription });
                }
                else if (mode == Mode.Edit)
                {
                    EditArea(areaDescription);
                }
            }
        }
    }
}
