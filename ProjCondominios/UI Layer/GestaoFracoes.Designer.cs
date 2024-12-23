namespace ProjCondominios.UI_Layer
{
    partial class GestaoFracoes
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
            pnlConteudoFracoes = new Panel();
            button1 = new Button();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(button1);
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
            pnlMenu.TabIndex = 1;
            // 
            // BtnFechar
            // 
            BtnFechar.Location = new Point(59, 404);
            BtnFechar.Name = "BtnFechar";
            BtnFechar.Size = new Size(75, 23);
            BtnFechar.TabIndex = 8;
            BtnFechar.Text = "Fechar";
            BtnFechar.UseVisualStyleBackColor = true;
            BtnFechar.Click += btnFechar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F);
            lblTitulo.ForeColor = SystemColors.WindowFrame;
            lblTitulo.Location = new Point(12, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(178, 21);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "FRAÇÕES AUTÓNOMAS";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(12, 143);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(170, 23);
            btnAdicionar.TabIndex = 4;
            btnAdicionar.Text = "Adicionar nova Fração";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(12, 188);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(170, 23);
            btnRemover.TabIndex = 3;
            btnRemover.Text = "Remover uma Fração";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(12, 232);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(170, 23);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar dados de Fração";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(12, 274);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(170, 47);
            btnListar.TabIndex = 6;
            btnListar.Text = "Listar Frações de um Condomínio";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnListarTodos
            // 
            button1.Location = new Point(12, 327);
            button1.Name = "button1";
            button1.Size = new Size(170, 23);
            button1.TabIndex = 9;
            button1.Text = "Listar todas as Frações";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnListarTodos_Click;
            // 
            // pnlConteudoFracoes
            // 
            pnlConteudoFracoes.Location = new Point(215, 0);
            pnlConteudoFracoes.Name = "pnlConteudoFracoes";
            pnlConteudoFracoes.Size = new Size(535, 450);
            pnlConteudoFracoes.TabIndex = 2;
            // 
            // GestaoFracoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlConteudoFracoes);
            Controls.Add(pnlMenu);
            Name = "GestaoFracoes";
            Text = "GestaoFracoes";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Button BtnFechar;
        private Label lblTitulo;
        private Button btnAdicionar;
        private Button btnRemover;
        private Button btnEditar;
        private Button btnListar;
        private Panel pnlConteudoFracoes;
        private Button button1;
    }
}