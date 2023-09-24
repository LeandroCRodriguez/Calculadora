using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            this.primerOperando = primerOperando;
            this.segundoOperando = segundoOperando;
        }
        public void SetPrimerOperando(Numeracion primerOperando)
        {
            this.primerOperando = primerOperando;
        }

        public Numeracion GetPrimerOperando()
        {
            return this.primerOperando;            
        }

        public void SetSegundoOperando(Numeracion segundoOperando)
        {
            this.segundoOperando = segundoOperando;
        }

        public Numeracion GetSegundoOperando()
        {
            return this.segundoOperando;
        }

        public Numeracion Operar(char operador)
        {
            switch (operador)
            {

                case '+':
                    return this.primerOperando + this.segundoOperando;

                case '-':
                    return this.primerOperando - this.segundoOperando;

                case '*':
                    return this.primerOperando * this.segundoOperando;

                case '/':
                    return this.primerOperando / this.segundoOperando;

                default:
                    return this.primerOperando + this.segundoOperando;
            }
        }
    }
}
