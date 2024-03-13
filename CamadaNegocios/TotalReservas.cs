using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocios
{
    public class TotalReservas
    {
        public TotalReservas(string entidade, string valor) {
            this.entidade = entidade;
            this.valor = valor;
        }

        private string entidade;

        public string Entidade
        {
            get { return entidade; }
            set { entidade = value; }
        }

        private string valor;

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }
    }
}
