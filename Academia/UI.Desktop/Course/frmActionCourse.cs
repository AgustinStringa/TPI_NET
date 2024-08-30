using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UI.Desktop.Course
{
    public partial class frmActionCourse : Form
    {
        public frmActionCourse()
        {
            InitializeComponent();
        }

        public frmActionCourse(Mode mode)
        {
            InitializeComponent();
            Utilities.LoadAreas(cmbAreas);
        }
        private void btnActionCourse_Click(object sender, EventArgs e)
        {
            //SI se esta creando validar que no exista ya un cursado para esa materia, esa comision y ese año calendario 
        }
    }
}
