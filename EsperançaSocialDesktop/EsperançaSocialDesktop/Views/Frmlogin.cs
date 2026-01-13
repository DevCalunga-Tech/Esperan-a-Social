using EsperancaSocial.Desktop.Controllers;
using EsperancaSocial.Desktop.Core;
using EsperancaSocial.Desktop.Data;
using EsperancaSocial.Desktop.Models;
using EsperançaSocialDesktop.Forms;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace EsperançaSocialDesktop
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string GerarHash(string senha)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Informe usuário e senha.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            LoginController controller = new LoginController();
            UsuarioModel usuario = controller.Autenticar(txtUsuario.Text.Trim(), txtSenha.Text.Trim());

            if (usuario == null)
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Armazena usuário na sessão
            SessaoUsuario.UsuarioLogado = usuario;

            // Abre o Dashboard
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.Show();

            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario.Focus();
        }
    }
}
