using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Model;
using Org.BouncyCastle.Asn1.Ocsp;
using UI.Desktop.Area;

namespace UI.Desktop.Curriculum
{
    public partial class frmActionCurriculum : Form
    {

        private Domain.Model.Curriculum curriculum;
        private Mode mode;

        public frmActionCurriculum(Mode mode)
        {
            this.mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Create:
                    btnActionCurriculum.Text = "Crear Plan de Estudios";
                    lblCurriculumId.Visible = false;
                    txtCurriculumId.Visible = false;
                    lblTitle.Text = "Crear Plan de Estudios";
                    LoadAreas();
                    break;
            }
        }

        public frmActionCurriculum(Mode mode, Domain.Model.Curriculum curr)
        {
            InitializeComponent();
            this.curriculum = curr;
            LoadAreas();
            if (mode == Mode.Edit)
            {
                btnActionCurriculum.Text = "Guardar Plan de Estudios";
                lblTitle.Text = "Editar Plan de Estudios";
                txtCurriculumId.Visible = true;
                txtCurriculumId.Text = curriculum.Id.ToString();
                lblCurriculumId.Visible = true;
                txtCurriculumDescription.Text = curriculum.Description;
                txtCurriculumYear.Text = curriculum.Year.ToString();
                txtCurriculumResolution.Text = curriculum.Resolution?.ToString().Trim();
                cbAreas.SelectedValue = curriculum.Area.Id;
            }
        }

        private async void LoadAreas()
        {
            try
            {
                var service = new Domain.Services.AreaService();
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

        private async void btnActionCurriculum_Click(object sender, EventArgs e)
        {
            string description = txtCurriculumDescription.Text;
            int year = 0;
            string resolution = txtCurriculumResolution.Text;

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
                    Domain.Model.Curriculum newCurr = new Domain.Model.Curriculum
                    {
                        Description = description,
                        AreaId = idArea,
                        Year = year,
                        Resolution = resolution
                    };

                    var service = new Domain.Services.CurriculumService();
                    var createdCurr = service.Create(newCurr);

                    if (createdCurr != null)
                    {
                        MessageBox.Show(createdCurr.Description + " creado correctamente");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
                else if (mode == Mode.Edit)
                {
                    var area = cbAreas.SelectedItem as Domain.Model.Area;
                    curriculum.Description = description;
                    curriculum.Year = year;
                    curriculum.Resolution = resolution;
                    curriculum.AreaId = idArea;
                    curriculum.Area = area;
                    var service = new Domain.Services.CurriculumService();
                    service.Update(curriculum);
                    MessageBox.Show("Actualizado correctamente");

                }

                this.Dispose();

            }
        }
    }
}
