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
        #region constructors
        public frmActionCurriculum()
        {
            InitializeComponent();
        }

        public frmActionCurriculum(Mode mode, Entities.Curriculum curr)
        {
            InitializeComponent();
        }

        public frmActionCurriculum(Mode mode)
        {
            InitializeComponent();
        }
        #endregion

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnActionCurriculum_Click(object sender, EventArgs e)
        {
            string description = txtCurriculumDescription.Text;
            int year = Int32.Parse(txtCurriculumYear.Text);
            string resolution = txtCurriculumResolution.Text;
            int area = cbAreas.SelectedIndex;

            Entities.Curriculum newCurr = new  Entities.Curriculum(description, area,year, resolution );
            
        }
    }
}
