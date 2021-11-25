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
    public partial class FrmCargarSocix : Form
    {
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

        private void btnGuardarSocix_Click(object sender, EventArgs e)
        {
            try
            {
                List<TextBox> listaTextBox = new List<TextBox>();
                listaTextBox.Add(txtApellido);
                listaTextBox.Add(txtNombre);
                listaTextBox.Add(txtDNI);
                listaTextBox.Add(txtEdad);
                bool camposLlenos = true;
                if (cmbDeportes.SelectedIndex == 1)
                {
                    listaTextBox.Add(txtPosicion);
                }

                foreach (TextBox textBox in listaTextBox)
                {
                    if (textBox.Text.Length <= 0)
                    {
                        MessageBox.Show("Complete todos los datos antes de guardar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        camposLlenos = false;
                        break;
                    }
                    
                }
                
               if (camposLlenos)
                {
                    switch (cmbDeportes.SelectedIndex)
                    {
                        case 1:
                            socix = new Futbolista();
                            socix.DNI = int.Parse(txtDNI.Text);
                            socix.Nombre = txtNombre.Text;
                            socix.Apellido = txtApellido.Text;
                            socix.Genero = generoSeleccionado;
                            socix.Edad = int.Parse(txtEdad.Text);
                            socix.TipoSocix = tipoSocixSeleccionado;
                            socix.CantidadMedallas = 0;
                            socix.Posicion = int.Parse(txtPosicion.Text);
                            socix.FechaAptaFisica = DateTime.Today.ToString();
                            socix.FechaDeAsociacion = socix.FechaAptaFisica;
                            socix.PartidosJugados = 0;

                            if (socix.Edad <= 12)
                            {
                                socix.ValorCuota = ECuota.NinixsFutbol;
                            }
                            else
                            {
                                socix.ValorCuota = ECuota.AdultxsFutbol;
                            }

                            if (socix.Edad >= 16 && socix.Edad <= 18)
                            {
                                socix.Categoria = ECategoria.Juvenil;
                            }
                            else if (socix.Edad == 14 || socix.Edad == 15)
                            {
                                socix.Categoria = ECategoria.Cadete;
                            }
                            else if (socix.Edad == 12 || socix.Edad == 13)
                            {
                                socix.Categoria = ECategoria.Infantil;
                            }
                            else if (socix.Edad == 10 || socix.Edad == 11)
                            {
                                socix.Categoria = ECategoria.Alevin;
                            }
                            else if (socix.Edad == 8 || socix.Edad == 9)
                            {
                                socix.Categoria = ECategoria.Benjamin;
                            }
                            else if (socix.Edad >= 5 && socix.Edad <= 7)
                            {
                                socix.Categoria = ECategoria.PreBenjamin;
                            }
                            else if (socix.TipoSocix == ETipoSocix.Competitivo && (socix.Edad < 5 || socix.Edad > 18))
                            {
                                throw new EdadNoAdmitidaException("La edad mínima para jugar en competitivo es de 5 años y la máxima 18.");
                            }
                            else
                            {
                                socix.Categoria = ECategoria.Amateur;
                            }
                            //socix = new Futbolista(int.Parse(txtDNI.Text), txtNombre.Text, txtApellido.Text, generoSeleccionado, int.Parse(txtEdad.Text), cuota, tipoSocixSeleccionado, 0, 0, int.Parse(txtPosicion.Text), DateTime.Today.ToString(), DateTime.Today.ToString());
                            break;

                        case 2:

                            socix = new Pugilista();
                            socix.DNI = int.Parse(txtDNI.Text);
                            socix.Nombre = txtNombre.Text;
                            socix.Apellido = txtApellido.Text;
                            socix.Genero = generoSeleccionado;
                            socix.Edad = int.Parse(txtEdad.Text);
                            socix.TipoSocix = tipoSocixSeleccionado;
                            socix.CantidadMedallas = 0;
                            socix.FechaAptaFisica = DateTime.Today.ToString();
                            socix.FechaDeAsociacion = socix.FechaAptaFisica;

                            if (socix.Edad <= 12)
                            {
                                socix.ValorCuota = ECuota.NinixsBoxeo;
                            }
                            else
                            {
                                socix.ValorCuota = ECuota.AdultxsBoxeo;
                            }

                            socix.CategoriaPeso = pesoSeleccionado;
                            socix.CantidadPeleas = 0;


                            //socix = new Pugilista(int.Parse(txtDNI.Text), txtNombre.Text, txtApellido.Text, generoSeleccionado, int.Parse(txtEdad.Text), cuota, 0, pesoSeleccionado, tipoSocixSeleccionado, 0, DateTime.Today.ToString(), DateTime.Today.ToString());
                            break;

                        default:
                            socix = new Nadador();
                            socix.DNI = int.Parse(txtDNI.Text);
                            socix.Nombre = txtNombre.Text;
                            socix.Apellido = txtApellido.Text;
                            socix.Genero = generoSeleccionado;
                            socix.Edad = int.Parse(txtEdad.Text);
                            socix.TipoSocix = tipoSocixSeleccionado;
                            socix.CantidadMedallas = 0;
                            socix.FechaAptaFisica = DateTime.Today.ToString();
                            socix.FechaDeAsociacion = socix.FechaAptaFisica;
                            socix.TipoPileta = piletaSeleccionada;
                            socix.EstiloPreferido = estiloNadoSeleccionado;

                            if (socix.Edad <= 12)
                            {
                                socix.ValorCuota = ECuota.NinixsNatacion;
                            }
                            else
                            {
                                socix.ValorCuota = ECuota.AdultxsNatacion;
                            }
                            // socix = new Nadador(int.Parse(txtDNI.Text), txtNombre.Text, txtApellido.Text, generoSeleccionado, int.Parse(txtEdad.Text), cuota, tipoSocixSeleccionado, 0, piletaSeleccionada, estiloNadoSeleccionado, DateTime.Today.ToString(), DateTime.Today.ToString());
                            break;

                    }

                    if ((MessageBox.Show($"¿Desea guardar el socio ingresado? \n \n {socix}", "Nuevx Socix", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        new GestorBaseDeDatos().Guardar(socix);
                        listaSocix.Add(socix);
                    }
                }
               
                
                       

            }
            catch (MenorQueCeroException ex)
            {
                MessageBox.Show($"{ex.Message}", "Edad no admitida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EdadNoAdmitidaException ex)
            {
                MessageBox.Show($"{ex.Message}", "Edad no admitida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NombreApellidoInvalidoException ex)
            {
                MessageBox.Show($"{ex.Message}","Nombre o Apellido inválido",MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            catch (PosicionException ex)
            {
                MessageBox.Show($"{ex.Message}", "Posición Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DniInvalidoException ex)
            {
                MessageBox.Show($"{ex.Message}", "DNI Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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
