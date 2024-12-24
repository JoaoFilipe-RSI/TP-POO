namespace ProjCondominios.UI_Layer
{
    partial class GestaoRelatorios
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
            pnlMenu = new Panel();
            btnGerarAtasReunioes = new Button();
            BtnFechar = new Button();
            lblTitulo = new Label();
            btnGerarRelatorioPagamentos = new Button();
            btnGerarRelatorioDespesas = new Button();
            btnGerarRelatorioFinanceiro = new Button();
            btnGerarRelatorioReservas = new Button();
            pnlConteudo = new Panel();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnGerarAtasReunioes);
            pnlMenu.Controls.Add(BtnFechar);
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Controls.Add(btnGerarRelatorioPagamentos);
            pnlMenu.Controls.Add(btnGerarRelatorioDespesas);
            pnlMenu.Controls.Add(btnGerarRelatorioFinanceiro);
            pnlMenu.Controls.Add(btnGerarRelatorioReservas);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(222, 450);
            pnlMenu.TabIndex = 1;
            // 
            // btnGerarAtasReunioes
            // 
            btnGerarAtasReunioes.Location = new Point(12, 287);
            btnGerarAtasReunioes.Name = "btnGerarAtasReunioes";
            btnGerarAtasReunioes.Size = new Size(193, 45);
            btnGerarAtasReunioes.TabIndex = 9;
            btnGerarAtasReunioes.Text = "Gerar  Atas de Reuniões de Condomínio";
            btnGerarAtasReunioes.UseVisualStyleBackColor = true;
            btnGerarAtasReunioes.Click += btnGerarAtasReunioes_Click;
            // 
            // BtnFechar
            // 
            BtnFechar.Location = new Point(60, 360);
            BtnFechar.Name = "BtnFechar";
            BtnFechar.Size = new Size(75, 23);
            BtnFechar.TabIndex = 8;
            BtnFechar.Text = "Fechar";
            BtnFechar.UseVisualStyleBackColor = true;
            BtnFechar.Click += BtnFechar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.ForeColor = SystemColors.WindowFrame;
            lblTitulo.Location = new Point(32, 44);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(136, 30);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "RELATÓRIOS";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnGerarRelatorioPagamentos
            // 
            btnGerarRelatorioPagamentos.Location = new Point(12, 112);
            btnGerarRelatorioPagamentos.Name = "btnGerarRelatorioPagamentos";
            btnGerarRelatorioPagamentos.Size = new Size(193, 38);
            btnGerarRelatorioPagamentos.TabIndex = 4;
            btnGerarRelatorioPagamentos.Text = "Gerar Relatório de Pagamentos";
            btnGerarRelatorioPagamentos.UseVisualStyleBackColor = true;
            btnGerarRelatorioPagamentos.Click += btnGerarRelatorioPagamentos_Click;
            // 
            // btnGerarRelatorioDespesas
            // 
            btnGerarRelatorioDespesas.Location = new Point(12, 156);
            btnGerarRelatorioDespesas.Name = "btnGerarRelatorioDespesas";
            btnGerarRelatorioDespesas.Size = new Size(193, 32);
            btnGerarRelatorioDespesas.TabIndex = 3;
            btnGerarRelatorioDespesas.Text = "Gerar Relatório de Despesas";
            btnGerarRelatorioDespesas.UseVisualStyleBackColor = true;
            btnGerarRelatorioDespesas.Click += btnGerarRelatorioDespesas_Click;
            // 
            // btnGerarRelatorioFinanceiro
            // 
            btnGerarRelatorioFinanceiro.Location = new Point(12, 194);
            btnGerarRelatorioFinanceiro.Name = "btnGerarRelatorioFinanceiro";
            btnGerarRelatorioFinanceiro.Size = new Size(193, 34);
            btnGerarRelatorioFinanceiro.TabIndex = 5;
            btnGerarRelatorioFinanceiro.Text = "Gerar Relatório Financeiro";
            btnGerarRelatorioFinanceiro.UseVisualStyleBackColor = true;
            btnGerarRelatorioFinanceiro.Click += btnGerarRelatorioFinanceiro_Click;
            // 
            // btnGerarRelatorioReservas
            // 
            btnGerarRelatorioReservas.Location = new Point(12, 234);
            btnGerarRelatorioReservas.Name = "btnGerarRelatorioReservas";
            btnGerarRelatorioReservas.Size = new Size(193, 36);
            btnGerarRelatorioReservas.TabIndex = 6;
            btnGerarRelatorioReservas.Text = "Gerar Relatório de Reservas";
            btnGerarRelatorioReservas.UseVisualStyleBackColor = true;
            btnGerarRelatorioReservas.Click += btnGerarRelatorioReservas_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Location = new Point(237, 0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(562, 450);
            pnlConteudo.TabIndex = 2;
            // 
            // GestaoRelatorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlMenu);
            Name = "GestaoRelatorios";
            Text = "GestaoRelatorios";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Button BtnFechar;
        private Label lblTitulo;
        private Button btnGerarRelatorioPagamentos;
        private Button btnGerarRelatorioDespesas;
        private Button btnGerarRelatorioFinanceiro;
        private Button btnGerarRelatorioReservas;
        private Button btnGerarAtasReunioes;
        private Panel pnlConteudo;
    }
}