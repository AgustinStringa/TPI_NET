﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void frmSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            frmLogin appLogin = new frmLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }
    }
}
