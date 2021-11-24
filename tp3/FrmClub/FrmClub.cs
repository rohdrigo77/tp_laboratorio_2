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
    public partial class FrmClub : Form
    {        
        private FrmCargarSocix cargarSocix;
        private FrmModificarSocix modificarSocix;
        private FrmListDatos mostrarDatos;
        private FrmInformes informes;
        private Club miClub;
        private GestorDeArchivos<Socix> gda;
        private List<Socix> listaSocixs;

        public FrmClub()
        {
            InitializeComponent();
            miClub = new Club("Club del Peluca");
            

        }

        public Club MiClub
        {
            get
            {
                return this.miClub;
            }
        }

        private void cargarSocixBtn_Click(object sender, EventArgs e)
        {
            
            this.cargarSocix = new FrmCargarSocix();
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
            this.gda = new GestorDeArchivos<Socix>();
            AgregarSocixAClub agregarSocix = AgregarSocix;

            try
            {
                if (gda.ExisteArchivo($"{this.miClub.RazonSocial}.json"))
                {
                    (new GestorDeArchivos<List<Socix>>()).Leer($"{this.miClub.RazonSocial}.json", out this.listaSocixs);
                    
           
                }
            }
            catch (Exception)
            {
                throw new ErrorArchivosException("Archivo no encontrado o inválido.");
            }

           

        }

        private void AgregarSocix(Socix socio)
        {
            try
            {
                this.miClub += socio;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
