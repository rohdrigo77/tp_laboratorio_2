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
    public delegate void ActualizarDataGrid();
    public delegate void ActualizarDataGridConDni(int dni);

    public partial class FrmListDatos : Form
    {
        private string consulta;
        private GestorBaseDeDatos gestor;
        public event ActualizarDataGrid actualizarDG;
        public event ActualizarDataGridConDni actualizarDGDni;

        public FrmListDatos(string consulta)
        {
            InitializeComponent();
            this.consulta = consulta;
        }

        public DataGridView DataGridView
        {
            get
            {
                return this.dataGridView1;
            }
        }

        public GestorBaseDeDatos Gestor
        {
            set
            {
                this.gestor = value;
            }
            get
            {
                return this.gestor;
            }
        }


        private void FrmListDatos_Load(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos(this.consulta);
            
            try
            {
                this.dataGridView1.DataSource = gestor.LeerDesdeBD();
         

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer desde Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listNadadoresBtn_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos("Select * from Socixs where valorCuota LIKE '%Natacion'");
        
            try
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = gestor.LeerDesdeBD();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer desde Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstFutbolistasBtn_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos("Select * from Socixs where valorCuota LIKE '%Futbol'");
        
            try
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = gestor.LeerDesdeBD();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer desde Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPugilistas_Click(object sender, EventArgs e)
        {
            gestor = new GestorBaseDeDatos("Select * from Socixs where valorCuota LIKE '%Boxeo'");

            try
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = gestor.LeerDesdeBD();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer desde Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }   

        public void ActualizarDatagrid()
        {
            if(this.actualizarDG != null)
            {
                this.actualizarDG.Invoke();
            }
           
        }

        public void ActualizarDatagridDni(int dni)
        {
            if (this.actualizarDGDni != null)
            {
                this.actualizarDGDni.Invoke(dni);
            }
        }

    }
}
