using Entidades;


namespace Calculadora
{
    public partial class FrmCalculadora : Form
    {
        private Operacion calculadora;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion resultado;
        private Numeracion.ESistema sistema;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Desea cerrar la calculadora?", "cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BtnCerrar(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnLimpiar(object sender, EventArgs e)
        {
            txtPrimerOperador.Text = string.Empty;
            txtSegundoOperador.Text = string.Empty;
            lblResultado.Text = string.Empty;
            this.resultado = null;
        }

        private void BtnOperar(object sender, EventArgs e)
        {
            primerOperando = new Numeracion(txtPrimerOperador.Text, this.sistema);
            segundoOperando = new Numeracion(txtSegundoOperador.Text, this.sistema);
            calculadora = new Operacion(primerOperando, segundoOperando);

            char operador = Convert.ToChar(cmbOperacion.SelectedItem.ToString()); //Estoy parseando a char            
            this.resultado = calculadora.Operar(operador);
            setResultado(resultado);

            //Lineas para probar
            //MessageBox.Show("Número obtenido: " + n1.GetValor(), "Número Obtenido");
            //MessageBox.Show("sistema obtenido: " + n1.GetESistema(), "sistema Obtenido");
            //MessageBox.Show("Número obtenido: " + n2.GetValor(), "Número Obtenido");
            //MessageBox.Show("sistema obtenido: " + n2.GetESistema(), "sistema Obtenido");
            //MessageBox.Show("resultado obtenido: " + resultado.GetValor(), "resultado Obtenido");
        }
        private void setResultado(Numeracion resultado)
        {
            if (rdbBinario.Checked)
            {
                this.sistema = Entidades.Numeracion.ESistema.Binario;
                double resultadoDouble = resultado.GetValor();
                Numeracion binario = new Numeracion(resultadoDouble, this.sistema);
                string resultadoConvertido = binario.ConvertirA(this.sistema);
                lblResultado.Text = resultadoConvertido;
            }
            else if (rdbDecimal.Checked)
            {
                this.sistema = Entidades.Numeracion.ESistema.Decimal;
                lblResultado.Text = resultado.GetValor().ToString();
            }

        }





        private void rdbBinario_checkedChanged(object sender, EventArgs e)
        {

        }

        private void rdbDecimal_checkedChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<char> chars = new List<char> { ' ', '+', '-', '*', '/' };

            foreach (char c in chars)
            {
                cmbOperacion.Items.Add(c);
            }
            rdbDecimal.Checked = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
    }
}