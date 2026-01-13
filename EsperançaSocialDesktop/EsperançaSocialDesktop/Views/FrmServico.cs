using EsperançaSocialDesktop.Controllers;
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
    public partial class FrmServico : Form
    {
        private int? idServicoSelecionado = null;
        private ServicoController controller = new ServicoController();
        public FrmServico()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void FrmServico_Load(object sender, EventArgs e)
        {
            CarregarComboProjetos();
            CarregarComboPeriodicidade();
            CarregarGrid();
        }
        private void CarregarComboProjetos()
        {
            cmbProjeto.Items.Clear();
            using (var con = EsperancaSocial.Desktop.Data.Conexao.ObterConexao())
            {
                var cmd = new SqlCommand("SELECT id_projeto, nome_projeto FROM Projeto ORDER BY nome_projeto", con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbProjeto.Items.Add(new { Id = reader["id_projeto"], Nome = reader["nome_projeto"].ToString() });
                }
            }
            if (cmbProjeto.Items.Count > 0) cmbProjeto.SelectedIndex = 0;
        }
        private void CarregarComboPeriodicidade()
        {
            cmbPeriodicidade.Items.Clear();
            cmbPeriodicidade.Items.AddRange(new string[] { "Diária", "Semanal", "Mensal", "Anual" });
            if (cmbPeriodicidade.Items.Count > 0) cmbPeriodicidade.SelectedIndex = 0;
        }
        private void CarregarGrid()
        {
            ServicoController controller = new ServicoController();
            List<ServicoModel> servicos = controller.Listar();

            dgvServicos.DataSource = null;

            if (servicos != null && servicos.Count > 0)
            {
                dgvServicos.DataSource = servicos;

                // Ajusta os nomes das colunas de acordo com as propriedades do Model
                dgvServicos.Columns["IdServico"].HeaderText = "ID";
                dgvServicos.Columns["NomeServico"].HeaderText = "Nome";
                dgvServicos.Columns["Descricao"].HeaderText = "Descrição";
                dgvServicos.Columns["Categoria"].HeaderText = "Categoria";
                dgvServicos.Columns["Periodicidade"].HeaderText = "Periodicidade";
                dgvServicos.Columns["Ativo"].HeaderText = "Ativo";
                dgvServicos.Columns["NomeProjecto"].HeaderText = "Projeto";

            }
        }
        private void LimparCampos()
        {
            idServicoSelecionado = null;
            txtNomeServico.Clear();
            txtDescricao.Clear();
            txtCategoria.Clear();
            if (cmbPeriodicidade.Items.Count > 0) cmbPeriodicidade.SelectedIndex = 0;
            if (cmbProjeto.Items.Count > 0) cmbProjeto.SelectedIndex = 0;
            chkAtivo.Checked = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cmbProjeto.SelectedItem == null)
            {
                MessageBox.Show("Selecione um projeto.");
                return;
            }

            dynamic projetoSelecionado = cmbProjeto.SelectedItem;
            int idProjeto = Convert.ToInt32(projetoSelecionado.Id);

            ServicoModel servico = new ServicoModel
            {
                IdProjecto = idProjeto,
                NomeServico = txtNomeServico.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                Categoria = txtCategoria.Text.Trim(),
                Periodicidade = cmbPeriodicidade.SelectedItem.ToString(),
                Ativo = chkAtivo.Checked
            };

            if (idServicoSelecionado == null)
            {
                controller.Inserir(servico);
                MessageBox.Show("Serviço cadastrado com sucesso!");
            }
            else
            {
                servico.IdServico = idServicoSelecionado.Value;
                controller.Atualizar(servico);
                MessageBox.Show("Serviço atualizado com sucesso!");
            }

            LimparCampos();
            CarregarGrid();
        }

        private void dgvServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            var row = dgvServicos.Rows[e.RowIndex];
            idServicoSelecionado = Convert.ToInt32(row.Cells["IdServico"].Value);
            txtNomeServico.Text = row.Cells["NomeServico"].Value.ToString();
            txtDescricao.Text = row.Cells["Descricao"].Value.ToString();
            txtCategoria.Text = row.Cells["Categoria"].Value.ToString();
            cmbPeriodicidade.SelectedItem = row.Cells["Periodicidade"].Value.ToString();
            chkAtivo.Checked = Convert.ToBoolean(row.Cells["Ativo"].Value);

            // Seleciona o projeto correto
            for (int i = 0; i < cmbProjeto.Items.Count; i++)
            {
                dynamic item = cmbProjeto.Items[i];
                if (Convert.ToInt32(item.Id) == Convert.ToInt32(row.Cells["IdProjecto"].Value))
                {
                    cmbProjeto.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
