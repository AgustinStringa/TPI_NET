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

namespace UI.Desktop.Commission
{
    public partial class frmActionCommission : Form
    {
        private Mode mode;
        public Domain.Model.Commission commission;
        public frmActionCommission(Mode mode)
        {
            this.mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Create:
                    btnActionCommission.Text = "Crear comisión";
                    lblId.Visible = false;
                    txtId.Visible = false;
                    lblDescriptionError.Visible = false;
                    lblIdCurriculumError.Visible = false;
                    lblIdError.Visible = false;
                    Utilities.LoadCurriculums(cbCurriculum);
                    break;
            }
        }
        public frmActionCommission(Mode mode, Domain.Model.Commission comm)
        {
            this.commission = comm;
            InitializeComponent();
            Utilities.LoadCurriculums(cbCurriculum);
            this.mode = mode;
            switch (mode)
            {
                case Mode.Edit:
                    btnActionCommission.Text = "Guardar comisión";
                    lblId.Visible = false;
                    lblDescriptionError.Visible = false;
                    lblIdCurriculumError.Visible = false;
                    lblIdError.Visible = false;
                    txtId.Visible = false;
                    //txtId.Text = commission.Id.ToString();
                    txtCommissionDescription.Text = commission.Description.ToString();
                    cbCurriculum.SelectedValue = commission.Curriculum.Id;
                    break;
            }

        }

        private async void LoadCurriculum()
        {
            try
            {
                var service = new Domain.Services.AreaService();
                cbCurriculum.DataSource = service.GetAll();
                cbCurriculum.ValueMember = "Id";
                cbCurriculum.DisplayMember = "Description";
                cbCurriculum.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async void btnActionCommission_Click(object sender, EventArgs e)
        {
            string commissionDescription = txtCommissionDescription.Text;

            bool validDescription = !String.IsNullOrEmpty(commissionDescription);
            if (!validDescription)
            {
                lblDescriptionError.Visible = true;
            }
            else
            {
                validDescription = true;
                lblDescriptionError.Visible = false;
            }

            bool validCurriculum = cbCurriculum.SelectedValue != null;

            if (validDescription && validCurriculum)
            {
                int idCurriculum = (int)cbCurriculum.SelectedValue;
                if (mode == Mode.Create)
                {
                    Domain.Model.Commission newComm = new Domain.Model.Commission
                    {
                        Description = commissionDescription,
                        IdCurriculum = idCurriculum

                    };
                    var service = new Domain.Services.CommissionService();
                    try
                    {
                        CreateCommission(newComm, service);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw ex;
                    }
                }
                else if (mode == Mode.Edit)
                {
                    var service = new Domain.Services.CommissionService();
                    EditCommission(commissionDescription, idCurriculum, service);
                }
            }

            /*
            else
            {
                if (mode == Mode.Create)
                {
                    CreateCommission(new Entities.Commission(commissionDescription.Trim(), commissionIdCurriculum));
                }
                else if (mode == Mode.Edit)
                {
                    EditCommission(new Entities.Commission(commissionDescription.Trim(), commissionIdCurriculum));
                }
            }
            */
        }





        /*
        private async void getcommission(int id)
        {
            commission = await business.commission.findone(id);
            txtcommissiondescription.text = commission.description;
            txtid.text = commission.idcommission.tostring();
        }
        */
        private async void CreateCommission(Domain.Model.Commission newCommission, Domain.Services.CommissionService service)
        {

            service.Create(newCommission);
            MessageBox.Show(newCommission.Description + " creada correctamente");
            this.Dispose();
        }

        private async void EditCommission(string description, int idCurriculum, Domain.Services.CommissionService service)
        {
            this.commission.Description = description;
            this.commission.IdCurriculum = idCurriculum;
            service.Update(this.commission);
            MessageBox.Show(this.commission.Description + " actualizada correctamente");
            this.Dispose();
        }

        /*
        private void txtCommissionName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //CreateCommission();
                btnActionCommission.PerformClick();
            }
        }
        */

    }
}
