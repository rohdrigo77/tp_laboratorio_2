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

namespace FrmClub
{
    public partial class FrmCargarSocix : Form
    {
        public event Printear PrintearSocix;
        EGenero generoSeleccionado;
        EPileta piletaSeleccionada;
        ETipoSocix tipoSocixSeleccionado;
        EEstilos estiloNadoSeleccionado;
        EPeso pesoSeleccionado;
        Socix socix;
        List<Socix> listaSocix;

        public FrmCargarSocix(List<Socix> lista)
        {
            InitializeComponent();
            listaSocix = lista;
        
        }

        private void lblGuardarSocix_Click(object sender, EventArgs e)
        {
            try
            {
                ECuota cuota;
               
                switch (cmbDeportes.SelectedIndex)
                {
                    case 1:
                        
                        if (int.Parse(txtEdad.Text) <= 12)
                        {
                            cuota = ECuota.NinixsFutbol;
                        }
                        else
                        {
                            cuota = ECuota.AdultxsFutbol;
                        }
                        socix = new Futbolista(int.Parse(txtDNI.Text), txtNombre.Text, txtApellido.Text, generoSeleccionado, int.Parse(txtEdad.Text), cuota, tipoSocixSeleccionado, 0, 0, int.Parse(txtPosicion.Text), DateTime.Today.ToString(), DateTime.Today.ToString());
                        break;
                       
                    case 2:
                        if (int.Parse(txtEdad.Text) <= 12)
                        {
                            cuota = ECuota.NinixsBoxeo;
                        }
                        else
                        {
                            cuota = ECuota.AdultxsBoxeo;
                        }
                        socix = new Pugilista(int.Parse(txtDNI.Text), txtNombre.Text, txtApellido.Text, generoSeleccionado, int.Parse(txtEdad.Text), cuota, 0, pesoSeleccionado, tipoSocixSeleccionado, 0, DateTime.Today.ToString(), DateTime.Today.ToString());
                        break;

                    default:
                        if (int.Parse(txtEdad.Text) <= 12)
                        {
                            cuota = ECuota.NinixsNatacion;
                        }
                        else
                        {
                            cuota = ECuota.AdultxsNatacion;
                        }
                        socix = new Nadador(int.Parse(txtDNI.Text), txtNombre.Text, txtApellido.Text, generoSeleccionado, int.Parse(txtEdad.Text), cuota, tipoSocixSeleccionado, 0, piletaSeleccionada, estiloNadoSeleccionado, DateTime.Today.ToString(), DateTime.Today.ToString());
                        break;
                        
                }

                if ((MessageBox.Show($"¿Desea guardar el socio ingresado? \n \n {socix.ToString()}", "Nuevx Socix", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    new GestorBaseDeDatos().Guardar(socix);
                    listaSocix.Add(socix);              
                }
                else
                {
                    if (MessageBox.Show("Desea Agregar otrx socix?", "Nuevx Socix", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        this.Dispose();
                    }
                }
         

            }
            catch (Exception)
            {
                throw;
            }  
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbDeportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDni.Enabled = true;
            txtDNI.Enabled = true;
           switch (cmbDeportes.SelectedIndex)
            {
                case 1:
                    
                    lblTipoPileta.Enabled = false;
                    cmbPileta.Enabled = false;
                    lblEstiloNado.Enabled = false;
                    cmbEstiloNado.Enabled = false;
                    lblCategoriaPeso.Enabled = false;
                    cmbPeso.Enabled = false;
                    lblPosicion.Enabled = true;
                    txtPosicion.Enabled = true;
                    break;
                case 2:
                    lblPosicion.Enabled = false;
                    txtPosicion.Enabled = false;
                    lblTipoPileta.Enabled = false;
                    cmbPileta.Enabled = false;
                    lblEstiloNado.Enabled = false;
                    cmbEstiloNado.Enabled = false;
                    lblPosicion.Enabled = false;
                    txtPosicion.Enabled = false;
                    lblCategoriaPeso.Enabled = true;
                    cmbPeso.Enabled = true;
                    break;
                default :
                    lblTipoPileta.Enabled = true;
                    cmbPileta.Enabled = true;
                    lblEstiloNado.Enabled = true;
                    cmbEstiloNado.Enabled = true;
                    lblCategoriaPeso.Enabled = false;
                    cmbPeso.Enabled = false;
                    lblPosicion.Enabled = false;
                    txtPosicion.Enabled = false;
                    break;    
            }
        }

        private void FrmCargarSocix_Load(object sender, EventArgs e)
        {
            this.cmbGenero.DataSource = Enum.GetValues(typeof(EGenero));
            this.cmbDeportes.DataSource = Enum.GetValues(typeof(EDeporteSocix));
            this.cmbPileta.DataSource = Enum.GetValues(typeof(EPileta));
            this.cmbEstiloNado.DataSource = Enum.GetValues(typeof(EEstilos));
            this.cmbPeso.DataSource = Enum.GetValues(typeof(EPeso));
            this.cmbTipoSocix.DataSource = Enum.GetValues(typeof(ETipoSocix));
        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbGenero.SelectedIndex)
            {
                case 1:
                    this.generoSeleccionado = EGenero.Masculino;
                    break;
                case 2:
                    this.generoSeleccionado = EGenero.Femenino;
                    break;
                default:
                    this.generoSeleccionado = EGenero.NoBinario;
                    break;

            }
        }

        private void cmbTipoSocix_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTipoSocix.SelectedIndex)
            {
                case 1:
                    this.tipoSocixSeleccionado= ETipoSocix.Recreativo;
                    break;
                default:
                    this.tipoSocixSeleccionado = ETipoSocix.Competitivo;
                    break;

            }
        }

        private void cmbPileta_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbPileta.SelectedIndex)
            {
                case 1:
                    this.piletaSeleccionada = EPileta.Niños;
                    break;
                case 2:
                    this.piletaSeleccionada = EPileta.Semiolimpica;
                    break;
                default:
                    this.piletaSeleccionada = EPileta.Olimpica;
                    break;

            }
        }

        private void cmbEstiloNado_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEstiloNado.SelectedIndex)
            {
                case 1:
                    this.estiloNadoSeleccionado = EEstilos.Crol;
                    break;
                case 2:
                    this.estiloNadoSeleccionado = EEstilos.Espalda;
                    break;
                case 3:
                    this.estiloNadoSeleccionado = EEstilos.Pecho;
                    break;
                default:
                    this.estiloNadoSeleccionado = EEstilos.Mariposa;
                    break;
            }
        }

        private void cmbPeso_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbPeso.SelectedIndex)
            {
                case 1:
                    this.pesoSeleccionado = EPeso.Mosca;
                    break;
                case 2:
                    this.pesoSeleccionado = EPeso.Pluma;
                    break;
                case 3:
                    this.pesoSeleccionado = EPeso.Ligero;
                    break;
                case 4:
                    this.pesoSeleccionado = EPeso.Wélter;
                    break;
                case 5:
                    this.pesoSeleccionado = EPeso.Medio;
                    break;
                case 6:
                    this.pesoSeleccionado = EPeso.Semipesado;
                    break;
                case 7:
                    this.pesoSeleccionado = EPeso.Pesado;
                    break;
                default:
                    this.pesoSeleccionado = EPeso.Superpesado;
                    break;
            }
        }

        private void FrmCargarSocix_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea Agregar otrx socix?", "Nuevx Socix", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

    }
}
