using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationCore;

namespace UI.Desktop
{
    public partial class FrmLogin : Form
    {
        private ClientService.UserService userService;
		public FrmLogin()
        {
            this.userService = new ClientService.UserService(new HttpClient());
            InitializeComponent();
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            var service = new ApplicationCore.Services.UserService();
            string username, password;
            username = txtUsuario.Text.Trim();
            password = txtContra.Text.Trim();
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) {
                MessageBox.Show("Completa todos los campos");
                return;
            }
            //llamar a HttpClient. Extraer el user de la rta, que contiene user y jwt
            var userLogged = await userService.ValidateCredentials(username, password);

            if (userLogged.User != null && userLogged.jwt != null)
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Autenticado correctamente","Autenticado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmMain form = new FrmMain(userLogged.User);
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
