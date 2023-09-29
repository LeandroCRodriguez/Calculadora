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
            primerOperando = new Numeracion(txtPrimerOperador.Text, Numeracion.ESistema.Decimal);
            segundoOperando = new Numeracion(txtSegundoOperador.Text, Numeracion.ESistema.Decimal);
            calculadora = new Operacion(primerOperando, segundoOperando);

            char operador = Convert.ToChar(cmbOperacion.SelectedItem); //Estoy parseando a char            
            this.resultado = calculadora.Operar(operador);
            setResultado();

        }
        private void setResultado()
        {
            if (resultado is not null)
            {
                //this.sistema = Entidades.Numeracion.ESistema.Binario;                
                string resultadoConvertido = resultado.ConvertirA(this.sistema);
                lblResultado.Text = resultadoConvertido;
            }

        }


        private void rdbBinario_checkedChanged(object sender, EventArgs e)
        {
            if (rdbBinario.Checked)
            {
                this.sistema = Entidades.Numeracion.ESistema.Binario;
                this.setResultado();
            }
        }

        private void rdbDecimal_checkedChanged(object sender, EventArgs e)
        {
            if (rdbDecimal.Checked)
            {
                this.sistema = Entidades.Numeracion.ESistema.Decimal;
                this.setResultado();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<char> chars = new List<char> { '+', '-', '*', '/' };

            foreach (char c in chars)
            {
                cmbOperacion.Items.Add(c);
            }
            rdbDecimal.Checked = true;
        }



        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
    }
}