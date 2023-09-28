using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numeracion
    {
        
        private ESistema esistema;
        private double valorNumerico; 


        public Numeracion(double valorNumerico, ESistema esistema) 
        {
            this.valorNumerico = valorNumerico;
            this.esistema = esistema;
        }

        public Numeracion(string valorNumerico, ESistema esistema) 
        {
            InicializarValores(valorNumerico, esistema);
        }

        public ESistema GetESistema()
        {
            return this.esistema;
        }

        public double GetValor()
        {
            return this.valorNumerico;
        }

        private void InicializarValores(String valorNumerico, ESistema sistema) 
        {
            this.esistema = sistema;
            double valorNumericoDouble =  double.MinValue;
            if (sistema == ESistema.Binario)
            {
                if(EsBinario(valorNumerico))
                {
                    double valorConvertido = BinarioADecimal(valorNumerico);
                    this.valorNumerico = valorConvertido;
                }                
            }
            else if(sistema == ESistema.Decimal)
            {
                if(double.TryParse(valorNumerico, out valorNumericoDouble))
                {
                    this.valorNumerico = valorNumericoDouble;
                }
                else
                {
                    this.valorNumerico = valorNumericoDouble;
                }
            }
        }
                //Hasta acá creo que viene bien

        public string ConvertirA(ESistema sistema)
        {
            switch (sistema)
            {
                case ESistema.Binario:
                        string valorConvertidoBinario = DecimalABinario(this.valorNumerico);
                        return valorConvertidoBinario;     
                case ESistema.Decimal:
                    string valorNumericoString;
                    return valorNumericoString = this.valorNumerico.ToString(); //No sé si es así o si es como el codigo comentado.
                        //string valorNumericoString = this.valorNumerico.ToString();
                        //double valorConvertidoDecimal = BinarioADecimal(valorNumericoString);
                        //return valorConvertidoDecimal.ToString();                 
                default:                    
                    return "Sistema no válido";
            }
        }

        private bool EsBinario(string valor)
        {
            foreach (char v in valor)
            {
                if (v != '0' && v != '1')
                {
                    return false; // La cadena contiene un carácter no válido
                }
            }
            return true; // La cadena es binaria
        }

        //Chat
        private string DecimalABinario(double valorDecimal)  //Me pide que llegue un strin y no un double
        {
            // Verificar si el valorDecimal es negativo
            if (valorDecimal < 0)
            {
                return "Número inválido";
            }

            int numeroEntero = (int)Math.Abs(valorDecimal); //Toma el valor abs de valorDecimal(si es - lo pasa a +) y lo convierte a int 

            // Manejamos el caso especial de 0
            if (numeroEntero == 0)
            {
                return "0";
            }

            // Inicializamos una cadena para almacenar el número binario
            string binario = "";

            while (numeroEntero > 0)
            {
                // Obtener el residuo de la división entre 2
                int residuo = numeroEntero % 2;

                // Agregar el residuo al inicio de la cadena binaria
                binario = residuo + binario;

                // Dividir el número entero por 2
                numeroEntero /= 2;
            }

            return binario;
        }


        private string DecimalABinario(int valorDecimal) //Me queda un metodo al pedo
        {
            if (valorDecimal < 0)
            {
                return "Número inválido";
            }
            // Manejamos el caso especial de 0
            if (valorDecimal == 0)
            {
                return "0";
            }

            // Inicializamos una cadena para almacenar el número binario
            string binario = "";

            while (valorDecimal > 0)
            {
                // Obtener el residuo de la división entre 2
                int residuo = valorDecimal % 2;

                // Agregar el residuo al inicio de la cadena binaria
                binario = residuo + binario;

                // Dividir el número entero por 2
                valorDecimal /= 2;
            }

            return binario;
        }


        private double BinarioADecimal(string valorBinario) //Tengo que modificarlo
        {
            if(EsBinario(valorBinario))
            {
                double resultado = 0;
                int longitud = valorBinario.Length;

                for (int i = 0; i < longitud; i++)
                {
                    int digito = int.Parse(valorBinario[i].ToString());
                    resultado = resultado * 2 + digito;
                }

                return resultado;
            }
            else
            {
                return 0;
            }
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            if (n1.esistema == n2.esistema)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            if (n1.esistema != n2.esistema)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            if (sistema == numeracion.esistema)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            if (sistema != numeracion.esistema)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static Numeracion operator +(Numeracion num1, Numeracion num2)
        {
            double resultado = num1.GetValor() + num2.GetValor();
            return new Numeracion(resultado, ESistema.Decimal); //Podría hacer un constructor que reciba solo el resultado como parametro. es mejor?
        }
        public static Numeracion operator -(Numeracion num1, Numeracion num2)
        {
            double resultado = num1.GetValor() - num2.GetValor();
            return new Numeracion(resultado, ESistema.Decimal); //Podría hacer un constructor que reciba solo el resultado como parametro. es mejor?
        }
        public static Numeracion operator *(Numeracion num1, Numeracion num2)
        {
            double resultado = num1.GetValor() * num2.GetValor();
            return new Numeracion(resultado, ESistema.Decimal); //Podría hacer un constructor que reciba solo el resultado como parametro. es mejor?
        }
        public static Numeracion operator /(Numeracion num1, Numeracion num2)
        {
            double resultado = num1.GetValor() / num2.GetValor();
            return new Numeracion(resultado, ESistema.Decimal); //Podría hacer un constructor que reciba solo el resultado como parametro. es mejor?
        }

        public enum ESistema 
        { Binario, Decimal };
    }
}
