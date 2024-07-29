using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.Curriculum;

namespace UI.Desktop.Subject
{
    
    public partial class frmActionSubject : Form
    {

        #region fields
        private Mode mode;
        public Entities.Subject subject;
        #endregion


#region constructors
        public frmActionSubject()
        {
            InitializeComponent();
        }


        public frmActionSubject(Mode mode)
        {
            this.mode = mode;
            InitializeComponent();
            switch (mode)
            {
                case Mode.Create:

                    break;
            }

        }

        private async void LoadCurriculums()
        {
            var areas = await Business.Curriculum.FindAll();
            cbCurriculums.DataSource = curriculums;
            cbCurriculums.ValueMember = "id_plan";
            cbCurriculums.DisplayMember = "Description";
            cbCurriculums.SelectedIndex = 0;
        }

    }
}
