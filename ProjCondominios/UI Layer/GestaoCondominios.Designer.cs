namespace ProjCondominios.UI_Layer
{
    partial class GestaoCondominios
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
            btnAdicionar = new Button();
            btnRemover = new Button();
            btnEditar = new Button();
            btnListar = new Button();
            pnlConteudo = new Panel();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(BtnFechar);
            pnlMenu.Controls.Add(lblTitulo);
            pnlMenu.Controls.Add(btnAdicionar);
            pnlMenu.Controls.Add(btnRemover);
            pnlMenu.Controls.Add(btnEditar);
            pnlMenu.Controls.Add(btnListar);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(209, 450);
            pnlMenu.TabIndex = 0;
            pnlMenu.Paint += pnlMenu_Paint;
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
            lblTitulo.Location = new Point(12, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(168, 30);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "CONDOMÍNIOS";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(12, 143);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(170, 23);
            btnAdicionar.TabIndex = 4;
            btnAdicionar.Text = "Adicionar novo Condomínio";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(12, 188);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(170, 23);
            btnRemover.TabIndex = 3;
            btnRemover.Text = "Remover um Condomínio";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += BtnRemover_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(12, 232);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(170, 23);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar dados de Condomínio";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += BtnEditar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(12, 274);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(170, 23);
            btnListar.TabIndex = 6;
            btnListar.Text = "Listar todos os condomínios";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += BtnListar_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Location = new Point(215, 0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(596, 450);
            pnlConteudo.TabIndex = 1;
            // 
            // GestaoCondominios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 450);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlMenu);
            Name = "GestaoCondominios";
            Text = "GestaoCondominios";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlConteudo;
        private Button btnListar;
        private Button btnEditar;
        private Button btnAdicionar;
        private Button btnRemover;
        private Label lblTitulo;
        private Button BtnFechar;
    }
}