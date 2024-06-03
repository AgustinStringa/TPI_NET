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
    public partial class frmCurriculum : Form
    {
        public frmCurriculum()
        {
            InitializeComponent();
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmActionCurriculum frm = new frmActionCurriculum(Mode.Create);
            frm.ShowDialog();
            //LoadAreas();
        }
    }
}
