using EsperancaSocial.Desktop.Core;
using EsperancaSocial.Desktop.Forms;
using EsperancaSocial.Desktop.Models;
using EsperançaSocialDesktop.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace EsperançaSocialDesktop.Forms
{

    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {

            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            if (!SessaoUsuario.EstaAutenticado())
            {
                MessageBox.Show("Sessão inválida. Faça login novamente.");
                this.Close();
                return;
            }

            lblUsuarioLogado.Text = SessaoUsuario.UsuarioLogado.Username;
            lblNivelAcesso.Text = SessaoUsuario.UsuarioLogado.NivelAcesso;

            AplicarPermissoes();
        }
        private void AplicarPermissoes()
        {
            string nivel = SessaoUsuario.UsuarioLogado.NivelAcesso;

            // Admin vê tudo
            if (nivel == "admin")
                return;

            // Operador
            if (nivel == "operador")
            {
                menuUsuarios.Visible = false;
                menuFuncionarios.Visible = false;
            }

            // Voluntário
            if (nivel == "voluntario")
            {
                menuUsuarios.Visible = false;
                menuFuncionarios.Visible = false;
                menuRelatorios.Visible = false;
            }
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmServico());
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            SessaoUsuario.EncerrarSessao();
            this.Hide();

            Frmlogin login = new Frmlogin();
            login.Show();
        }

        private void menuFamilias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmFamilia());

        }

        private void btnfamilias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmFamilia());
        }

        private void menuIndividuos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmIndividuo());
        }

        private void menuFuncionarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmFuncionario());
        }

        private void menuDoador_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDoador());
        }

        private void menuDoacoes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDoacao());
        }

        private void btnDoacoes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDoacao());
        }

        private void btnProj_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProjecto());
        }

        private void menuProjectos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProjecto());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnAgendamentos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAgendamento());
        }

        private void menuAgendamento_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAgendamento());
        }

        private void btnAtendimentos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAtendimento());
        }

        private void menuAtendimento_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAtendimento());
        }


        Form formularioAtual;
        public void AbrirFormulario(Form frm)
        {

            if (formularioAtual != null)
                formularioAtual.Close();

            formularioAtual = frm;

            pnlCont.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlCont.Controls.Add(frm);
            frm.Show();
        }
    }
    }

