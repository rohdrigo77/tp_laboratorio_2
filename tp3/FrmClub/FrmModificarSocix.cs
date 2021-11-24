using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmClub
{
    
    public partial class FrmModificarSocix : Form
    {
        List<TextBox> cajasDeTexto = new List<TextBox>();
        List<ComboBox> comboCajas = new List<ComboBox>();
        List<CheckBox> cajasCheck = new List<CheckBox>();

        public FrmModificarSocix()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            StringBuilder camposModificados = new StringBuilder();
            StringBuilder stringValue = new StringBuilder();
            string txtValue = "";

            camposModificados.AppendLine("Campos modificados:");
            camposModificados.AppendLine(" ");

            

            for  (int i=0;i<cajasCheck.Count;i++)
            {
                if(cajasCheck[i].CheckState == CheckState.Checked)
                {

                    stringValue.AppendLine($"{cajasCheck[i].Text} = ");

                    foreach (TextBox cajita in cajasDeTexto)
                    {
                        bool contains = cajita.Name.IndexOf($"txt{char.ToUpper(cajasCheck[i].Text[0])}", StringComparison.OrdinalIgnoreCase) >= 0;
                        
                        if (contains)
                        {
                            txtValue = cajita.Text;
                            stringValue.Append($"{txtValue}");
                            break;
                        }
                    }

                    foreach (ComboBox cajita in comboCajas)
                    {
                        bool contains = cajita.Name.IndexOf($"cmb{char.ToUpper(cajasCheck[i].Text[0])}", StringComparison.OrdinalIgnoreCase) >= 0;

                        if (contains)
                        {
                            txtValue = cajita.Text;
                            break;
                        }
                    }                   

                    camposModificados.AppendLine($"{cajasCheck[i].Text}:{txtValue}");

                    if (!(i==cajasCheck.Count-1))
                    {
                        camposModificados.Append(",");
                    }

                }
            }

            camposModificados.AppendLine("");
            camposModificados.AppendLine("¿Guardar Cambios?");

            if(MessageBox.Show($"{camposModificados}","Socix Modificado",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                (new GestorBaseDeDatos($"UPDATE Socixs SET {camposModificados} WHERE dni = {txtDNI.Text}")).EjecutarNonQuery();
                    
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chkCantidadPeleas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCantidadPeleas.CheckState == CheckState.Checked)
            {
                txtCantidadPeleas.Enabled = true;
            }
            else
            {
                txtCantidadPeleas.Enabled = false;
            }
        }

        private void chkNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNombre.CheckState == CheckState.Checked)
            {
                txtNombre.Enabled = true;
            }
            else
            {
                txtNombre.Enabled = false;
            }
        }

        private void chkApellido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApellido.CheckState == CheckState.Checked)
            {
                txtApellido.Enabled = true;
            }
            else
            {
                txtApellido.Enabled = false;
            }
        }

        private void chkGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenero.CheckState == CheckState.Checked)
            {
                cmbGenero.Enabled = true;
            }
            else
            {
                cmbGenero.Enabled = false;
            }
        }

        private void chkEdad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEdad.CheckState == CheckState.Checked)
            {
                txtEdad.Enabled = true;
            }
            else
            {
                txtEdad.Enabled = false;
            }
        }

        private void chkValorCuota_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValorCuota.CheckState == CheckState.Checked)
            {
                cmbValorCuota.Enabled = true;
            }
            else
            {
                cmbValorCuota.Enabled = false;
            }
        }

        private void chkMedallas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMedallas.CheckState == CheckState.Checked)
            {
                txtMedallas.Enabled = true;
            }
            else
            {
                txtMedallas.Enabled = false;
            }
        }

        private void chkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoria.CheckState == CheckState.Checked)
            {
                cmbCategoria.Enabled = true;
            }
            else
            {
                cmbCategoria.Enabled = false;
            }
        }

        private void chkPosicion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPosicion.CheckState == CheckState.Checked)
            {
                txtPosicion.Enabled = true;
            }
            else
            {
                txtPosicion.Enabled = false;
            }
        }

        private void chkPartidosJugados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPartidosJugados.CheckState == CheckState.Checked)
            {
                txtPartidosJugados.Enabled = true;
            }
            else
            {
                txtPartidosJugados.Enabled = false;
            }
        }

        private void chkTipoPileta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTipoPileta.CheckState == CheckState.Checked)
            {
                cmbTipoPileta.Enabled = true;
            }
            else
            {
                cmbTipoPileta.Enabled = false;
            }
        }

        private void chkEstilo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstilo.CheckState == CheckState.Checked)
            {
                cmbEstiloPreferido.Enabled = true;
            }
            else
            {
                cmbEstiloPreferido.Enabled = false;
            }
        }

        private void chkCategoriaPeso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoriaPeso.CheckState == CheckState.Checked)
            {
                cmbCategoriaPeso.Enabled = true;
            }
            else
            {
                cmbCategoriaPeso.Enabled = false;
            }
        }

        private void FrmModificarSocix_Load(object sender, EventArgs e)
        {

            cajasDeTexto.Add(txtNombre);
            cajasDeTexto.Add(txtApellido);          
            cajasDeTexto.Add(txtEdad); 
            cajasDeTexto.Add(txtMedallas);     
            cajasDeTexto.Add(txtPosicion);
            cajasDeTexto.Add(txtPartidosJugados);
            cajasDeTexto.Add(txtCantidadPeleas);

            comboCajas.Add(cmbGenero);
            comboCajas.Add(cmbCategoria);
            comboCajas.Add(cmbValorCuota);
            comboCajas.Add(cmbTipoSocix);
            comboCajas.Add(cmbTipoPileta);
            comboCajas.Add(cmbEstiloPreferido);
            comboCajas.Add(cmbCategoriaPeso);

            cajasCheck.Add(chkNombre);
            cajasCheck.Add(chkApellido);
            cajasCheck.Add(chkEdad);
            cajasCheck.Add(chkMedallas);
            cajasCheck.Add(chkPosicion);
            cajasCheck.Add(chkPartidosJugados);
            cajasCheck.Add(chkCantidadPeleas);
            cajasCheck.Add(chkGenero);
            cajasCheck.Add(chkCategoria);
            cajasCheck.Add(chkValorCuota);
            cajasCheck.Add(chkTipoSocix);
            cajasCheck.Add(chkTipoPileta);
            cajasCheck.Add(chkEstilo);
            cajasCheck.Add(chkCategoriaPeso);

            foreach (TextBox cajita in cajasDeTexto)
            {
                cajita.Enabled = false;
            }

            foreach (ComboBox cajita in comboCajas)
            {
                cajita.Enabled = false;
            }

            cmbGenero.DataSource = Enum.GetValues(typeof(EGenero));
            cmbValorCuota.DataSource = Enum.GetValues(typeof(ECuota));
            cmbCategoria.DataSource = Enum.GetValues(typeof(EGenero));
            cmbTipoSocix.DataSource = Enum.GetValues(typeof(EGenero));
            cmbTipoPileta.DataSource = Enum.GetValues(typeof(EGenero));
            cmbEstiloPreferido.DataSource = Enum.GetValues(typeof(EGenero));
            cmbCategoriaPeso.DataSource = Enum.GetValues(typeof(EGenero));

            
            Task.Run(() => new FrmListDatos("Select * from Socixs").ShowDialog());

        }

        private void chkTipoSocix_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTipoSocix.CheckState == CheckState.Checked)
            {
                cmbTipoSocix.Enabled = true;
            }
            else
            {
                cmbTipoSocix.Enabled = false;
            }
        }

    }
}
