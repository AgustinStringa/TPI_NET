using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Area;

namespace UI.Desktop.Curriculum
{
    public partial class frmActionCurriculum : Form
    {
        #region fields
        private Entities.Curriculum currentCurriculum;
        private Mode mode;
        #endregion

        #region constructors
        public frmActionCurriculum()
        {
            InitializeComponent();
            LoadAreas();
        }

        public frmActionCurriculum(Mode mode, Entities.Curriculum curr)
        {
            InitializeComponent();
            currentCurriculum = curr;
            LoadAreas();
            if (mode == Mode.Edit)
            {
                btnActionCurriculum.Text = "Guardar Plan de Estudios";
                txtCurriculumId.Visible = true;
                txtCurriculumId.Text = currentCurriculum.Id.ToString();
                lblCurriculumId.Visible = true;

                txtCurriculumDescription.Text = currentCurriculum.Description;
                
                txtCurriculumYear.Text = currentCurriculum.Year.ToString();

                txtCurriculumResolution.Text = currentCurriculum.Resolution.ToString().Trim();

                //selected value esta bindeado a una lista de areas
                cbAreas.SelectedValue = currentCurriculum.Area.IdArea;

            }
        }

        public frmActionCurriculum(Mode mode)
        {
            InitializeComponent();
            LoadAreas();
            this.mode = mode;
            if (mode == Mode.Create) {
                btnActionCurriculum.Text = "Crear Plan de Estudios";

                txtCurriculumId.Visible = false;
                lblCurriculumId.Visible = false;
            }
        }
        #endregion


        private async void LoadAreas()
        {
            var areas = await Business.Area.FindAll();
            cbAreas.DataSource = areas;
            cbAreas.ValueMember = "IdArea";
            cbAreas.DisplayMember = "Description";
            cbAreas.SelectedIndex = 0;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void btnActionCurriculum_Click(object sender, EventArgs e)
        {
            string description = txtCurriculumDescription.Text;
            int year = 0;
            string resolution = txtCurriculumResolution.Text;
            try
            {
                lblCurriculumYearError.Visible = false;
                year = Int32.Parse(txtCurriculumYear.Text);
            }
            catch (Exception ex)
            { 
                lblCurriculumYearError.Visible = true;
            }

            if (String.IsNullOrEmpty(description))
            {
                lblCurriculumDescriptionError.Visible = true;
            }
            else
            {
                lblCurriculumDescriptionError.Visible = false;
            }

            if (cbAreas.SelectedValue != null)
            {
                int idArea = (int)cbAreas.SelectedValue;

                if (mode == Mode.Create)
                {
                    Entities.Curriculum newCurr = new Entities.Curriculum(description, idArea, year, resolution);

                    var curr = await Business.Curriculum.Create(newCurr);

                    if (curr != null)
                    {
                        MessageBox.Show(curr.Description + " creado correctamente");
                        this.Dispose();
                    }
                    else
                    {

                        MessageBox.Show("ERROR");
                    }
                }
                else if (mode == Mode.Edit)
                {
                    var area = cbAreas.SelectedItem as Entities.Area;
                    
                    var updatedCurriculum = new Entities.Curriculum(
                        currentCurriculum.Id,
                        description,
                        area,
                        year,
                        resolution
                        );
                    //llamada a update negocio
                    var update = await Business.Curriculum.Update(updatedCurriculum);
                    if (update != null)
                    {
                        //actualizo campos o cierro form
                        MessageBox.Show("Actualizado correctamente");
                    }
                    else { 
                        MessageBox.Show("Error al actualizar");

                    }
                }

                this.Dispose();

            }



        }
    }
}
