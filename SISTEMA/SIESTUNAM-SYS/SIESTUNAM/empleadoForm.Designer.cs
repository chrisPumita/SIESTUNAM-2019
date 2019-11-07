namespace SIESTUNAM
{
    partial class empleadoForm
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
            this.pintaPanel = new System.Windows.Forms.Panel();
            this.checkStatus = new System.Windows.Forms.CheckBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblOpcionTitulo = new System.Windows.Forms.Label();
            this.cboTipoUsuario = new System.Windows.Forms.ComboBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtApm = new System.Windows.Forms.TextBox();
            this.txtApp = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNoCuenta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAccion = new System.Windows.Forms.Button();
            this.pintaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pintaPanel
            // 
            this.pintaPanel.Controls.Add(this.checkStatus);
            this.pintaPanel.Controls.Add(this.txtId);
            this.pintaPanel.Controls.Add(this.lblId);
            this.pintaPanel.Controls.Add(this.lblOpcionTitulo);
            this.pintaPanel.Controls.Add(this.cboTipoUsuario);
            this.pintaPanel.Controls.Add(this.cboSex);
            this.pintaPanel.Controls.Add(this.txtMail);
            this.pintaPanel.Controls.Add(this.txtTel);
            this.pintaPanel.Controls.Add(this.txtApm);
            this.pintaPanel.Controls.Add(this.txtApp);
            this.pintaPanel.Controls.Add(this.txtNombre);
            this.pintaPanel.Controls.Add(this.txtNoCuenta);
            this.pintaPanel.Controls.Add(this.label8);
            this.pintaPanel.Controls.Add(this.label7);
            this.pintaPanel.Controls.Add(this.label6);
            this.pintaPanel.Controls.Add(this.label5);
            this.pintaPanel.Controls.Add(this.label4);
            this.pintaPanel.Controls.Add(this.label3);
            this.pintaPanel.Controls.Add(this.label2);
            this.pintaPanel.Controls.Add(this.label1);
            this.pintaPanel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pintaPanel.Location = new System.Drawing.Point(2, 45);
            this.pintaPanel.Name = "pintaPanel";
            this.pintaPanel.Size = new System.Drawing.Size(448, 432);
            this.pintaPanel.TabIndex = 38;
            // 
            // checkStatus
            // 
            this.checkStatus.AutoSize = true;
            this.checkStatus.Checked = true;
            this.checkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkStatus.Location = new System.Drawing.Point(195, 395);
            this.checkStatus.Name = "checkStatus";
            this.checkStatus.Size = new System.Drawing.Size(79, 23);
            this.checkStatus.TabIndex = 51;
            this.checkStatus.Text = "Activo";
            this.checkStatus.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(195, 56);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(227, 27);
            this.txtId.TabIndex = 50;
            this.txtId.Text = "AU";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(157, 59);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(32, 19);
            this.lblId.TabIndex = 49;
            this.lblId.Text = "ID:";
            // 
            // lblOpcionTitulo
            // 
            this.lblOpcionTitulo.AutoSize = true;
            this.lblOpcionTitulo.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpcionTitulo.Location = new System.Drawing.Point(22, 14);
            this.lblOpcionTitulo.Name = "lblOpcionTitulo";
            this.lblOpcionTitulo.Size = new System.Drawing.Size(213, 29);
            this.lblOpcionTitulo.TabIndex = 48;
            this.lblOpcionTitulo.Text = "<AccionRealiza>";
            // 
            // cboTipoUsuario
            // 
            this.cboTipoUsuario.FormattingEnabled = true;
            this.cboTipoUsuario.Items.AddRange(new object[] {
            "Administrador",
            "Empleado"});
            this.cboTipoUsuario.Location = new System.Drawing.Point(195, 350);
            this.cboTipoUsuario.Name = "cboTipoUsuario";
            this.cboTipoUsuario.Size = new System.Drawing.Size(227, 27);
            this.cboTipoUsuario.TabIndex = 47;
            this.cboTipoUsuario.Text = "Seleccion tipo";
            // 
            // cboSex
            // 
            this.cboSex.AutoCompleteCustomSource.AddRange(new string[] {
            "Hombre",
            "Mujer"});
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "Hombre",
            "Mujer"});
            this.cboSex.Location = new System.Drawing.Point(195, 314);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(227, 27);
            this.cboSex.TabIndex = 46;
            this.cboSex.Text = "Seleccione sexo";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(195, 277);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(227, 27);
            this.txtMail.TabIndex = 45;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(195, 240);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(227, 27);
            this.txtTel.TabIndex = 44;
            // 
            // txtApm
            // 
            this.txtApm.Location = new System.Drawing.Point(195, 203);
            this.txtApm.Name = "txtApm";
            this.txtApm.Size = new System.Drawing.Size(227, 27);
            this.txtApm.TabIndex = 43;
            // 
            // txtApp
            // 
            this.txtApp.Location = new System.Drawing.Point(195, 166);
            this.txtApp.Name = "txtApp";
            this.txtApp.Size = new System.Drawing.Size(227, 27);
            this.txtApp.TabIndex = 42;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(195, 129);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(227, 27);
            this.txtNombre.TabIndex = 41;
            // 
            // txtNoCuenta
            // 
            this.txtNoCuenta.Location = new System.Drawing.Point(195, 92);
            this.txtNoCuenta.Name = "txtNoCuenta";
            this.txtNoCuenta.Size = new System.Drawing.Size(227, 27);
            this.txtNoCuenta.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 19);
            this.label8.TabIndex = 39;
            this.label8.Text = "Tipo de cuenta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 19);
            this.label7.TabIndex = 38;
            this.label7.Text = "Sexo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 19);
            this.label6.TabIndex = 37;
            this.label6.Text = "E-mail:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "Telefono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 19);
            this.label4.TabIndex = 35;
            this.label4.Text = "Apellido Materno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "Apellido Paterno:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "No. de Cuenta:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(61)))), ((int)(((byte)(113)))));
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 21);
            this.panel2.TabIndex = 39;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(150)))), ((int)(((byte)(57)))));
            this.panel3.Location = new System.Drawing.Point(2, 527);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(448, 34);
            this.panel3.TabIndex = 40;
            // 
            // btnAccion
            // 
            this.btnAccion.Location = new System.Drawing.Point(317, 483);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(122, 36);
            this.btnAccion.TabIndex = 41;
            this.btnAccion.Text = "<ACTION>";
            this.btnAccion.UseVisualStyleBackColor = true;
            this.btnAccion.Click += new System.EventHandler(this.button1_Click);
            // 
            // empleadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 564);
            this.Controls.Add(this.btnAccion);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pintaPanel);
            this.Name = "empleadoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EMPLEADO";
            this.pintaPanel.ResumeLayout(false);
            this.pintaPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pintaPanel;
        private System.Windows.Forms.CheckBox checkStatus;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblOpcionTitulo;
        private System.Windows.Forms.ComboBox cboTipoUsuario;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtApm;
        private System.Windows.Forms.TextBox txtApp;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNoCuenta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAccion;
    }
}