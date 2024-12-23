
namespace ProjCondominios.UI_Layer
{
    partial class GestaoCondominos
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
            lblTitulo = new Label();
            btnAdicionar = new Button();
            btnRemover = new Button();
            btnEditar = new Button();
            btnListar = new Button();
            BtnFecharCondominos = new Button();
            pnlConteudoCondonimos = new Panel();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Controls.Add(btnAdicionar);
            pnlMenu.Controls.Add(btnRemover);
            pnlMenu.Controls.Add(btnEditar);
            pnlMenu.Controls.Add(btnListar);
            pnlMenu.Controls.Add(BtnFecharCondominos);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(209, 450);
            pnlMenu.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.ForeColor = SystemColors.WindowFrame;
            lblTitulo.Location = new Point(12, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(162, 30);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "CONDÓMINOS";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(12, 104);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(170, 23);
            btnAdicionar.TabIndex = 4;
            btnAdicionar.Text = "Adicionar novo Condómino";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += BtnAdicionar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(12, 149);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(170, 23);
            btnRemover.TabIndex = 3;
            btnRemover.Text = "Remover um Condómino";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += BtnRemover_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(12, 193);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(170, 23);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar dados de Condómino";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += BtnEditar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(12, 235);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(170, 23);
            btnListar.TabIndex = 6;
            btnListar.Text = "Listar todos os condóminos";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += BtnListar_Click;
            // 
            // BtnFecharCondominos
            // 
            BtnFecharCondominos.Location = new Point(61, 327);
            BtnFecharCondominos.Name = "BtnFecharCondominos";
            BtnFecharCondominos.Size = new Size(75, 23);
            BtnFecharCondominos.TabIndex = 8;
            BtnFecharCondominos.Text = "Fechar";
            BtnFecharCondominos.UseVisualStyleBackColor = true;
            BtnFecharCondominos.Click += BtnFecharCondominos_Click;
            // 
            // pnlConteudoCondonimos
            // 
            pnlConteudoCondonimos.Location = new Point(215, 3);
            pnlConteudoCondonimos.Name = "pnlConteudoCondonimos";
            pnlConteudoCondonimos.Size = new Size(566, 447);
            pnlConteudoCondonimos.TabIndex = 2;
            // 
            // GestaoCondominos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 450);
            Controls.Add(pnlConteudoCondonimos);
            Controls.Add(pnlMenu);
            Name = "GestaoCondominos";
            Text = "GestaoCondominos";
            Load += GestaoCondominos_Load;
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Label lblTitulo;
        private Button btnAdicionar;
        private Button btnRemover;
        private Button btnEditar;
        private Button btnListar;
        private Button BtnFecharCondominos;
        private Panel pnlConteudoCondonimos;
    }
}