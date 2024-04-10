using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocios
{
    public class TotalAeroporto
    {
        public TotalAeroporto(string descricao, int lotacao) {
            this.descricao = descricao;
            this.lotacao = lotacao;
        }

        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private int lotacao;

        public int Lotacao
        {
            get { return lotacao; }
            set { lotacao = value; }
        }
    }
}
