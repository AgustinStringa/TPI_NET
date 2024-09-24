using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationCore.Model;
using UI.Desktop.Area;

namespace UI.Desktop.Curriculum
{
    public partial class FrmActionCurriculum : Form
    {

        private ApplicationCore.Model.Curriculum curriculum;
        private Mode mode;

        public FrmActionCurriculum(Mode mode)
        {
            switch (mode)
            {
                case Mode.Create:
                    InitializeComponent();
                    this.mode = mode;
                    lblTitleFrmActionCurriculum.Text = "Crear Plan de Estudios";
                    btnActionCurriculum.Text = "Crear Plan de Estudios";
                    lblCurriculumId.Visible = false;
                    lblCurriculumIdValue.Visible = false;
                    lblTitleFrmActionCurriculum.Text = "Crear Plan de Estudios";
                    Utilities.LoadAreas(cbAreas);
                    break;
                default:
                    this.Dispose();
                    break;
            }
        }

        public FrmActionCurriculum(Mode mode, ApplicationCore.Model.Curriculum curr)
        {
            switch (mode)
            {
                case Mode.Edit:
                    this.curriculum = curriculum;
                    this.mode = mode;
                    InitializeComponent();
                    Utilities.LoadAreas(cbAreas);
                    if (curriculum.Subjects.Count > 0)
                    {
                        cbAreas.Enabled = false;
                        lblAreaError.Visible = true;
                    }
                    else
                    {
                        lblAreaError.Visible = false;
                        cbAreas.Enabled = true;
                    }
                    btnActionCurriculum.Text = "Guardar Plan de Estudios";
                    lblTitleFrmActionCurriculum.Text = "Editar Plan de Estudios";
                    lblCurriculumIdValue.Visible = true;
                    lblCurriculumIdValue.Text = this.curriculum.Id.ToString();
                    lblCurriculumId.Visible = true;
                    txtCurriculumDescription.Text = this.curriculum.Description;
                    txtCurriculumYear.Text = this.curriculum.Year.ToString();
                    txtCurriculumResolution.Text = this.curriculum.Resolution?.ToString().Trim();
                    cbAreas.SelectedValue = this.curriculum.Area.Id;
                    break;
                default:
                    this.Dispose();
                    break;
            }
        }

        private async void LoadAreas()
        {
            try
            {
                var service = new ApplicationCore.Services.AreaService();
                cbAreas.DataSource = service.GetAll();
                cbAreas.ValueMember = "Id";
                cbAreas.DisplayMember = "Description";
                cbAreas.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }

        }

        #region Events
        private async void btnActionCurriculum_Click(object sender, EventArgs e)
        {
            string description = txtCurriculumDescription.Text.Trim();
            int year = 0;
            string resolution = txtCurriculumResolution.Text.Trim();

            bool validYear = false;
            try
            {
                lblCurriculumYearError.Visible = false;
                year = Int32.Parse(txtCurriculumYear.Text);
                validYear = true;
            }
            catch (Exception ex)
            {
                validYear = false;
                lblCurriculumYearError.Visible = true;
            }

            bool validDescription = !String.IsNullOrEmpty(description);
            if (!validDescription)
            {
                lblCurriculumDescriptionError.Visible = true;
            }
            else
            {
                validDescription = true;
                lblCurriculumDescriptionError.Visible = false;
            }

            bool validArea = cbAreas.SelectedValue != null;

            if (validArea && validDescription && validYear)
            {
                int idArea = (int)cbAreas.SelectedValue;
                if (mode == Mode.Create)
                {
                    ApplicationCore.Model.Curriculum newCurriculum = new ApplicationCore.Model.Curriculum
                    {
                        Description = description,
                        AreaId = idArea,
                        Year = year,
                        Resolution = resolution
                    };

                    var service = new ApplicationCore.Services.CurriculumService();
                    try
                    {
                        await service.Create(newCurriculum);
                        MessageBox.Show("Plan de Estudios " + newCurriculum.Description + " creado correctamente.", "Crear Plan de Estudios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        //TO DO: que errores puede haber aqui?
                        if (ex.HResult == -2146233088)
                        {
                            MessageBox.Show("Plan de Estudios existente.", "No se ha podido crear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (mode == Mode.Edit)
                {
                    var area = cbAreas.SelectedItem as ApplicationCore.Model.Area;
                    var service = new ApplicationCore.Services.CurriculumService();
                    this.curriculum.Description = description;
                    this.curriculum.Year = year;
                    this.curriculum.Resolution = resolution;
                    this.curriculum.AreaId = idArea;
                    this.curriculum.Area = area;
                    await service.Update(this.curriculum);
                    MessageBox.Show("Actualizado correctamente");
                    this.Dispose();

                }
            }
        }

        private void FrmActionCurriculum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnActionCurriculum.PerformClick();
            }
        }

        #endregion
    }
}
