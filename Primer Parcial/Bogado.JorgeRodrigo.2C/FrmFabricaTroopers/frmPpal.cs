using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmFabricaTroopers
{
    public partial class frmPpal : Form
    {
        public frmPpal()
        {
            InitializeComponent();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }
        private void frmPpal_Load_1(object sender, EventArgs e)
        {
            this.cmbTipo.DataSource = Enum.GetValues(typeof(Trooper.ETrooper));

            
        }
    }
}
