namespace ProjCondominios.UI_Layer
{
    partial class GestaoReservas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();

            // Aqui, removemos quaisquer inicializações duplicadas
            // Não adicionamos controles como TextBox, ComboBox ou Button
            // Eles já estão sendo inicializados dinamicamente no código principal do formulário.

            // Configuração inicial do formulário (geral)
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "GestaoReservas";
        }

        // Campo de componentes (gerado pelo Designer)
        private System.ComponentModel.IContainer components = null;
        #endregion
    }
}