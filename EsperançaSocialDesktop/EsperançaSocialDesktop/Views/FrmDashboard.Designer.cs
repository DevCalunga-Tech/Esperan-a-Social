namespace EsperançaSocialDesktop.Forms
{
    partial class FrmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFamilias = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIndividuos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAtendimento = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAgendamento = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServicos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoador = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPerfil = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.btnProj = new System.Windows.Forms.Button();
            this.btnDoacoes = new System.Windows.Forms.Button();
            this.btnAgendamentos = new System.Windows.Forms.Button();
            this.btnAtendimentos = new System.Windows.Forms.Button();
            this.btnfamilias = new System.Windows.Forms.Button();
            this.pnlCont = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNivelAcesso = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblData = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuPrincipal.SuspendLayout();
            this.pnlLateral.SuspendLayout();
            this.pnlCont.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastros,
            this.menuAtendimento,
            this.menuAgendamento,
            this.menuDoacoes,
            this.menuServicos,
            this.menuProjectos,
            this.menuDoador,
            this.menuRelatorios,
            this.menuSistema});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(800, 24);
            this.menuPrincipal.TabIndex = 1;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuCadastros
            // 
            this.menuCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFamilias,
            this.menuIndividuos,
            this.menuFuncionarios,
            this.menuUsuarios});
            this.menuCadastros.Name = "menuCadastros";
            this.menuCadastros.Size = new System.Drawing.Size(71, 20);
            this.menuCadastros.Text = "Cadastros";
            // 
            // menuFamilias
            // 
            this.menuFamilias.Name = "menuFamilias";
            this.menuFamilias.Size = new System.Drawing.Size(142, 22);
            this.menuFamilias.Text = "Familias";
            this.menuFamilias.Click += new System.EventHandler(this.menuFamilias_Click);
            // 
            // menuIndividuos
            // 
            this.menuIndividuos.Name = "menuIndividuos";
            this.menuIndividuos.Size = new System.Drawing.Size(142, 22);
            this.menuIndividuos.Text = "Individuos";
            this.menuIndividuos.Click += new System.EventHandler(this.menuIndividuos_Click);
            // 
            // menuFuncionarios
            // 
            this.menuFuncionarios.Name = "menuFuncionarios";
            this.menuFuncionarios.Size = new System.Drawing.Size(142, 22);
            this.menuFuncionarios.Text = "Funcionarios";
            this.menuFuncionarios.Click += new System.EventHandler(this.menuFuncionarios_Click);
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(142, 22);
            this.menuUsuarios.Text = "Usuarios";
            // 
            // menuAtendimento
            // 
            this.menuAtendimento.Name = "menuAtendimento";
            this.menuAtendimento.Size = new System.Drawing.Size(94, 20);
            this.menuAtendimento.Text = "Atendimentos";
            this.menuAtendimento.Click += new System.EventHandler(this.menuAtendimento_Click);
            // 
            // menuAgendamento
            // 
            this.menuAgendamento.Name = "menuAgendamento";
            this.menuAgendamento.Size = new System.Drawing.Size(100, 20);
            this.menuAgendamento.Text = "Agendamentos";
            this.menuAgendamento.Click += new System.EventHandler(this.menuAgendamento_Click);
            // 
            // menuDoacoes
            // 
            this.menuDoacoes.Name = "menuDoacoes";
            this.menuDoacoes.Size = new System.Drawing.Size(64, 20);
            this.menuDoacoes.Text = "Doações";
            this.menuDoacoes.Click += new System.EventHandler(this.menuDoacoes_Click);
            // 
            // menuServicos
            // 
            this.menuServicos.Name = "menuServicos";
            this.menuServicos.Size = new System.Drawing.Size(62, 20);
            this.menuServicos.Text = "Serviços";
            this.menuServicos.Click += new System.EventHandler(this.serviçosToolStripMenuItem_Click);
            // 
            // menuProjectos
            // 
            this.menuProjectos.Name = "menuProjectos";
            this.menuProjectos.Size = new System.Drawing.Size(64, 20);
            this.menuProjectos.Text = "Pojectos";
            this.menuProjectos.Click += new System.EventHandler(this.menuProjectos_Click);
            // 
            // menuDoador
            // 
            this.menuDoador.Name = "menuDoador";
            this.menuDoador.Size = new System.Drawing.Size(58, 20);
            this.menuDoador.Text = "Doador";
            this.menuDoador.Click += new System.EventHandler(this.menuDoador_Click);
            // 
            // menuRelatorios
            // 
            this.menuRelatorios.Name = "menuRelatorios";
            this.menuRelatorios.Size = new System.Drawing.Size(71, 20);
            this.menuRelatorios.Text = "Relatórios";
            // 
            // menuSistema
            // 
            this.menuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSair,
            this.menuPerfil});
            this.menuSistema.Name = "menuSistema";
            this.menuSistema.Size = new System.Drawing.Size(60, 20);
            this.menuSistema.Text = "Sistema";
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(101, 22);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // menuPerfil
            // 
            this.menuPerfil.Name = "menuPerfil";
            this.menuPerfil.Size = new System.Drawing.Size(101, 22);
            this.menuPerfil.Text = "Perfil";
            // 
            // pnlLateral
            // 
            this.pnlLateral.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlLateral.Controls.Add(this.btnProj);
            this.pnlLateral.Controls.Add(this.btnDoacoes);
            this.pnlLateral.Controls.Add(this.btnAgendamentos);
            this.pnlLateral.Controls.Add(this.btnAtendimentos);
            this.pnlLateral.Controls.Add(this.btnfamilias);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 24);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(200, 426);
            this.pnlLateral.TabIndex = 2;
            // 
            // btnProj
            // 
            this.btnProj.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProj.ForeColor = System.Drawing.Color.White;
            this.btnProj.Location = new System.Drawing.Point(0, 180);
            this.btnProj.Name = "btnProj";
            this.btnProj.Size = new System.Drawing.Size(200, 45);
            this.btnProj.TabIndex = 0;
            this.btnProj.Text = "PROJECTOS SOCIAIS";
            this.btnProj.UseVisualStyleBackColor = true;
            this.btnProj.Click += new System.EventHandler(this.btnProj_Click);
            // 
            // btnDoacoes
            // 
            this.btnDoacoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoacoes.ForeColor = System.Drawing.Color.White;
            this.btnDoacoes.Location = new System.Drawing.Point(0, 135);
            this.btnDoacoes.Name = "btnDoacoes";
            this.btnDoacoes.Size = new System.Drawing.Size(200, 45);
            this.btnDoacoes.TabIndex = 0;
            this.btnDoacoes.Text = "DOAÇÕES";
            this.btnDoacoes.UseVisualStyleBackColor = true;
            this.btnDoacoes.Click += new System.EventHandler(this.btnDoacoes_Click);
            // 
            // btnAgendamentos
            // 
            this.btnAgendamentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgendamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendamentos.ForeColor = System.Drawing.Color.White;
            this.btnAgendamentos.Location = new System.Drawing.Point(0, 90);
            this.btnAgendamentos.Name = "btnAgendamentos";
            this.btnAgendamentos.Size = new System.Drawing.Size(200, 45);
            this.btnAgendamentos.TabIndex = 0;
            this.btnAgendamentos.Text = "AGENDAMENTOS";
            this.btnAgendamentos.UseVisualStyleBackColor = true;
            this.btnAgendamentos.Click += new System.EventHandler(this.btnAgendamentos_Click);
            // 
            // btnAtendimentos
            // 
            this.btnAtendimentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAtendimentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtendimentos.ForeColor = System.Drawing.Color.White;
            this.btnAtendimentos.Location = new System.Drawing.Point(0, 45);
            this.btnAtendimentos.Name = "btnAtendimentos";
            this.btnAtendimentos.Size = new System.Drawing.Size(200, 45);
            this.btnAtendimentos.TabIndex = 0;
            this.btnAtendimentos.Text = "ATENDIMENTOS";
            this.btnAtendimentos.UseVisualStyleBackColor = true;
            this.btnAtendimentos.Click += new System.EventHandler(this.btnAtendimentos_Click);
            // 
            // btnfamilias
            // 
            this.btnfamilias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnfamilias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfamilias.ForeColor = System.Drawing.Color.White;
            this.btnfamilias.Location = new System.Drawing.Point(0, 0);
            this.btnfamilias.Name = "btnfamilias";
            this.btnfamilias.Size = new System.Drawing.Size(200, 45);
            this.btnfamilias.TabIndex = 0;
            this.btnfamilias.Text = "FAMILÍAS";
            this.btnfamilias.UseVisualStyleBackColor = true;
            this.btnfamilias.Click += new System.EventHandler(this.btnfamilias_Click);
            // 
            // pnlCont
            // 
            this.pnlCont.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCont.Controls.Add(this.statusStrip1);
            this.pnlCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCont.Location = new System.Drawing.Point(200, 24);
            this.pnlCont.Name = "pnlCont";
            this.pnlCont.Size = new System.Drawing.Size(600, 426);
            this.pnlCont.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuarioLogado,
            this.lblNivelAcesso,
            this.lblData});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(600, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(59, 17);
            this.lblUsuarioLogado.Text = "USUÁRIO:";
            // 
            // lblNivelAcesso
            // 
            this.lblNivelAcesso.Name = "lblNivelAcesso";
            this.lblNivelAcesso.Size = new System.Drawing.Size(93, 17);
            this.lblNivelAcesso.Text = "Nível de Acesso:";
            // 
            // lblData
            // 
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(31, 17);
            this.lblData.Text = "Data";
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlCont);
            this.Controls.Add(this.pnlLateral);
            this.Controls.Add(this.menuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmDashboard";
            this.Text = "Esperança Social-Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.pnlLateral.ResumeLayout(false);
            this.pnlCont.ResumeLayout(false);
            this.pnlCont.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.Button btnProj;
        private System.Windows.Forms.Button btnDoacoes;
        private System.Windows.Forms.Button btnAgendamentos;
        private System.Windows.Forms.Button btnAtendimentos;
        private System.Windows.Forms.Button btnfamilias;
        private System.Windows.Forms.Panel pnlCont;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioLogado;
        private System.Windows.Forms.ToolStripStatusLabel lblNivelAcesso;
        private System.Windows.Forms.ToolStripStatusLabel lblData;
        private System.Windows.Forms.ToolStripMenuItem menuCadastros;
        private System.Windows.Forms.ToolStripMenuItem menuAtendimento;
        private System.Windows.Forms.ToolStripMenuItem menuFamilias;
        private System.Windows.Forms.ToolStripMenuItem menuIndividuos;
        private System.Windows.Forms.ToolStripMenuItem menuFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuAgendamento;
        private System.Windows.Forms.ToolStripMenuItem menuDoacoes;
        private System.Windows.Forms.ToolStripMenuItem menuServicos;
        private System.Windows.Forms.ToolStripMenuItem menuProjectos;
        private System.Windows.Forms.ToolStripMenuItem menuSistema;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.ToolStripMenuItem menuPerfil;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorios;
        private System.Windows.Forms.ToolStripMenuItem menuDoador;
    }
}