namespace BioMetrixCore.Presentacion
{
    partial class FrmUsuarios
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnListaLocal = new System.Windows.Forms.Button();
            this.btnDatosDispositivo = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 106);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(526, 278);
            this.dgvDatos.TabIndex = 0;
            // 
            // btnListaLocal
            // 
            this.btnListaLocal.Location = new System.Drawing.Point(12, 58);
            this.btnListaLocal.Name = "btnListaLocal";
            this.btnListaLocal.Size = new System.Drawing.Size(75, 23);
            this.btnListaLocal.TabIndex = 1;
            this.btnListaLocal.Text = "Copia Local";
            this.btnListaLocal.UseVisualStyleBackColor = true;
            this.btnListaLocal.Click += new System.EventHandler(this.btnListaLocal_Click);
            // 
            // btnDatosDispositivo
            // 
            this.btnDatosDispositivo.Location = new System.Drawing.Point(93, 58);
            this.btnDatosDispositivo.Name = "btnDatosDispositivo";
            this.btnDatosDispositivo.Size = new System.Drawing.Size(75, 23);
            this.btnDatosDispositivo.TabIndex = 1;
            this.btnDatosDispositivo.Text = "Dispositivo Conectado";
            this.btnDatosDispositivo.UseVisualStyleBackColor = true;
            this.btnDatosDispositivo.Click += new System.EventHandler(this.btnDatosDispositivo_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(0, 401);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblStatus.Size = new System.Drawing.Size(550, 25);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "label3";
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 426);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDatosDispositivo);
            this.Controls.Add(this.btnListaLocal);
            this.Controls.Add(this.dgvDatos);
            this.Name = "FrmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnListaLocal;
        private System.Windows.Forms.Button btnDatosDispositivo;
        private System.Windows.Forms.Label lblStatus;
    }
}