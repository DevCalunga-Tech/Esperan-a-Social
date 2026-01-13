using EsperançaSocialDesktop.Controllers;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EsperançaSocialDesktop.Views
{
    public partial class FrmProjecto : Form
    {
        private int? idProjectoSelecionado = null;
        private ProjectoController controller = new ProjectoController();

        public FrmProjecto()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void FrmProjecto_Load(object sender, EventArgs e)
        {
            CarregarStatus();
            CarregarGrid();
        }

        // STATUS PADRÃO
        private void CarregarStatus()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Planeado");
            cmbStatus.Items.Add("Em Execução");
            cmbStatus.Items.Add("Concluído");
            cmbStatus.Items.Add("Cancelado");

            cmbStatus.SelectedIndex = 0;
        }
        private void CarregarGrid()
        {
            dgvProjectos.DataSource = null;
            dgvProjectos.DataSource = controller.Listar();

            dgvProjectos.Columns["IdProjecto"].HeaderText = "ID";
            dgvProjectos.Columns["NomeProjecto"].HeaderText = "Projeto";
            dgvProjectos.Columns["DataInicio"].HeaderText = "Início";
            dgvProjectos.Columns["DataFim"].HeaderText = "Fim";
            dgvProjectos.Columns["Descricao"].HeaderText = "Descrição";
            dgvProjectos.Columns["Status"].HeaderText = "Status";

            dgvProjectos.Columns["IdProjecto"].Visible = false;
        }
        // LIMPAR CAMPOS
        private void LimparCampos()
        {
            idProjectoSelecionado = null;
            txtNomeProjecto.Clear();
            txtDescricao.Clear();
            cmbStatus.SelectedIndex = 0;
            dtpDataInicio.Value = DateTime.Now;
            dtpDataFim.Value = DateTime.Now;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ProjectoModel projecto = new ProjectoModel
            {
                NomeProjecto = txtNomeProjecto.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                Status = cmbStatus.Text,
                DataInicio = dtpDataInicio.Value,
                DataFim = dtpDataFim.Checked ? dtpDataFim.Value : (DateTime?)null
            }
            ;

            if (idProjectoSelecionado == null)
            {
                controller.Inserir(projecto);
                MessageBox.Show("Projeto cadastrado com sucesso!");
            }
            else
            {
                projecto.IdProjecto = idProjectoSelecionado.Value;
                controller.Atualizar(projecto);
                MessageBox.Show("Projeto atualizado com sucesso!");
            }

            LimparCampos();
            CarregarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (idProjectoSelecionado == null)
            {
                MessageBox.Show("Selecione um projeto para excluir.");
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir este projeto?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controller.Excluir(idProjectoSelecionado.Value);
                MessageBox.Show("Projeto excluído com sucesso!");
                LimparCampos();
                CarregarGrid();
            }
        }

        private void dgvProjectos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProjectos.Rows[e.RowIndex];

            idProjectoSelecionado = Convert.ToInt32(row.Cells["IdProjecto"].Value);
            txtNomeProjecto.Text = row.Cells["NomeProjecto"].Value.ToString();
            txtDescricao.Text = row.Cells["Descricao"].Value.ToString();
            cmbStatus.Text = row.Cells["Status"].Value.ToString();
            dtpDataInicio.Value = Convert.ToDateTime(row.Cells["DataInicio"].Value);

            if (row.Cells["DataFim"].Value == DBNull.Value)
                dtpDataFim.Checked = false;
            else
            {
                dtpDataFim.Checked = true;
                dtpDataFim.Value = Convert.ToDateTime(row.Cells["DataFim"].Value);
            }
        }

      
    }

}