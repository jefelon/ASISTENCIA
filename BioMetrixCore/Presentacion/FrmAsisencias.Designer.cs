namespace BioMetrixCore.Presentacion
{
    partial class FrmAsisencias
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDatosDispositivo = new System.Windows.Forms.Button();
            this.btnListaLocal = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(0, 511);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblStatus.Size = new System.Drawing.Size(800, 25);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "label3";
            // 
            // btnDatosDispositivo
            // 
            this.btnDatosDispositivo.Location = new System.Drawing.Point(93, 29);
            this.btnDatosDispositivo.Name = "btnDatosDispositivo";
            this.btnDatosDispositivo.Size = new System.Drawing.Size(75, 23);
            this.btnDatosDispositivo.TabIndex = 9;
            this.btnDatosDispositivo.Text = "Dispositivo Conectado";
            this.btnDatosDispositivo.UseVisualStyleBackColor = true;
            this.btnDatosDispositivo.Click += new System.EventHandler(this.btnDatosDispositivo_Click);
            // 
            // btnListaLocal
            // 
            this.btnListaLocal.Location = new System.Drawing.Point(12, 29);
            this.btnListaLocal.Name = "btnListaLocal";
            this.btnListaLocal.Size = new System.Drawing.Size(75, 23);
            this.btnListaLocal.TabIndex = 10;
            this.btnListaLocal.Text = "Copia Local";
            this.btnListaLocal.UseVisualStyleBackColor = true;
            this.btnListaLocal.Click += new System.EventHandler(this.btnListaLocal_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 77);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(776, 426);
            this.dgvDatos.TabIndex = 8;
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(174, 29);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(75, 23);
            this.btnSincronizar.TabIndex = 9;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(379, 32);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(101, 20);
            this.dtpDesde.TabIndex = 12;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(508, 31);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(101, 20);
            this.dtpHasta.TabIndex = 12;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(255, 29);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(118, 21);
            this.cmbEmpleado.TabIndex = 13;
            // 
            // FrmAsisencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 536);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.btnDatosDispositivo);
            this.Controls.Add(this.btnListaLocal);
            this.Controls.Add(this.dgvDatos);
            this.Name = "FrmAsisencias";
            this.Text = "FrmAsisencia";
            this.Load += new System.EventHandler(this.FrmAsisencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDatosDispositivo;
        private System.Windows.Forms.Button btnListaLocal;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.ComboBox cmbEmpleado;
    }
}