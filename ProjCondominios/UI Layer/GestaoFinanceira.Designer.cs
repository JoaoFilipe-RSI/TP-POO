namespace ProjCondominios.UI_Layer
{
    partial class GestaoFinanceira
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
            BtnFechar = new Button();
            lblTitulo = new Label();
            btnCalcularSaldo = new Button();
            btnRelatorioFinanceiro = new Button();
            btnCalcularBalanco = new Button();
            pnlConteudo = new Panel();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(BtnFechar);
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Controls.Add(btnCalcularSaldo);
            pnlMenu.Controls.Add(btnRelatorioFinanceiro);
            pnlMenu.Controls.Add(btnCalcularBalanco);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(209, 450);
            pnlMenu.TabIndex = 1;
            // 
            // BtnFechar
            // 
            BtnFechar.Location = new Point(61, 327);
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
            lblTitulo.Location = new Point(31, 52);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(137, 30);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "FINANCEIRO";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnCalcularSaldo
            // 
            btnCalcularSaldo.Location = new Point(12, 143);
            btnCalcularSaldo.Name = "btnCalcularSaldo";
            btnCalcularSaldo.Size = new Size(170, 39);
            btnCalcularSaldo.TabIndex = 4;
            btnCalcularSaldo.Text = "Calcular Saldo de Condomínio";
            btnCalcularSaldo.UseVisualStyleBackColor = true;
            btnCalcularSaldo.Click += btnCalcularSaldo_Click;
            // 
            // btnRelatorioFinanceiro
            // 
            btnRelatorioFinanceiro.Location = new Point(12, 198);
            btnRelatorioFinanceiro.Name = "btnRelatorioFinanceiro";
            btnRelatorioFinanceiro.Size = new Size(170, 40);
            btnRelatorioFinanceiro.TabIndex = 5;
            btnRelatorioFinanceiro.Text = "Ver Relatório Financeiro de Condomínio";
            btnRelatorioFinanceiro.UseVisualStyleBackColor = true;
            btnRelatorioFinanceiro.Click += btnRelatorioFinanceiro_Click;
            // 
            // btnCalcularBalanco
            // 
            btnCalcularBalanco.Location = new Point(12, 255);
            btnCalcularBalanco.Name = "btnCalcularBalanco";
            btnCalcularBalanco.Size = new Size(170, 42);
            btnCalcularBalanco.TabIndex = 6;
            btnCalcularBalanco.Text = "Calcular Balanço Financeiro de Condomínio";
            btnCalcularBalanco.UseVisualStyleBackColor = true;
            btnCalcularBalanco.Click += btnCalcularBalanco_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Location = new Point(215, 0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(596, 450);
            pnlConteudo.TabIndex = 2;
            // 
            // GestaoFinanceira
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlMenu);
            Name = "GestaoFinanceira";
            Text = "GestaoFinanceira";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        
        private Panel pnlMenu;
        private Button BtnFechar;
        private Label lblTitulo;
        private Button btnCalcularSaldo;
        private Button btnRelatorioFinanceiro;
        private Button btnCalcularBalanco;
        private Panel pnlConteudo;
    }
}