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

namespace UI.Desktop.Area
{
    public partial class frmCreateArea : Form
    {
        public frmCreateArea()
        {
            InitializeComponent();
        }

        public Entities.Area newArea;
        private void btnCreateArea_Click(object sender, EventArgs e)
        {
            string areaName = txtAreaName.Text;
            if (String.IsNullOrEmpty(areaName.Trim())) {
               //finalizar ejecucion
            } else {
                
            // la capa de negocio deberia instanciar la ENtidad
                //Business.Area = new (description)
                newArea = new Entities.Area(areaName);
            }
             
        }
    }
}
