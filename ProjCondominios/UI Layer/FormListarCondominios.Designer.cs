namespace ProjCondominios.UI_Layer
{
    partial class FormListarCondominios
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
            dgvCondominios = new DataGridView();
            btnRemover = new Button();
            btnRegistoCondominio = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCondominios).BeginInit();
            SuspendLayout();
            // 
            // dgvCondominios
            // 
            dgvCondominios.AllowUserToOrderColumns = true;
            dgvCondominios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCondominios.Location = new Point(396, 51);
            dgvCondominios.Name = "dgvCondominios";
            dgvCondominios.Size = new Size(240, 150);
            dgvCondominios.TabIndex = 0;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(28, 118);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(170, 23);
            btnRemover.TabIndex = 1;
            btnRemover.Text = "Remover 1 Condomínio";
            btnRemover.UseVisualStyleBackColor = true;
            // 
            // btnRegistoCondominio
            // 
            btnRegistoCondominio.Location = new Point(28, 73);
            btnRegistoCondominio.Name = "btnRegistoCondominio";
            btnRegistoCondominio.Size = new Size(170, 23);
            btnRegistoCondominio.TabIndex = 2;
            btnRegistoCondominio.Text = "Adicionar novo Condomínio";
            btnRegistoCondominio.UseVisualStyleBackColor = true;
            btnRegistoCondominio.Click += btnRegistoCondominio_Click;
            // 
            // FormListarCondominios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 514);
            Controls.Add(btnRegistoCondominio);
            Controls.Add(btnRemover);
            Controls.Add(dgvCondominios);
            Name = "FormListarCondominios";
            Text = "FormListarCondominios";
            Load += FormListarCondominios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCondominios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCondominios;
        private Button btnRemover;
        private Button btnRegistoCondominio;
    }
}