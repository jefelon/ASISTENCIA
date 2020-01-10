namespace BioMetrixCore.Presentacion
{
    partial class FrmPersonalRegistrar
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoEmpleado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreTexto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rbtAfpSi = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtAfpNo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtOnpNo = new System.Windows.Forms.RadioButton();
            this.rbtOnpSi = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtAsigFamNo = new System.Windows.Forms.RadioButton();
            this.rbtAsigFamSi = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtRentQuinNo = new System.Windows.Forms.RadioButton();
            this.rbtRentQuinSi = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(1, 2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(47, 20);
            this.txtId.TabIndex = 9;
            this.txtId.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(145, 371);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(89, 35);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "CODIGO EN DISPOSITIVO:";
            // 
            // txtCodigoEmpleado
            // 
            this.txtCodigoEmpleado.Location = new System.Drawing.Point(171, 33);
            this.txtCodigoEmpleado.Name = "txtCodigoEmpleado";
            this.txtCodigoEmpleado.Size = new System.Drawing.Size(205, 20);
            this.txtCodigoEmpleado.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "NOMBRES:";
            // 
            // txtNombreTexto
            // 
            this.txtNombreTexto.Location = new System.Drawing.Point(171, 93);
            this.txtNombreTexto.Name = "txtNombreTexto";
            this.txtNombreTexto.Size = new System.Drawing.Size(205, 20);
            this.txtNombreTexto.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "APELLIDOS:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(171, 130);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(205, 20);
            this.txtApellidos.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "DEPARTAMENTO:";
            this.label5.Visible = false;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(14, 167);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(68, 20);
            this.txtDepartamento.TabIndex = 12;
            this.txtDepartamento.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "CARGO:";
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(169, 167);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(205, 20);
            this.txtCargo.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "AFP:";
            // 
            // rbtAfpSi
            // 
            this.rbtAfpSi.AutoSize = true;
            this.rbtAfpSi.Location = new System.Drawing.Point(6, 16);
            this.rbtAfpSi.Name = "rbtAfpSi";
            this.rbtAfpSi.Size = new System.Drawing.Size(36, 17);
            this.rbtAfpSi.TabIndex = 13;
            this.rbtAfpSi.TabStop = true;
            this.rbtAfpSi.Text = "Sí";
            this.rbtAfpSi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtAfpNo);
            this.groupBox1.Controls.Add(this.rbtAfpSi);
            this.groupBox1.Location = new System.Drawing.Point(98, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 44);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rbtAfpNo
            // 
            this.rbtAfpNo.AutoSize = true;
            this.rbtAfpNo.Location = new System.Drawing.Point(47, 16);
            this.rbtAfpNo.Name = "rbtAfpNo";
            this.rbtAfpNo.Size = new System.Drawing.Size(39, 17);
            this.rbtAfpNo.TabIndex = 13;
            this.rbtAfpNo.TabStop = true;
            this.rbtAfpNo.Text = "No";
            this.rbtAfpNo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtOnpNo);
            this.groupBox2.Controls.Add(this.rbtOnpSi);
            this.groupBox2.Location = new System.Drawing.Point(282, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(92, 44);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // rbtOnpNo
            // 
            this.rbtOnpNo.AutoSize = true;
            this.rbtOnpNo.Location = new System.Drawing.Point(47, 16);
            this.rbtOnpNo.Name = "rbtOnpNo";
            this.rbtOnpNo.Size = new System.Drawing.Size(39, 17);
            this.rbtOnpNo.TabIndex = 13;
            this.rbtOnpNo.TabStop = true;
            this.rbtOnpNo.Text = "No";
            this.rbtOnpNo.UseVisualStyleBackColor = true;
            // 
            // rbtOnpSi
            // 
            this.rbtOnpSi.AutoSize = true;
            this.rbtOnpSi.Location = new System.Drawing.Point(6, 16);
            this.rbtOnpSi.Name = "rbtOnpSi";
            this.rbtOnpSi.Size = new System.Drawing.Size(36, 17);
            this.rbtOnpSi.TabIndex = 13;
            this.rbtOnpSi.TabStop = true;
            this.rbtOnpSi.Text = "Sí";
            this.rbtOnpSi.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(239, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "SNP:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtAsigFamNo);
            this.groupBox3.Controls.Add(this.rbtAsigFamSi);
            this.groupBox3.Location = new System.Drawing.Point(97, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(92, 44);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // rbtAsigFamNo
            // 
            this.rbtAsigFamNo.AutoSize = true;
            this.rbtAsigFamNo.Location = new System.Drawing.Point(47, 16);
            this.rbtAsigFamNo.Name = "rbtAsigFamNo";
            this.rbtAsigFamNo.Size = new System.Drawing.Size(39, 17);
            this.rbtAsigFamNo.TabIndex = 13;
            this.rbtAsigFamNo.TabStop = true;
            this.rbtAsigFamNo.Text = "No";
            this.rbtAsigFamNo.UseVisualStyleBackColor = true;
            // 
            // rbtAsigFamSi
            // 
            this.rbtAsigFamSi.AutoSize = true;
            this.rbtAsigFamSi.Location = new System.Drawing.Point(6, 16);
            this.rbtAsigFamSi.Name = "rbtAsigFamSi";
            this.rbtAsigFamSi.Size = new System.Drawing.Size(36, 17);
            this.rbtAsigFamSi.TabIndex = 13;
            this.rbtAsigFamSi.TabStop = true;
            this.rbtAsigFamSi.Text = "Sí";
            this.rbtAsigFamSi.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "ASIG. FAM.:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtRentQuinNo);
            this.groupBox4.Controls.Add(this.rbtRentQuinSi);
            this.groupBox4.Location = new System.Drawing.Point(284, 281);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(92, 44);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // rbtRentQuinNo
            // 
            this.rbtRentQuinNo.AutoSize = true;
            this.rbtRentQuinNo.Location = new System.Drawing.Point(47, 16);
            this.rbtRentQuinNo.Name = "rbtRentQuinNo";
            this.rbtRentQuinNo.Size = new System.Drawing.Size(39, 17);
            this.rbtRentQuinNo.TabIndex = 13;
            this.rbtRentQuinNo.TabStop = true;
            this.rbtRentQuinNo.Text = "No";
            this.rbtRentQuinNo.UseVisualStyleBackColor = true;
            // 
            // rbtRentQuinSi
            // 
            this.rbtRentQuinSi.AutoSize = true;
            this.rbtRentQuinSi.Location = new System.Drawing.Point(6, 16);
            this.rbtRentQuinSi.Name = "rbtRentQuinSi";
            this.rbtRentQuinSi.Size = new System.Drawing.Size(36, 17);
            this.rbtRentQuinSi.TabIndex = 13;
            this.rbtRentQuinSi.TabStop = true;
            this.rbtRentQuinSi.Text = "Sí";
            this.rbtRentQuinSi.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(198, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "RENTA 5TA.:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(105, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "TIPO:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "EMPLEADO",
            "TRABAJADOR"});
            this.cmbTipo.Location = new System.Drawing.Point(169, 198);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(205, 21);
            this.cmbTipo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(171, 64);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(205, 20);
            this.txtDni.TabIndex = 0;
            // 
            // FrmPersonalRegistrar
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 420);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoEmpleado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCargo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombreTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPersonalRegistrar";
            this.Text = "FrmPersonalRegistrar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodigoEmpleado;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNombreTexto;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.RadioButton rbtAfpSi;
        public System.Windows.Forms.RadioButton rbtAfpNo;
        public System.Windows.Forms.RadioButton rbtOnpNo;
        public System.Windows.Forms.RadioButton rbtOnpSi;
        public System.Windows.Forms.RadioButton rbtAsigFamNo;
        public System.Windows.Forms.RadioButton rbtAsigFamSi;
        public System.Windows.Forms.RadioButton rbtRentQuinNo;
        public System.Windows.Forms.RadioButton rbtRentQuinSi;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDni;
    }
}