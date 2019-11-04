namespace SIESTUNAM
{
    partial class AddVehiculo
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtPlacas = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 55;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboTipoVehiculo);
            this.panel1.Controls.Add(this.txtColor);
            this.panel1.Controls.Add(this.txtPlacas);
            this.panel1.Controls.Add(this.txtModelo);
            this.panel1.Controls.Add(this.txtMarca);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblNombreUsuario);
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 336);
            this.panel1.TabIndex = 53;
            // 
            // comboTipoVehiculo
            // 
            this.comboTipoVehiculo.AutoCompleteCustomSource.AddRange(new string[] {
            "Moto",
            "Automovil",
            "Camioneta",
            "Camion"});
            this.comboTipoVehiculo.FormattingEnabled = true;
            this.comboTipoVehiculo.Items.AddRange(new object[] {
            "Motocicleta",
            "Autmovil",
            "Camioneta",
            "Camion",
            "Otro"});
            this.comboTipoVehiculo.Location = new System.Drawing.Point(196, 97);
            this.comboTipoVehiculo.Name = "comboTipoVehiculo";
            this.comboTipoVehiculo.Size = new System.Drawing.Size(207, 27);
            this.comboTipoVehiculo.TabIndex = 62;
            this.comboTipoVehiculo.Text = "Seleccione Vehiculo";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(196, 244);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(207, 27);
            this.txtColor.TabIndex = 61;
            // 
            // txtPlacas
            // 
            this.txtPlacas.Location = new System.Drawing.Point(196, 207);
            this.txtPlacas.Name = "txtPlacas";
            this.txtPlacas.Size = new System.Drawing.Size(207, 27);
            this.txtPlacas.TabIndex = 60;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(196, 170);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(207, 27);
            this.txtModelo.TabIndex = 59;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(196, 133);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(207, 27);
            this.txtMarca.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(113, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 19);
            this.label13.TabIndex = 57;
            this.label13.Text = "Color:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(105, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 19);
            this.label12.TabIndex = 56;
            this.label12.Text = "Placas:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(94, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 19);
            this.label11.TabIndex = 55;
            this.label11.Text = "Modelo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(106, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 19);
            this.label10.TabIndex = 54;
            this.label10.Text = "Marca:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 19);
            this.label2.TabIndex = 53;
            this.label2.Text = "Tipo de Vehiculo:";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(22, 52);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(169, 29);
            this.lblNombreUsuario.TabIndex = 52;
            this.lblNombreUsuario.Text = "<UserName>";
            // 
            // cboStatus
            // 
            this.cboStatus.AutoSize = true;
            this.cboStatus.Checked = true;
            this.cboStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboStatus.Location = new System.Drawing.Point(196, 291);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(79, 23);
            this.cboStatus.TabIndex = 51;
            this.cboStatus.Text = "Activo";
            this.cboStatus.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 29);
            this.label9.TabIndex = 48;
            this.label9.Text = "Agregar vehiculo a:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(150)))), ((int)(((byte)(57)))));
            this.panel3.Location = new System.Drawing.Point(2, 417);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(448, 34);
            this.panel3.TabIndex = 52;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(61)))), ((int)(((byte)(113)))));
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 21);
            this.panel2.TabIndex = 51;
            // 
            // AddVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 450);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "AddVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddVehiculo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.CheckBox cboStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboTipoVehiculo;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtPlacas;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
    }
}