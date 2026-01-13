using EsperancaSocial.Desktop.Controllers;
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
    public partial class FrmFuncionario : Form

    {
        private int? idFuncionarioSelecionado = null;
        private FuncionarioController controller = new FuncionarioController();
        public FrmFuncionario()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
           
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            dgvFuncionarios.DataSource = null;
            dgvFuncionarios.DataSource = controller.Listar();
        }
        private void LimparCampos()
        {
            idFuncionarioSelecionado = null;

            txtNome.Clear();
            txtCargo.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            dtpDataEntrada.Value = DateTime.Now;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            FuncionarioModel funcionario = new FuncionarioModel
            {
                Nome = txtNome.Text.Trim(),
                Cargo = txtCargo.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DataEntrada = dtpDataEntrada.Value
            };

            if (idFuncionarioSelecionado == null)
            {
                controller.Inserir(funcionario);
                MessageBox.Show("Funcionário cadastrado com sucesso.");
            }
            else
            {
                funcionario.IdFuncionario = idFuncionarioSelecionado.Value;
                controller.Atualizar(funcionario);
                MessageBox.Show("Funcionário atualizado com sucesso.");
            }

            LimparCampos();
            CarregarGrid();
        }

         

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (idFuncionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário para excluir.");
                return;
            }
            if (MessageBox.Show("Deseja realmente excluir este indivíduo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controller.Excluir(idFuncionarioSelecionado.Value);
                MessageBox.Show("Indivíduo excluído com sucesso!");
                LimparCampos();
                CarregarGrid();
            }

            
        }

        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvFuncionarios.Rows[e.RowIndex];

            idFuncionarioSelecionado = Convert.ToInt32(row.Cells[0].Value);
            txtNome.Text = row.Cells[1].Value.ToString();
            txtCargo.Text = row.Cells[2].Value.ToString();
            txtTelefone.Text = row.Cells[3].Value.ToString();
            txtEmail.Text = row.Cells[4].Value.ToString();
            dtpDataEntrada.Value = Convert.ToDateTime(row.Cells[5].Value);
        }
    }
}
