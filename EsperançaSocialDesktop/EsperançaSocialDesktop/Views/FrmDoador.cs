using EsperançaSocialDesktop.Controllers;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsperançaSocialDesktop.Views
{
    public partial class FrmDoador : Form
    {

        private DoadorController controller = new DoadorController();
        private int? idDoadorSelecionado = null; // ID 
        public FrmDoador()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void FrmDoador_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Pessoa Física");
            cmbTipo.Items.Add("Empresa");
            cmbTipo.SelectedIndex = 0;

            CarregarGrid();
        }
        private void CarregarGrid()
        {
            dgvDoadores.DataSource = null;
            dgvDoadores.DataSource = controller.Listar();
        }
        private void LimparCampos()
        {
            idDoadorSelecionado = null;
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            cmbTipo.SelectedIndex = 0;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do doador.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DoadorModel d = new DoadorModel
            {
                Nome = txtNome.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Tipo = cmbTipo.Text
            };

            if (idDoadorSelecionado == null)
            {
                controller.Inserir(d);
                MessageBox.Show("Doador cadastrado com sucesso.");
            }
            else
            {
                d.IdDoador = idDoadorSelecionado.Value;
                controller.Atualizar(d);
                MessageBox.Show("Doador atualizado com sucesso.");
            }

            LimparCampos();
            CarregarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idDoadorSelecionado == null)
            {
                MessageBox.Show("Selecione um doador para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este doador?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controller.Excluir(idDoadorSelecionado.Value);
                MessageBox.Show("Doador excluído com sucesso.");
                LimparCampos();
                CarregarGrid();
            }
        }

        private void dgvDoadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDoadores.Rows[e.RowIndex];

            idDoadorSelecionado = Convert.ToInt32(row.Cells[0].Value); // ID interno
            txtNome.Text = row.Cells[1].Value.ToString();
            txtTelefone.Text = row.Cells[2].Value.ToString();
            txtEmail.Text = row.Cells[3].Value.ToString();
            cmbTipo.Text = row.Cells[4].Value.ToString();
        }

       
    }
}
