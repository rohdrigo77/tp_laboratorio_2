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


namespace MiCalculadora
{

    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor FormCalculadora
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            CargarOperadoresEnComboBox();
        }

        /// <summary>
        /// Metodo de carga para FormCalculadora que limpia la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Metodo para cerrar el formulario al hacer clic en su boton correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo para convertir numero decimal en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(lblResultado.Text)))
            {
                string temp = this.lblResultado.Text;
                this.lblResultado.Text = new Operando().DecimalBinario(this.lblResultado.Text);
                CargarConversion(temp);
            }

        }
        /// <summary>
        /// Metodo para Realizar operaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtNumero1.Text, out double num1) && double.TryParse(txtNumero2.Text, out double num2))
            {
                
                if (String.Compare(cmbOperador.SelectedValue.ToString(), "/") == 0 && (Convert.ToDouble(txtNumero2.Text) == 0))
                {
                    MessageBox.Show("No se puede dividir por 0!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.lblResultado.Text = double.MinValue.ToString();
                }
                else
                {
                    this.lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, (cmbOperador.SelectedValue).ToString()).ToString();
                    
                }

                CargarResultado();
            }
     
           
        }
        /// <summary>
        /// Metodo para manejar el evento del boton "limpiar" al hacerle clic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
           
        }
        /// <summary>
        /// Metodo para convertir de Binario a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string temp;

            if  (!(string.IsNullOrEmpty(lblResultado.Text)))
            {
                temp = this.lblResultado.Text;
                this.lblResultado.Text = new Operando(this.lblResultado.Text).BinarioDecimal(this.lblResultado.Text);
                CargarConversion(temp);
            }      
        }
        /// <summary>
        /// Metodo para limpiar pantalla
        /// </summary>
        public void Limpiar()
        {
            this.lstOperaciones.Items.Clear();
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedItem = "+";this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.lblResultado.Text = ""; 

        }
        /// <summary>
        /// Metodo estatico que realiza una operación matemática indicada
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        static double Operar(string numero1, string numero2, string operador)
        {
           return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
        }
        /// <summary>
        /// Metodo para cargar distintos operadores en combobox
        /// </summary>
        private void CargarOperadoresEnComboBox()
        {
            List<object> operadores = new List <object>()
            {
                new {Operador=' ' },
                new {Operador='+' },
                new {Operador='/' },
                new {Operador='*' },
                new {Operador='-' },
            };

            cmbOperador.DataSource = operadores;
            cmbOperador.ValueMember = "Operador";
            cmbOperador.DisplayMember = "Operador";
            cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;


        }
        /// <summary>
        /// Metodo para cargar resultado en la lista
        /// </summary>
        public void CargarResultado()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(txtNumero1.Text);
            if (cmbOperador.Text == " ")
            {
                sb.AppendLine("+");
            }
            else
            {
                sb.AppendLine(cmbOperador.Text);
            }
            sb.AppendLine(txtNumero2.Text);
            sb.Append('=');
            sb.AppendLine(lblResultado.Text);

            lstOperaciones.Items.Add(sb);
        }
        /// <summary>
        /// Metodo para cargar conversion en la lista
        /// </summary>
        /// <param name="temp"></param>
        public void CargarConversion(string temp)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(temp);
            sb.Append('=');
            sb.AppendLine(lblResultado.Text);
            lstOperaciones.Items.Add(sb);
        }
        /// <summary>
        /// Metodo para solicitar confirmación antes de cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está segur@ que quiere cerrar la calculadora?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
    }
}
