using EsperancaSocial.Desktop.Controllers;
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
    public partial class FrmAtendimento : Form
    {
        private int idAtendimento = 0;
        private AtendimentoController controller = new AtendimentoController();
        public FrmAtendimento()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void FrmAtendimento_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarCombos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
             private void CarregarCombos()
        {
            // Famílias
            cbFamilia.DataSource = new FamiliaController().Listar();
            cbFamilia.DisplayMember = "NomeResponsavel";
            cbFamilia.ValueMember = "IdFamilia";
            cbFamilia.SelectedIndex = -1;

            // Individuos
            cbIndividuo.DataSource = new IndividuoController().ListarCombo();
            cbIndividuo.DisplayMember = "Nome";
            cbIndividuo.ValueMember = "IdIndividuo";
            cbIndividuo.SelectedIndex = -1;

            // Serviços
            cbServico.DataSource = new ServicoController().Listar();
            cbServico.DisplayMember = "NomeServico";
            cbServico.ValueMember = "IdServico";
            cbServico.SelectedIndex = -1;

            // Funcionários
            cbFuncionario.DataSource = new FuncionarioController().ListarCombo();
            cbFuncionario.DisplayMember = "Nome";
            cbFuncionario.ValueMember = "IdFuncionario";
            cbFuncionario.SelectedIndex = -1;

            // Data do atendimento
            dtpDataAtendimento.Value = DateTime.Now;
        }

        private void CarregarGrid()
        {
            dgvAtendimentos.DataSource = null;
            dgvAtendimentos.AutoGenerateColumns = true;
            dgvAtendimentos.DataSource = controller.Listar();

            // Ajustar cabeçalhos
            dgvAtendimentos.Columns["IdAtendimento"].HeaderText = "ID";
            dgvAtendimentos.Columns["NomeFamilia"].HeaderText = "Família";
            dgvAtendimentos.Columns["NomeIndividuo"].HeaderText = "Indivíduo";
            dgvAtendimentos.Columns["NomeServico"].HeaderText = "Serviço";
            dgvAtendimentos.Columns["NomeFuncionario"].HeaderText = "Funcionário";
            dgvAtendimentos.Columns["DataAtendimento"].HeaderText = "Data";
            dgvAtendimentos.Columns["TipoAtendimento"].HeaderText = "Tipo";
            dgvAtendimentos.Columns["Observacoes"].HeaderText = "Observações";

            // Ocultar IDs internos
            dgvAtendimentos.Columns["IdFamilia"].Visible = false;
            dgvAtendimentos.Columns["IdIndividuo"].Visible = false;
            dgvAtendimentos.Columns["IdServico"].Visible = false;
            dgvAtendimentos.Columns["IdFuncionario"].Visible = false;

            dgvAtendimentos.ClearSelection();
        }

        private void LimparCampos()
        {
            idAtendimento = 0;
            cbFamilia.SelectedIndex = -1;
            cbIndividuo.SelectedIndex = -1;
            cbServico.SelectedIndex = -1;
            cbFuncionario.SelectedIndex = -1;

            dtpDataAtendimento.Value = DateTime.Now;
            txtTipoAtendimento.Clear();
            txtObservacoes.Clear();

            dgvAtendimentos.ClearSelection();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var atendimento = new AtendimentoModel
                {
                    IdAtendimento = idAtendimento,
                    IdFamilia = Convert.ToInt32(cbFamilia.SelectedValue),
                    IdIndividuo = cbIndividuo.SelectedIndex != -1 ? Convert.ToInt32(cbIndividuo.SelectedValue) : (int?)null,
                    IdServico = Convert.ToInt32(cbServico.SelectedValue),
                    IdFuncionario = Convert.ToInt32(cbFuncionario.SelectedValue),
                    DataAtendimento = dtpDataAtendimento.Value,
                    TipoAtendimento = txtTipoAtendimento.Text.Trim(),
                    Observacoes = txtObservacoes.Text.Trim()
                };

                if (idAtendimento == 0)
                {
                    controller.Inserir(atendimento);
                    MessageBox.Show("Atendimento cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    controller.Atualizar(atendimento);
                    MessageBox.Show("Atendimento atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (idAtendimento <= 0)
                    throw new Exception("Selecione um atendimento para excluir.");

                controller.Excluir(idAtendimento);
                MessageBox.Show("Atendimento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAtendimentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            var row = dgvAtendimentos.Rows[e.RowIndex];

            idAtendimento = Convert.ToInt32(row.Cells["IdAtendimento"].Value);
            cbFamilia.SelectedValue = row.Cells["IdFamilia"].Value;
            cbIndividuo.SelectedValue = row.Cells["IdIndividuo"].Value;
            cbServico.SelectedValue = row.Cells["IdServico"].Value;
            cbFuncionario.SelectedValue = row.Cells["IdFuncionario"].Value;
            dtpDataAtendimento.Value = Convert.ToDateTime(row.Cells["DataAtendimento"].Value);
            txtTipoAtendimento.Text = row.Cells["TipoAtendimento"].Value?.ToString();
            txtObservacoes.Text = row.Cells["Observacoes"].Value?.ToString();
        }
    }
    }

