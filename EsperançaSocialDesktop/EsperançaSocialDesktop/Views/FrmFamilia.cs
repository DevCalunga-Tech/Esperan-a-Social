using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EsperancaSocial.Desktop.Controllers;
using EsperancaSocial.Desktop.Models;

namespace EsperancaSocial.Desktop.Forms
{
    public partial class FrmFamilia : Form
    {
        private int _idFamiliaSelecionada = 0;
        public FrmFamilia()
        {
            InitializeComponent();
            this.TopLevel = false;
        }

        private void FrmFamilia_Load(object sender, EventArgs e)
        {
            // Inicializa ComboBox Situação
            cmbSituacao.Items.Clear();
            cmbSituacao.Items.Add("Ativa");
            cmbSituacao.Items.Add("Inativa");
            cmbSituacao.SelectedIndex = 0;

            // Configura DataGridView
            dgvFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFamilias.MultiSelect = false;
            dgvFamilias.AutoGenerateColumns = true;
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            FamiliaController controller = new FamiliaController();
            dgvFamilias.DataSource = controller.Listar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            FamiliaModel familia = new FamiliaModel
            {
                IdFamilia = _idFamiliaSelecionada,
                NomeResponsavel = txtNomeResponsavel.Text,
                Telefone = txtTelefone.Text,
                Endereco = txtEndereco.Text,
                Bairro = txtBairro.Text,
                NumeroMembros = int.Parse(txtNumeroMembros.Text),
                RendaFamiliar = decimal.Parse(txtRendaFamiliar.Text),
                Situacao = cmbSituacao.Text
            };

            FamiliaController controller = new FamiliaController();

            if (_idFamiliaSelecionada == 0)
            {
                controller.Inserir(familia);
                MessageBox.Show("Família cadastrada com sucesso!");
            }
            else
            {
                controller.Atualizar(familia);
                MessageBox.Show("Família atualizada com sucesso!");
            }

            LimparCampos();
            CarregarGrid();
        }

        private void LimparCampos()
        {
            txtNomeResponsavel.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtNumeroMembros.Clear();
            txtRendaFamiliar.Clear();
            cmbSituacao.SelectedIndex = 0;

            _idFamiliaSelecionada = 0;
        }

        private void dgvFamilias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvFamilias.Rows[e.RowIndex];

            txtNomeResponsavel.Text = row.Cells["NomeResponsavel"].Value.ToString();
            txtTelefone.Text = row.Cells["Telefone"].Value.ToString();
            txtEndereco.Text = row.Cells["Endereco"].Value.ToString();
            txtBairro.Text = row.Cells["Bairro"].Value.ToString();
            txtNumeroMembros.Text = row.Cells["NumeroMembros"].Value.ToString();
            txtRendaFamiliar.Text = row.Cells["RendaFamiliar"].Value.ToString();
            cmbSituacao.Text = row.Cells["Situacao"].Value.ToString();

            // Guarda o ID selecionado
            _idFamiliaSelecionada = Convert.ToInt32(row.Cells["IdFamilia"].Value);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
            if (_idFamiliaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma família para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                "Tem certeza que deseja excluir esta família?\n\nEsta ação não poderá ser desfeita.",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao == DialogResult.No)
                return;

            FamiliaController controller = new FamiliaController();
            controller.Excluir(_idFamiliaSelecionada);

            MessageBox.Show("Família excluída com sucesso!");

            LimparCampos();
            CarregarGrid();
        

    }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();

            txtNomeResponsavel.Focus();
        }
    }
}

    


