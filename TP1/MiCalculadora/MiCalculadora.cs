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
/// <summary>
/// 
/// </summary>
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            CargarOperadoresEnComboBox();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
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
        /// 
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
                }
                else
                {
                    this.lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, (cmbOperador.SelectedValue).ToString()).ToString();
                    CargarResultado();
                }
            }
     
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
           
        }
        /// <summary>
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
