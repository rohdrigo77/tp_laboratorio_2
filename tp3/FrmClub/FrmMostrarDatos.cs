using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;


namespace FrmClub
{
    public partial class FrmListDatos : Form
    {
        private string consulta;
        private GestorBaseDeDatos gestor;
        public FrmListDatos(string consulta)
        {
            InitializeComponent();
            this.consulta = consulta;
        }

        private void FrmListDatos_Load(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos();
            gestor.SqlComando = this.consulta;

            this.dataGridView1.DataSource = gestor.LeerDesdeBD();
        }

        private void listNadadoresBtn_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos();
            this.consulta = "Select * from Socixs where tipoPileta != NULL";
            gestor.SqlComando = this.consulta;

            this.dataGridView1.Columns[7].Visible = false;
            this.dataGridView1.Columns[8].Visible = false;
            this.dataGridView1.Columns[9].Visible = false;
            this.dataGridView1.Columns[10].Visible = true;
            this.dataGridView1.Columns[11].Visible = true;
            this.dataGridView1.Columns[12].Visible = false;
            this.dataGridView1.Columns[13].Visible = false;
            this.dataGridView1.DataSource = gestor.LeerDesdeBD();
        }

        private void lstFutbolistasBtn_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos();
            this.consulta = "Select * from Socixs where posicion != NULL";
            gestor.SqlComando = this.consulta;

            this.dataGridView1.Columns[7].Visible = true;
            this.dataGridView1.Columns[8].Visible = true;
            this.dataGridView1.Columns[9].Visible = true;
            this.dataGridView1.Columns[10].Visible = false;
            this.dataGridView1.Columns[11].Visible = false;
            this.dataGridView1.Columns[12].Visible = false;
            this.dataGridView1.Columns[13].Visible = false;
            this.dataGridView1.DataSource = gestor.LeerDesdeBD();
        }

        private void btnPugilistas_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos();
            this.consulta = "Select * from Socixs where categoriaPeso != NULL";
            gestor.SqlComando = this.consulta;

            this.dataGridView1.Columns[7].Visible = false;
            this.dataGridView1.Columns[8].Visible = false;
            this.dataGridView1.Columns[9].Visible = false;
            this.dataGridView1.Columns[10].Visible = false;
            this.dataGridView1.Columns[11].Visible = false;
            this.dataGridView1.Columns[12].Visible = true;
            this.dataGridView1.Columns[13].Visible = true;
            this.dataGridView1.DataSource = gestor.LeerDesdeBD();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
