namespace ProjCondominios.UI_Layer
{
    partial class GestaoReservas
    {
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Limpa os recursos que estão sendo usados.
            /// </summary>
            /// <param name="disposing">true se os recursos gerenciados devem ser descartados; caso contrário, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Código Gerado pelo Designer do Windows Form

            private void InitializeComponent()
            {
                this.lblCondominio = new System.Windows.Forms.Label();
                this.txtDescricao = new System.Windows.Forms.TextBox();
                this.lblDescricao = new System.Windows.Forms.Label();
                this.dtpData = new System.Windows.Forms.DateTimePicker();
                this.lblData = new System.Windows.Forms.Label();
                this.txtHoraInicio = new System.Windows.Forms.TextBox();
                this.lblHoraInicio = new System.Windows.Forms.Label();
                this.txtHoraFim = new System.Windows.Forms.TextBox();
                this.lblHoraFim = new System.Windows.Forms.Label();
                this.cmbTipoReserva = new System.Windows.Forms.ComboBox();
                this.lblTipoReserva = new System.Windows.Forms.Label();
                this.cmbCondomino = new System.Windows.Forms.ComboBox();
                this.lblCondomino = new System.Windows.Forms.Label();
                this.btnRegistrarReserva = new System.Windows.Forms.Button();
                this.btnAtualizarReserva = new System.Windows.Forms.Button();
                this.btnCancelarReserva = new System.Windows.Forms.Button();
                this.lstReservas = new System.Windows.Forms.ListBox();
                this.lblReservas = new System.Windows.Forms.Label();
                this.SuspendLayout();

                // lblCondominio
                this.lblCondominio.AutoSize = true;
                this.lblCondominio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
                this.lblCondominio.Location = new System.Drawing.Point(12, 9);
                this.lblCondominio.Name = "lblCondominio";
                this.lblCondominio.Size = new System.Drawing.Size(202, 25);
                this.lblCondominio.TabIndex = 0;
                this.lblCondominio.Text = "Gestão de Reservas";

                // txtDescricao
                this.txtDescricao.Location = new System.Drawing.Point(17, 60);
                this.txtDescricao.Name = "txtDescricao";
                this.txtDescricao.Size = new System.Drawing.Size(250, 23);
                this.txtDescricao.TabIndex = 1;

                // lblDescricao
                this.lblDescricao.AutoSize = true;
                this.lblDescricao.Location = new System.Drawing.Point(14, 42);
                this.lblDescricao.Name = "lblDescricao";
                this.lblDescricao.Size = new System.Drawing.Size(62, 15);
                this.lblDescricao.TabIndex = 2;
                this.lblDescricao.Text = "Descrição:";

                // dtpData
                this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                this.dtpData.Location = new System.Drawing.Point(17, 109);
                this.dtpData.Name = "dtpData";
                this.dtpData.Size = new System.Drawing.Size(250, 23);
                this.dtpData.TabIndex = 2;

                // lblData
                this.lblData.AutoSize = true;
                this.lblData.Location = new System.Drawing.Point(14, 91);
                this.lblData.Name = "lblData";
                this.lblData.Size = new System.Drawing.Size(34, 15);
                this.lblData.TabIndex = 4;
                this.lblData.Text = "Data:";

                // txtHoraInicio
                this.txtHoraInicio.Location = new System.Drawing.Point(17, 158);
                this.txtHoraInicio.Name = "txtHoraInicio";
                this.txtHoraInicio.Size = new System.Drawing.Size(120, 23);
                this.txtHoraInicio.TabIndex = 3;

                // lblHoraInicio
                this.lblHoraInicio.AutoSize = true;
                this.lblHoraInicio.Location = new System.Drawing.Point(14, 140);
                this.lblHoraInicio.Name = "lblHoraInicio";
                this.lblHoraInicio.Size = new System.Drawing.Size(71, 15);
                this.lblHoraInicio.TabIndex = 6;
                this.lblHoraInicio.Text = "Hora Início:";

                // txtHoraFim
                this.txtHoraFim.Location = new System.Drawing.Point(147, 158);
                this.txtHoraFim.Name = "txtHoraFim";
                this.txtHoraFim.Size = new System.Drawing.Size(120, 23);
                this.txtHoraFim.TabIndex = 4;

                // lblHoraFim
                this.lblHoraFim.AutoSize = true;
                this.lblHoraFim.Location = new System.Drawing.Point(144, 140);
                this.lblHoraFim.Name = "lblHoraFim";
                this.lblHoraFim.Size = new System.Drawing.Size(62, 15);
                this.lblHoraFim.TabIndex = 8;
                this.lblHoraFim.Text = "Hora Fim:";

                // cmbTipoReserva
                this.cmbTipoReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cmbTipoReserva.FormattingEnabled = true;
                this.cmbTipoReserva.Location = new System.Drawing.Point(17, 207);
                this.cmbTipoReserva.Name = "cmbTipoReserva";
                this.cmbTipoReserva.Size = new System.Drawing.Size(250, 23);
                this.cmbTipoReserva.TabIndex = 5;

                // lblTipoReserva
                this.lblTipoReserva.AutoSize = true;
                this.lblTipoReserva.Location = new System.Drawing.Point(14, 189);
                this.lblTipoReserva.Name = "lblTipoReserva";
                this.lblTipoReserva.Size = new System.Drawing.Size(88, 15);
                this.lblTipoReserva.TabIndex = 10;
                this.lblTipoReserva.Text = "Tipo de Reserva:";

                // cmbCondomino
                this.cmbCondomino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cmbCondomino.FormattingEnabled = true;
                this.cmbCondomino.Location = new System.Drawing.Point(17, 256);
                this.cmbCondomino.Name = "cmbCondomino";
                this.cmbCondomino.Size = new System.Drawing.Size(250, 23);
                this.cmbCondomino.TabIndex = 6;

                // lblCondomino
                this.lblCondomino.AutoSize = true;
                this.lblCondomino.Location = new System.Drawing.Point(14, 238);
                this.lblCondomino.Name = "lblCondomino";
                this.lblCondomino.Size = new System.Drawing.Size(72, 15);
                this.lblCondomino.TabIndex = 12;
                this.lblCondomino.Text = "Condômino:";

                // btnRegistrarReserva
                this.btnRegistrarReserva.Location = new System.Drawing.Point(17, 295);
                this.btnRegistrarReserva.Name = "btnRegistrarReserva";
                this.btnRegistrarReserva.Size = new System.Drawing.Size(75, 23);
                this.btnRegistrarReserva.TabIndex = 7;
                this.btnRegistrarReserva.Text = "Registrar";
                this.btnRegistrarReserva.UseVisualStyleBackColor = true;
                this.btnRegistrarReserva.Click += new System.EventHandler(this.btnRegistrarReserva_Click);

                // btnAtualizarReserva
                this.btnAtualizarReserva.Location = new System.Drawing.Point(98, 295);
                this.btnAtualizarReserva.Name = "btnAtualizarReserva";
                this.btnAtualizarReserva.Size = new System.Drawing.Size(75, 23);
                this.btnAtualizarReserva.TabIndex = 8;
                this.btnAtualizarReserva.Text = "Atualizar";
                this.btnAtualizarReserva.UseVisualStyleBackColor = true;
                this.btnAtualizarReserva.Click += new System.EventHandler(this.btnAtualizarReserva_Click);

                // btnCancelarReserva
                this.btnCancelarReserva.Location = new System.Drawing.Point(179, 295);
                this.btnCancelarReserva.Name = "btnCancelarReserva";
                this.btnCancelarReserva.Size = new System.Drawing.Size(75, 23);
                this.btnCancelarReserva.TabIndex = 9;
                this.btnCancelarReserva.Text = "Cancelar";
                this.btnCancelarReserva.UseVisualStyleBackColor = true;
                this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);

