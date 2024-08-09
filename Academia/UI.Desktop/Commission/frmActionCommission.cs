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
    public enum Mode { Edit, Create };
    public partial class frmActionCommission : Form
    {
        private Mode mode;
        public Entities.Commission Commission;
        public frmActionCommission(Mode mode)
        {
            this.mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Create:
                    btnActionCommission.Text = "Crear Especialidad";
                    lblId.Visible = false;
                    txtId.Visible = false;
                    break;
            }
        }
        public frmActionCommission(Mode mode, int id)
        {
            this.mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Edit:
                    btnActionCommission.Text = "Guardar Especialidad";
                    lblId.Visible = true;
                    txtId.Visible = true;
                    txtId.Text = id.ToString();
                    GetCommission(id);
                    break;
            }

        }

        private async void GetCommission(int id)
        {
            Commission = await Business.Commission.FindOne(id);
            txtCommissionDescription.Text =Commission.Description;
            txtId.Text = Commission.IdCommission.ToString();
        }

        private async void CreateCommission(Entities.Commission newCommission)
        {

            var newCommissionResult = await Business.Commission.Create(newCommission);
            MessageBox.Show(newCommissionResult.Year + "0" + newCommissionResult.Description + " creada correctamente");
            this.Dispose();
        }

        private async void EditCommission(Entities.Commission newCommission)
        {
            var updatedCommissionResult = await Business.Commission.Update(new Entities.Commission(newCommission.Description, newCommission.Year, newCommission.IdCurriculum, Commission.IdCommission));
            MessageBox.Show(updatedCommissionResult.Year + "0" + updatedCommissionResult.Description + " actualizada correctamente");
            this.Dispose();
        }

        private void txtCommissionName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //CreateCommission();
                btnActionCommission.PerformClick();
            }
        }
        private async void btnActionCommission_Click(object sender, EventArgs e)
        {
            string commissionDescription = txtCommissionDescription.Text;
            int commissionYear = Int32.Parse(txtCommissionYear.Text);
            int commissionIdCurriculum = Int32.Parse(txtCommissionIdCurriculum.Text);
            if (String.IsNullOrEmpty(commissionDescription.Trim()))
            {
                //finalizar ejecucion
            }
            else
            {
                if (mode == Mode.Create)
                {
                    CreateCommission(new Entities.Commission(commissionDescription.Trim(), commissionYear, commissionIdCurriculum));
                }
                else if (mode == Mode.Edit)
                {
                    EditCommission(new Entities.Commission(commissionDescription.Trim(), commissionYear, commissionIdCurriculum));
                }
            }

        }

    }
}
