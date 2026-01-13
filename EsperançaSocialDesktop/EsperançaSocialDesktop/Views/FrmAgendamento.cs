using EsperancaSocial.Desktop.Controllers;
using EsperancaSocial.Desktop.Models;
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
    public partial class FrmAgendamento : Form
    {
        private int idAgendamento = 0;
        private readonly AgendamentoController controller = new AgendamentoController();
        public FrmAgendamento()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void FrmAgendamento_Load(object sender, EventArgs e)
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
            var familias = new FamiliaController().Listar();
            cbFamilia.DataSource = familias;
            cbFamilia.DisplayMember = "NomeResponsavel"; // deve existir no modelo
            cbFamilia.ValueMember = "idFamilia";
            cbFamilia.SelectedIndex = -1;

            // Funcionários
            var funcionarios = new FuncionarioController().ListarCombo();
            cbFuncionario.DataSource = funcionarios;
            cbFuncionario.DisplayMember = "Nome"; // deve existir no modelo
            cbFuncionario.ValueMember = "IdFuncionario";
            cbFuncionario.SelectedIndex = -1;

            // Status
            cbStatus.DataSource = null;
            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new string[] { "Pendente", "Concluído", "Cancelado" });
            cbStatus.SelectedIndex = 0;

        }

        private void CarregarGrid()
        {
            dgvAgendamentos.DataSource = null;
            dgvAgendamentos.AutoGenerateColumns = true;
            dgvAgendamentos.DataSource = controller.Listar();

            dgvAgendamentos.Columns["IdAgendamento"].HeaderText = "ID";
            dgvAgendamentos.Columns["NomeFamilia"].HeaderText = "Família";
            dgvAgendamentos.Columns["NomeFuncionario"].HeaderText = "Funcionário";
            dgvAgendamentos.Columns["DataAgendada"].HeaderText = "Data Agendada";
            dgvAgendamentos.Columns["TipoServico"].HeaderText = "Serviço";
            dgvAgendamentos.Columns["Status"].HeaderText = "Status";

            // Ocultar IDs internos
            dgvAgendamentos.Columns["IdFamilia"].Visible = false;
            dgvAgendamentos.Columns["IdFuncionario"].Visible = false;

            dgvAgendamentos.ClearSelection();
        }
        private void LimparCampos()
        {
            idAgendamento = 0;
            cbFamilia.SelectedIndex = -1;
            cbFuncionario.SelectedIndex = -1;
            dtpDataAgendada.Value = DateTime.Now;
            txtTipoServico.Clear();
            cbStatus.SelectedIndex = cbStatus.Items.Count > 0 ? 0 : -1;
            dgvAgendamentos.ClearSelection();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {


            try

            {

                if (!(cbFamilia.SelectedItem is FamiliaModel familia))
                    throw new Exception("Selecione uma família válida.");

                if (!(cbFuncionario.SelectedItem is FuncionarioModel funcionario))
                    throw new Exception("Selecione um funcionário válido.");

                var agendamento = new AgendamentoModel
                {
                    IdAgendamento = idAgendamento,
                    IdFamilia = familia.IdFamilia,
                    IdFuncionario = funcionario.IdFuncionario,
                    DataAgendada = dtpDataAgendada.Value,
                    TipoServico = txtTipoServico.Text.Trim(),
                    Status = cbStatus.SelectedItem.ToString()
                };

                if (idAgendamento == 0)
                {
                    controller.Inserir(agendamento);
                    MessageBox.Show("Agendamento cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    controller.Atualizar(agendamento);
                    MessageBox.Show("Agendamento atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (idAgendamento == 0)
                    throw new Exception("Selecione um agendamento para excluir.");

                controller.Excluir(idAgendamento);
                MessageBox.Show("Agendamento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvAgendamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvAgendamentos.Rows[e.RowIndex];

            idAgendamento = Convert.ToInt32(row.Cells["IdAgendamento"].Value);
            cbFamilia.SelectedValue = row.Cells["IdFamilia"].Value;
            cbFuncionario.SelectedValue = row.Cells["IdFuncionario"].Value;
            dtpDataAgendada.Value = Convert.ToDateTime(row.Cells["DataAgendada"].Value);
            txtTipoServico.Text = row.Cells["TipoServico"].Value?.ToString();
            cbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "Pendente";

        }
    }
}



