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
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.btnBorrarBase = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnAgregarRegistro = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(0, 540);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblStatus.Size = new System.Drawing.Size(882, 25);
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
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 100);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(858, 434);
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
            this.dtpDesde.Location = new System.Drawing.Point(607, 28);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(96, 20);
            this.dtpDesde.TabIndex = 12;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(711, 28);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(101, 20);
            this.dtpHasta.TabIndex = 12;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(12, 2);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(118, 21);
            this.cmbEmpleado.TabIndex = 13;
            this.cmbEmpleado.Visible = false;
            // 
            // cmbEmp
            // 
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(448, 28);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(153, 21);
            this.cmbEmp.TabIndex = 13;
            this.cmbEmp.SelectedIndexChanged += new System.EventHandler(this.cmbEmp_SelectedIndexChanged);
            // 
            // btnBorrarBase
            // 
            this.btnBorrarBase.Location = new System.Drawing.Point(136, 2);
            this.btnBorrarBase.Name = "btnBorrarBase";
            this.btnBorrarBase.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarBase.TabIndex = 9;
            this.btnBorrarBase.Text = "Borrar Base";
            this.btnBorrarBase.UseVisualStyleBackColor = true;
            this.btnBorrarBase.Visible = false;
            this.btnBorrarBase.Click += new System.EventHandler(this.btnBorrarBase_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(818, 25);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(50, 23);
            this.btnFiltrar.TabIndex = 15;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "TRABAJADOR",
            "EMPLEADO"});
            this.cmbTipo.Location = new System.Drawing.Point(326, 29);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(106, 21);
            this.cmbTipo.TabIndex = 13;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbEmp_SelectedIndexChanged);
            // 
            // btnAgregarRegistro
            // 
            this.btnAgregarRegistro.Location = new System.Drawing.Point(12, 58);
            this.btnAgregarRegistro.Name = "btnAgregarRegistro";
            this.btnAgregarRegistro.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarRegistro.TabIndex = 16;
            this.btnAgregarRegistro.Text = "Agregar";
            this.btnAgregarRegistro.UseVisualStyleBackColor = true;
            this.btnAgregarRegistro.Click += new System.EventHandler(this.btnAgregarRegistro_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(93, 58);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 16;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tipo:";
            // 
            // FrmAsisencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 565);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnAgregarRegistro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmbEmp);
            this.Controls.Add(this.cmbEmpleado);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBorrarBase);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.btnDatosDispositivo);
            this.Controls.Add(this.btnListaLocal);
            this.Controls.Add(this.dgvDatos);
            this.Name = "FrmAsisencias";
            this.Text = "FrmAsistencia";
            this.Load += new System.EventHandler(this.FrmAsisencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox cmbEmp;
        private System.Windows.Forms.Button btnBorrarBase;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnAgregarRegistro;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label label1;
    }
}