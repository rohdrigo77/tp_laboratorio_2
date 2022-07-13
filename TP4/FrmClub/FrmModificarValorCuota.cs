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
    public partial class FrmModificarValorCuota : Form
    {

        public FrmModificarValorCuota()
        {
            InitializeComponent();
            cmbCuotas.DataSource = Enum.GetValues(typeof(ECuota));
        }

       

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtValor.Text, out float valor) && valor > 0)
            {
                switch (cmbCuotas.SelectedIndex)
                {
                    case 1:
                        Club.ValorCuotaAdultxsNatacion = valor;
                        break;
                    case 2:
                        Club.ValorCuotaNinixsNatacion = valor;
                        break;
                    case 3:
                        Club.ValorCuotaAdultxsFutbol = valor;
                        break;
                    case 4:
                        Club.ValorCuotaNinixsBoxeo = valor;
                        break;
                    case 5:
                        Club.ValorCuotaAdultxsBoxeo = valor;
                        break;
                    default:
                        Club.ValorCuotaNinixsNatacion = valor;
                        break;
                }

                if (MessageBox.Show("Cambio guardado exitosamente. ¿Desea Modificar otro Elemento?:", " Cambios guardados", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    this.Close();
                }
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
