using EsperancaSocial.Desktop.Controllers;
using EsperancaSocial.Desktop.Data;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsperançaSocialDesktop.Views
{
    public partial class FrmIndividuo : Form
    {
        public FrmIndividuo()
        {
            InitializeComponent();
            this.TopLevel = false;
        }
        private int _idIndividuoSelecionado = 0;
        private IndividuoController controller = new IndividuoController();

        private void FrmIndividuo_Load(object sender, EventArgs e)
        {
            cmbGenero.Items.Clear();
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Feminino");
            cmbGenero.Items.Add("Outro");
            cmbGenero.SelectedIndex = 0; // Seleciona o primeiro por padrão
            CarregarFamilias();
            CarregarGrid();
        }

        private void CarregarFamilias()
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT id_familia, nome_responsavel FROM Familia ORDER BY nome_responsavel", conn);
                da.Fill(dt);

                cmbFamilia.DataSource = dt;
                cmbFamilia.DisplayMember = "nome_responsavel";
                cmbFamilia.ValueMember = "id_familia";
            }
        }
        private void CarregarGrid()
        {
            dgvIndividuos.DataSource = controller.Listar();
            dgvIndividuos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIndividuos.MultiSelect = false;
            dgvIndividuos.Columns["id_individuo"].HeaderText = "ID";
            dgvIndividuos.Columns["nome"].HeaderText = "Nome";
            dgvIndividuos.Columns["data_nascimento"].HeaderText = "Data Nascimento";
            dgvIndividuos.Columns["genero"].HeaderText = "Gênero";
            dgvIndividuos.Columns["escolaridade"].HeaderText = "Escolaridade";
            dgvIndividuos.Columns["parentesco"].HeaderText = "Parentesco";
            dgvIndividuos.Columns["condicao_saude"].HeaderText = "Condição Saúde";
            dgvIndividuos.Columns["observacoes"].HeaderText = "Observações";
            dgvIndividuos.Columns["Familia"].HeaderText = "Família";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void LimparCampos()
        {
            _idIndividuoSelecionado = 0;
            txtNome.Text = "";
            dtpDataNasc.Value = DateTime.Today;
            cmbGenero.SelectedIndex = -1;
            txtEscolaridade.Text = "";
            txtParentesco.Text = "";
            txtCondicao.Text = "";
            txtObservacoes.Text = "";
            cmbFamilia.SelectedIndex = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do indivíduo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IndividuoModel indiv = new IndividuoModel()
            {
                IdIndividuo = _idIndividuoSelecionado,
                IdFamilia = Convert.ToInt32(cmbFamilia.SelectedValue),
                Nome = txtNome.Text.Trim(),
                DataNascimento = dtpDataNasc.Value,
                Genero = cmbGenero.Text,
                Escolaridade = txtEscolaridade.Text.Trim(),
                Parentesco = txtParentesco.Text.Trim(),
                CondicaoSaude = txtCondicao.Text.Trim(),
                Observacoes = txtObservacoes.Text.Trim()
            };

            if (_idIndividuoSelecionado == 0)
            {
                controller.Inserir(indiv);
                MessageBox.Show("Indivíduo inserido com sucesso!");
            }
            else  
            {
                controller.Atualizar(indiv);
                MessageBox.Show("Indivíduo atualizado com sucesso!");
            }

            LimparCampos();
            CarregarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (_idIndividuoSelecionado == 0)
            {
                MessageBox.Show("Selecione um indivíduo para excluir.");
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este indivíduo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controller.Excluir(_idIndividuoSelecionado);
                MessageBox.Show("Indivíduo excluído com sucesso!");
                LimparCampos();
                CarregarGrid();
            }

        }

        private void dgvIndividuo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvIndividuos.Rows[e.RowIndex];
                _idIndividuoSelecionado = Convert.ToInt32(row.Cells["id_individuo"].Value);
                txtNome.Text = row.Cells["nome"].Value.ToString();
                dtpDataNasc.Value = Convert.ToDateTime(row.Cells["data_nascimento"].Value);
                cmbGenero.Text = row.Cells["genero"].Value.ToString();
                txtEscolaridade.Text = row.Cells["escolaridade"].Value.ToString();
                txtParentesco.Text = row.Cells["parentesco"].Value.ToString();
                txtCondicao.Text = row.Cells["condicao_saude"].Value.ToString();
                txtObservacoes.Text = row.Cells["observacoes"].Value.ToString();
                cmbFamilia.Text = row.Cells["Familia"].Value.ToString();
            }
        }

       
    }

}
