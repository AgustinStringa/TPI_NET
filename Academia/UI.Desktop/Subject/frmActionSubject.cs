using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Subject
{
    
    public partial class frmActionSubject : Form
    {


        private Mode mode;
        public Entities.Subject subject;
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
    }
}
