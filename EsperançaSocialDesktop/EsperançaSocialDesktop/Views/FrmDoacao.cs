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
    public partial class FrmDoacao : Form
    {
        public FrmDoacao()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private int? idDoacaoSelecionada = null;
        private DoacaoController controller = new DoacaoController();
        private List<DoacaoModel> doadores = new List<DoacaoModel>();

        private void FrmDoacao_Load(object sender, EventArgs e)
        {
            CarregarComboDoadores();
            CarregarGrid();
        }
        private void CarregarComboDoadores()
        {
            using (var con = EsperancaSocial.Desktop.Data.Conexao.ObterConexao())
            {
                var cmd = new System.Data.SqlClient.SqlCommand("SELECT id_doador, Nome FROM Doador ORDER BY Nome", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                cmbDoador.Items.Clear();
                while (reader.Read())
                {
                    cmbDoador.Items.Add(new { Id = reader["id_doador"], Nome = reader["Nome"].ToString() });
                }
            }
            if (cmbDoador.Items.Count > 0) cmbDoador.SelectedIndex = 0;
        }
        // Carrega DataGridView com as doações
        private void CarregarGrid()
        {
            dgvDoacoes.DataSource = null;
            dgvDoacoes.DataSource = controller.Listar();

            dgvDoacoes.Columns["IdDoacao"].HeaderText = "ID";
            dgvDoacoes.Columns["NomeDoador"].HeaderText = "Doador";
            dgvDoacoes.Columns["TipoDoacao"].HeaderText = "Tipo";
            dgvDoacoes.Columns["Descricao"].HeaderText = "Descrição";
            dgvDoacoes.Columns["Quantidade"].HeaderText = "Qtd";
            dgvDoacoes.Columns["ValorEstimado"].HeaderText = "Valor Estimado";
            dgvDoacoes.Columns["DataDoacao"].HeaderText = "Data";
        }
        private void LimparCampos()
        {
            idDoacaoSelecionada = null;
            if (cmbDoador.Items.Count > 0) cmbDoador.SelectedIndex = 0;
            txtTipoDoacao.Clear();
            txtDescricao.Clear();
            txtQuantidade.Clear();
            txtValorEstimado.Clear();
            dtpDataDoacao.Value = DateTime.Now;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (cmbDoador.SelectedItem == null)
            {
                MessageBox.Show("Selecione um doador.");
                return;
            }

            dynamic selecionado = cmbDoador.SelectedItem;
            int idDoador = Convert.ToInt32(selecionado.Id);

            DoacaoModel doacao = new DoacaoModel
            {
                IdDoador = idDoador,
                TipoDoacao = txtTipoDoacao.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                Quantidade = string.IsNullOrWhiteSpace(txtQuantidade.Text) ? (int?)null : Convert.ToInt32(txtQuantidade.Text),
                ValorEstimado = string.IsNullOrWhiteSpace(txtValorEstimado.Text) ? (decimal?)null : Convert.ToDecimal(txtValorEstimado.Text),
                DataDoacao = dtpDataDoacao.Value
            };

            if (idDoacaoSelecionada == null)
            {
                controller.Inserir(doacao);
                MessageBox.Show("Doação cadastrada com sucesso!");
            }
            else
            {
                doacao.IdDoacao = idDoacaoSelecionada.Value;
                controller.Atualizar(doacao);
                MessageBox.Show("Doação atualizada com sucesso!");
            }

            LimparCampos();
            CarregarGrid();  
    }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idDoacaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma doação para excluir.");
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir esta doação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controller.Excluir(idDoacaoSelecionada.Value);
                MessageBox.Show("Doação excluída com sucesso!");
                LimparCampos();
                CarregarGrid();
            }
        }

        private void dgvDoacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDoacoes.Rows[e.RowIndex];
            idDoacaoSelecionada = Convert.ToInt32(row.Cells["IdDoacao"].Value);
            txtTipoDoacao.Text = row.Cells["TipoDoacao"].Value.ToString();
            txtDescricao.Text = row.Cells["Descricao"].Value.ToString();
            txtQuantidade.Text = row.Cells["Quantidade"].Value?.ToString();
            txtValorEstimado.Text = row.Cells["ValorEstimado"].Value?.ToString();
            dtpDataDoacao.Value = Convert.ToDateTime(row.Cells["DataDoacao"].Value);

            // Seleciona o doador no combo
            for (int i = 0; i < cmbDoador.Items.Count; i++)
            {
                dynamic item = cmbDoador.Items[i];
                if (Convert.ToInt32(item.Id) == Convert.ToInt32(row.Cells["idDoador"].Value))
                {
                    cmbDoador.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
