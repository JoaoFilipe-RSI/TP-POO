namespace ProjCondominios.Forms
{
    partial class FormRegistoCondominio
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
        /// 


        private void InitializeComponent()
        {
            txtNome = new TextBox();
            txtEndereco = new TextBox();
            txtOrcamentoAnual = new TextBox();
            cbTipoCondominio = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(238, 30);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(189, 23);
            txtNome.TabIndex = 0;
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(238, 82);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(189, 23);
            txtEndereco.TabIndex = 1;
            // 
            // txtOrcamentoAnual
            // 
            txtOrcamentoAnual.Location = new Point(238, 193);
            txtOrcamentoAnual.Name = "txtOrcamentoAnual";
            txtOrcamentoAnual.Size = new Size(189, 23);
            txtOrcamentoAnual.TabIndex = 2;
            // 
            // cbTipoCondominio
            // 
            cbTipoCondominio.FormattingEnabled = true;
            cbTipoCondominio.Location = new Point(238, 138);
            cbTipoCondominio.Name = "cbTipoCondominio";
            cbTipoCondominio.Size = new Size(189, 23);
            cbTipoCondominio.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 30);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 4;
            label1.Text = "Nome do Condomínio:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 83);
            label2.Name = "label2";
            label2.Size = new Size(146, 15);
            label2.TabIndex = 5;
            label2.Text = "Endereço do Condomínio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 139);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 6;
            label3.Text = "Tipo de Condomínio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 194);
            label4.Name = "label4";
            label4.Size = new Size(189, 15);
            label4.TabIndex = 7;
            label4.Text = "Orçamento anual do Condomínio:";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(298, 260);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // FormRegistoCondominio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 450);
            Controls.Add(btnSalvar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbTipoCondominio);
            Controls.Add(txtOrcamentoAnual);
            Controls.Add(txtEndereco);
            Controls.Add(txtNome);
            Name = "FormRegistoCondominio";
            Text = "Registar novo Condominio";
            FormClosing += FormRegistoCondominio_FormClosing;
            Load += FormRegistoCondominio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtEndereco;
        private TextBox txtOrcamentoAnual;
        private ComboBox cbTipoCondominio;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSalvar;
    }
}