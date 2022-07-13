namespace FrmClub
{
    partial class FrmModificarValorCuota
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbCuotas = new System.Windows.Forms.ComboBox();
            this.lblElegirCuota = new System.Windows.Forms.Label();
            this.lblNuevoValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Yellow;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAceptar.ForeColor = System.Drawing.Color.Red;
            this.btnAceptar.Location = new System.Drawing.Point(12, 75);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(157, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Yellow;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(192, 75);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(158, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbCuotas
            // 
            this.cmbCuotas.FormattingEnabled = true;
            this.cmbCuotas.Location = new System.Drawing.Point(12, 37);
            this.cmbCuotas.Name = "cmbCuotas";
            this.cmbCuotas.Size = new System.Drawing.Size(157, 23);
            this.cmbCuotas.TabIndex = 2;
            // 
            // lblElegirCuota
            // 
            this.lblElegirCuota.AutoSize = true;
            this.lblElegirCuota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblElegirCuota.ForeColor = System.Drawing.Color.Red;
            this.lblElegirCuota.Location = new System.Drawing.Point(24, 9);
            this.lblElegirCuota.Name = "lblElegirCuota";
            this.lblElegirCuota.Size = new System.Drawing.Size(130, 15);
            this.lblElegirCuota.TabIndex = 3;
            this.lblElegirCuota.Text = "Elija cuota a modificar:";
            // 
            // lblNuevoValor
            // 
            this.lblNuevoValor.AutoSize = true;
            this.lblNuevoValor.BackColor = System.Drawing.Color.Cyan;
            this.lblNuevoValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNuevoValor.ForeColor = System.Drawing.Color.Red;
            this.lblNuevoValor.Location = new System.Drawing.Point(229, 9);
            this.lblNuevoValor.Name = "lblNuevoValor";
            this.lblNuevoValor.Size = new System.Drawing.Size(78, 15);
            this.lblNuevoValor.TabIndex = 4;
            this.lblNuevoValor.Text = "Nuevo valor:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(192, 37);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(158, 23);
            this.txtValor.TabIndex = 5;
            // 
            // FrmModificarValorCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(362, 114);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblNuevoValor);
            this.Controls.Add(this.lblElegirCuota);
            this.Controls.Add(this.cmbCuotas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "FrmModificarValorCuota";
            this.Text = "FrmModificarValorCuota";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbCuotas;
        private System.Windows.Forms.Label lblElegirCuota;
        private System.Windows.Forms.Label lblNuevoValor;
        private System.Windows.Forms.TextBox txtValor;
    }
}