                // lstReservas
                this.lstReservas.FormattingEnabled = true;
                this.lstReservas.ItemHeight = 15;
                this.lstReservas.Location = new System.Drawing.Point(290, 60);
                this.lstReservas.Name = "lstReservas";
                this.lstReservas.Size = new System.Drawing.Size(320, 259);
                this.lstReservas.TabIndex = 10;
                this.lstReservas.SelectedIndexChanged += new System.EventHandler(this.lstReservas_SelectedIndexChanged);

                // lblReservas
                this.lblReservas.AutoSize = true;
                this.lblReservas.Location = new System.Drawing.Point(287, 42);
                this.lblReservas.Name = "lblReservas";
                this.lblReservas.Size = new System.Drawing.Size(56, 15);
                this.lblReservas.TabIndex = 17;
                this.lblReservas.Text = "Reservas:";

                // FormGestaoReservas
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(634, 341);
                this.Controls.Add(this.lblReservas);
                this.Controls.Add(this.lstReservas);
                this.Controls.Add(this.btnCancelarReserva);
                this.Controls.Add(this.btnAtualizarReserva);
                this.Controls.Add(this.btnRegistrarReserva);
                this.Controls.Add(this.lblCondomino);
                this.Controls.Add(this.cmbCondomino);
                this.Controls.Add(this.lblTipoReserva);
                this.Controls.Add(this.cmbTipoReserva);
                this.Controls.Add(this.lblHoraFim);
                this.Controls.Add(this.txtHoraFim);
                this.Controls.Add(this.lblHoraInicio);
                this.Controls.Add(this.txtHoraInicio);
                this.Controls.Add(this.lblData);
                this.Controls.Add(this.dtpData);
                this.Controls.Add(this.lblDescricao);
                this.Controls.Add(this.txtDescricao);
                this.Controls.Add(this.lblCondominio);
                this.Name = "FormGestaoReservas";
                this.Text = "Gestão de Reservas";
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            #endregion

            private System.Windows.Forms.Label lblCondominio;
            private System.Windows.Forms.TextBox txtDescricao;
            private System.Windows.Forms.Label lblDescricao;
            private System.Windows.Forms.DateTimePicker dtpData;
            private System.Windows.Forms.Label lblData;
            private System.Windows.Forms.TextBox txtHoraInicio;
            private System.Windows.Forms.Label lblHoraInicio;
            private System.Windows.Forms.TextBox txtHoraFim;
            private System.Windows.Forms.Label lblHoraFim;
            private System.Windows.Forms.ComboBox cmbTipoReserva;
            private System.Windows.Forms.Label lblTipoReserva;
            private System.Windows.Forms.ComboBox cmbCondomino;
            private System.Windows.Forms.Label lblCondomino;
            private System.Windows.Forms.Button btnRegistrarReserva;
            private System.Windows.Forms.Button btnAtualizarReserva;
            private System.Windows.Forms.Button btnCancelarReserva;
            private System.Windows.Forms.ListBox lstReservas;
            private System.Windows.Forms.Label lblReservas;
        }
    }