using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using CamadaNegocio;

namespace CamadaNegocios
{
    public class Aeroporto
    {

        #region Propriedades

        private int vooId;

        public int VooId
        {
            get { return vooId; }
            set { vooId = value; }
        }

        private string localChegada;

        public string LocalChegada
        {
            get { return localChegada; }
            set { localChegada = value; }
        }
        
        private string localPartida;

        public string LocalPartida
        {
            get { return localPartida; }
            set { localPartida = value; }
        }

        private DateTime dataPartida;
        public DateTime DataPartida
        {
            get { return dataPartida; }
            set { dataPartida = value; }
        }

         private DateTime dataChegada;
        public DateTime DataChegada
        {
            get { return dataChegada; }
            set { dataChegada = value; }
        }

        private int lotacao;
        public int Lotacao
        {
            get { return lotacao; }
            set { lotacao = value; }
        }
        
        private int capacidade;
        public int Capacidade
        {
            get { return capacidade; }
            set { capacidade = value; }
        }

        private int companhiaId;
        public int CompanhiaId
        {
            get { return companhiaId; }
            set { companhiaId = value; }
        }

        private TipoEstado tipoEstado;
        public TipoEstado TipoEstado
        {
            get { return tipoEstado; }
            set { tipoEstado = value; }
        }

        private string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        #endregion

        #region Metodos

        public static Aeroporto ObterAeroporto(int vooId)
        {
            Aeroporto aeroporto = null;

            string localPartida = string.Empty;
            string localChegada = string.Empty;
            DateTime dataPartida = DateTime.Today;
            DateTime dataChegada = DateTime.Today;
            int lotacao = 0;
            int capacidade = 0;
            int tipoEstado = 0;
            int companhiaId = 0;
            string descricao = string.Empty;

            bool ok = CamadaDados.Aeroporto.ObterVoo(vooId, ref localPartida, ref localChegada, ref dataPartida, ref dataChegada,
                ref lotacao, ref capacidade, ref tipoEstado, ref companhiaId, ref descricao);
            if (ok)
            {
                aeroporto = new Aeroporto();
                aeroporto.VooId = vooId;
                aeroporto.LocalPartida = localPartida;
                aeroporto.LocalChegada = localChegada;
                aeroporto.DataPartida = dataPartida;
                aeroporto.DataChegada = dataChegada;
                aeroporto.Lotacao = lotacao;
                aeroporto.Capacidade = capacidade;
                aeroporto.TipoEstado = (TipoEstado)tipoEstado;
                aeroporto.CompanhiaId = companhiaId;
                aeroporto.Descricao = descricao;
            }

            return aeroporto;
        }

        public class ListaAeroporto : List<Aeroporto>
        {
            public ListaAeroporto(DataTable dataTable)
            {
                if (dataTable != null)
                {
                    foreach (DataRow dataRow in dataTable.AsEnumerable())
                    {
                        Aeroporto aeroporto = new Aeroporto();

                        aeroporto.VooId = dataRow.Field<int>("VooId");
                        aeroporto.LocalPartida = dataRow.Field<string>("LocalPartida");
                        aeroporto.LocalChegada = dataRow.Field<string>("LocalChegada");
                        aeroporto.DataPartida = dataRow.Field<DateTime>("DataPartida");
                        aeroporto.DataChegada = dataRow.Field<DateTime>("DataChegada");
                        aeroporto.Lotacao = dataRow.Field<int>("Lotacao");
                        aeroporto.Capacidade = dataRow.Field<int>("Capacidade");
                        aeroporto.TipoEstado = (TipoEstado)dataRow.Field<int>("Estado");
                        aeroporto.CompanhiaId = dataRow.Field<int>("CompanhiaId");
                        aeroporto.Descricao = dataRow.Field<string>("Descricao");

                        this.Add(aeroporto);
                    }
                }
            }




        }
        public static ListaAeroporto ObterListaAeroporto()
        {
            DataTable dataTable = CamadaDados.Aeroporto.ListarVoos();

            ListaAeroporto entradas = new ListaAeroporto(dataTable);

            return entradas;
        }

        #endregion

    }


}
