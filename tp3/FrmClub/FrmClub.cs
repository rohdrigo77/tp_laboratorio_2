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
using Excepciones;

namespace FrmClub
{
    public delegate string ObtenerClub();
    public partial class FrmClub : Form
    {        
        private FrmCargarSocix cargarSocix;
        private FrmModificarSocix modificarSocix;
        private FrmListDatos mostrarDatos;
        private FrmInformes informes;
        private Club miClub;
        private GestorDeArchivos <List<Socix>> gda;
        private List<Socix> listaSocixs;

        public FrmClub()
        {
            InitializeComponent();
            miClub = new Club("Club del Peluca");
            listaSocixs = new List<Socix>();
        }

        public Club MiClub
        {
            get
            {
                return this.miClub;
            }
        }

        public List<Socix> ListaSocixs
        {
            get
            {
                return this.listaSocixs;
            }
        }

        private void cargarSocixBtn_Click(object sender, EventArgs e)
        {
            
            this.cargarSocix = new FrmCargarSocix(this.listaSocixs);
            cargarSocix.ShowDialog();
        }  

        private void listSocixsBtn_Click(object sender, EventArgs e)
        {
            this.mostrarDatos = new FrmListDatos("Select * from Socixs");
            mostrarDatos.ShowDialog();
        }

        private void informesBtn_Click(object sender, EventArgs e)
        {
            this.informes = new FrmInformes(this.miClub.ListaSocixs);
            informes.ShowDialog();
        }

        private void modificarSocixBtn_Click(object sender, EventArgs e)
        {
            this.modificarSocix = new FrmModificarSocix();

            modificarSocix.ShowDialog();
        }

        private void FrmClub_Load(object sender, EventArgs e)
        {
            this.Text = miClub.RazonSocial;
            this.gda = new GestorDeArchivos <List<Socix>>();
            

            try
            {
               if(gda.ExisteArchivo($"{miClub.RazonSocial}.json"))
               {
                    gda.Leer($"{miClub.RazonSocial}.json", out listaSocixs);
               }
               else
                {

                }
            }
            catch (ErrorArchivosException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error al intentar abrir el archivo", MessageBoxButtons.OK);
            }
        }

        private void FrmClub_FormClosing(object sender, FormClosingEventArgs e)
        {
            new GestorDeArchivos<List<Socix>>().Guardar($"{this.miClub.RazonSocial}.json", listaSocixs);
        }
    }
}
