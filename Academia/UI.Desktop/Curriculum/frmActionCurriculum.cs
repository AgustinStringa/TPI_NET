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
    public partial class FrmActionCurriculum : Form
    {

        private Domain.Model.Curriculum curriculum;
        private Mode mode;

        public FrmActionCurriculum(Mode mode)
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
                    Utilities.LoadAreas(cbAreas);
                    break;
            }
        }

        public FrmActionCurriculum(Mode mode, Domain.Model.Curriculum curr)
        {
            this.curriculum = curr;
            InitializeComponent();
            Utilities.LoadAreas(cbAreas);
            this.mode = mode;
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
                    try
                    {
                        await service.Create(newCurr);
                        MessageBox.Show(newCurr.Description + " creado correctamente");
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw ex;
                    }
                }
                else if (mode == Mode.Edit)
                {
                    var area = cbAreas.SelectedItem as Domain.Model.Area;
                    var service = new Domain.Services.CurriculumService();
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
    }
}
