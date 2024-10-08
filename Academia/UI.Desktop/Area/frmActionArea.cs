﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ClientService;

namespace UI.Desktop.Area
{
    public partial class FrmActionArea : Form
    {
        private Mode mode;
        private ApplicationCore.Model.Area area;
        private IAreaService _areaService;
        public FrmActionArea(Mode mode, IAreaService service)
        {
            this.mode = mode;
            this._areaService = service;
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
        public FrmActionArea(Mode mode, ApplicationCore.Model.Area area, IAreaService service)
        {
            this.mode = mode;
            this.area = area;
            this._areaService = service;
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

        private async void CreateArea(ApplicationCore.Model.Area newArea)
        {
            try
            {
                await _areaService.CreateAsync(newArea);
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
                await _areaService.UpdateAsync(area);
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
                    CreateArea(new ApplicationCore.Model.Area { Description = areaDescription });
                }
                else if (mode == Mode.Edit)
                {
                    EditArea(areaDescription);
                }
            }
        }
    }
}
