using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace UI.Desktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            var service = new Domain.Services.UserService() ;
            string username, password;
            username = txtUsuario.Text.Trim();
            password = txtContra.Text.Trim();
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) {
                MessageBox.Show("Completa todos los campos");
                return;
            }
            var user = await service.ValidateCredentials(username, password);
            if (user != null)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Autenticado correctamente","Autenticado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain form = new frmMain(user);
                this.Visible = false;
                form.ShowDialog();
                this.Visible = true;

            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOlvido_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
