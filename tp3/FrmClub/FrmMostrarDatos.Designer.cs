﻿
namespace FrmClub
{
    partial class FrmListDatos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medallas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partidosJugados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPileta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estiloPreferido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadPeleas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDeAsociacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listNadadoresBtn = new System.Windows.Forms.Button();
            this.lstFutbolistasBtn = new System.Windows.Forms.Button();
            this.btnPugilistas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSocio,
            this.nombre,
            this.apellido,
            this.genero,
            this.edad,
            this.valorCuota,
            this.medallas,
            this.categoria,
            this.posicion,
            this.partidosJugados,
            this.tipoPileta,
            this.estiloPreferido,
            this.categoriaPeso,
            this.cantidadPeleas,
            this.fechaDeAsociacion});
            this.dataGridView1.Location = new System.Drawing.Point(190, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1543, 586);
            this.dataGridView1.TabIndex = 5;
            // 
            // idSocio
            // 
            this.idSocio.HeaderText = "idSocio";
            this.idSocio.Name = "idSocio";
            // 
            // nombre
            // 
            this.nombre.HeaderText = "nombre";
            this.nombre.Name = "nombre";
            // 
            // apellido
            // 
            this.apellido.HeaderText = "apellido";
            this.apellido.Name = "apellido";
            // 
            // genero
            // 
            this.genero.HeaderText = "genero";
            this.genero.Name = "genero";
            // 
            // edad
            // 
            this.edad.HeaderText = "edad";
            this.edad.Name = "edad";
            // 
            // valorCuota
            // 
            this.valorCuota.HeaderText = "valorCuota";
            this.valorCuota.Name = "valorCuota";
            // 
            // medallas
            // 
            this.medallas.HeaderText = "medallas";
            this.medallas.Name = "medallas";
            // 
            // categoria
            // 
            this.categoria.HeaderText = "categoria";
            this.categoria.Name = "categoria";
            // 
            // posicion
            // 
            this.posicion.HeaderText = "posicion";
            this.posicion.Name = "posicion";
            // 
            // partidosJugados
            // 
            this.partidosJugados.HeaderText = "partidosJugados";
            this.partidosJugados.Name = "partidosJugados";
            // 
            // tipoPileta
            // 
            this.tipoPileta.HeaderText = "tipoPileta";
            this.tipoPileta.Name = "tipoPileta";
            // 
            // estiloPreferido
            // 
            this.estiloPreferido.HeaderText = "estiloPreferido";
            this.estiloPreferido.Name = "estiloPreferido";
            // 
            // categoriaPeso
            // 
            this.categoriaPeso.HeaderText = "categoriaPeso";
            this.categoriaPeso.Name = "categoriaPeso";
            // 
            // cantidadPeleas
            // 
            this.cantidadPeleas.HeaderText = "cantidadPeleas";
            this.cantidadPeleas.Name = "cantidadPeleas";
            // 
            // fechaDeAsociacion
            // 
            this.fechaDeAsociacion.HeaderText = "fechaDeAsociacion";
            this.fechaDeAsociacion.Name = "fechaDeAsociacion";
            // 
            // listNadadoresBtn
            // 
            this.listNadadoresBtn.Location = new System.Drawing.Point(22, 12);
            this.listNadadoresBtn.Name = "listNadadoresBtn";
            this.listNadadoresBtn.Size = new System.Drawing.Size(146, 51);
            this.listNadadoresBtn.TabIndex = 6;
            this.listNadadoresBtn.Text = "Nadadores";
            this.listNadadoresBtn.UseVisualStyleBackColor = true;
            this.listNadadoresBtn.Click += new System.EventHandler(this.listNadadoresBtn_Click);
            // 
            // lstFutbolistasBtn
            // 
            this.lstFutbolistasBtn.Location = new System.Drawing.Point(22, 69);
            this.lstFutbolistasBtn.Name = "lstFutbolistasBtn";
            this.lstFutbolistasBtn.Size = new System.Drawing.Size(146, 51);
            this.lstFutbolistasBtn.TabIndex = 7;
            this.lstFutbolistasBtn.Text = "Futbolistas";
            this.lstFutbolistasBtn.UseVisualStyleBackColor = true;
            this.lstFutbolistasBtn.Click += new System.EventHandler(this.lstFutbolistasBtn_Click);
            // 
            // btnPugilistas
            // 
            this.btnPugilistas.Location = new System.Drawing.Point(23, 126);
            this.btnPugilistas.Name = "btnPugilistas";
            this.btnPugilistas.Size = new System.Drawing.Size(145, 50);
            this.btnPugilistas.TabIndex = 8;
            this.btnPugilistas.Text = "Pugilistas";
            this.btnPugilistas.UseVisualStyleBackColor = true;
            this.btnPugilistas.Click += new System.EventHandler(this.btnPugilistas_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(22, 549);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(146, 49);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmListDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 610);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPugilistas);
            this.Controls.Add(this.lstFutbolistasBtn);
            this.Controls.Add(this.listNadadoresBtn);
            this.Controls.Add(this.dataGridView1);
            this.MinimizeBox = false;
            this.Name = "FrmListDatos";
            this.Text = "Datos Socixs";
            this.Load += new System.EventHandler(this.FrmListDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSocio;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn medallas;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn posicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn partidosJugados;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPileta;
        private System.Windows.Forms.DataGridViewTextBoxColumn estiloPreferido;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaPeso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadPeleas;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDeAsociacion;
        private System.Windows.Forms.Button listNadadoresBtn;
        private System.Windows.Forms.Button lstFutbolistasBtn;
        private System.Windows.Forms.Button btnPugilistas;
        private System.Windows.Forms.Button btnSalir;
    }
}