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
        private Entities.Subject currentSubject;
        private Mode mode;
        #endregion


        #region constructors
        public frmActionSubject()
        {
            InitializeComponent();
        }


        public frmActionSubject(Mode mode, Entities.Subject subj)
        {
            InitializeComponent();
            currentSubject = subj;
            LoadCurriculums();
            if (mode == Mode.Edit)
            {

            }
        }

        public frmActionSubject(Mode mode)
        {
            InitializeComponent();
            LoadCurriculums();
            this.mode = mode;
            if (mode == Mode.Create)
            {

            }
        }



        #endregion}
        public async void LoadCurriculums()
        {
            var curriculums = await Business.Curriculum.FindAll();
            cbCurriculums.DataSource = curriculums;
            cbCurriculums.ValueMember = "Id";
            cbCurriculums.DisplayMember = "Description";
            cbCurriculums.SelectedIndex = 0;
        }
    } 
}
