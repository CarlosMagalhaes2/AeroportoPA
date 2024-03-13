using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace CamadaNegocios
{
    public class Reservas
    {

        #region Propriedades

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string entidade;

        public string Entidade
        {
            get { return entidade; }
            set { entidade = value; }
        }

        private string grupo;
        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        private DateTime timestamp;
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
       
        #endregion

        #region Metodos

        public static Reservas ObterReservas(string id)
        {
            Reservas reservas = null;

            string entidade = string.Empty;
            DateTime timestamp = DateTime.Today;
            string grupo = string.Empty;
           
            
        

            bool ok = CamadaDados.Reservas.Obter(id, ref entidade, ref timestamp, ref grupo);
            if (ok)
            {
                reservas = new Reservas();
                reservas.Id = id;
                reservas.Entidade = entidade;
                reservas.Timestamp = timestamp;
                reservas.Grupo = grupo;
                
                
             
            }

            return reservas;
        }

        public class ListaReservas : List<Reservas>
        {
            public ListaReservas(DataTable dataTable)
            {
                if (dataTable != null)
                {
                    foreach (DataRow dataRow in dataTable.AsEnumerable())
                    {
                        Reservas reservas = new Reservas();

                        reservas.Id = dataRow.Field<string>("id");
                        reservas.Entidade = dataRow.Field<string>("entidade");
                        reservas.Timestamp = dataRow.Field<DateTime>("timestamp");
                        reservas.Grupo = dataRow.Field<string>("grupo");
                       


                        this.Add(reservas);
                    }
                }
            }




        }
        public static ListaReservas ObterListaReservas()
        {
            DataTable dataTable = CamadaDados.Reservas.ObterLista();

            ListaReservas entradas = new ListaReservas(dataTable);

            return entradas;
        }

        #endregion

    }

    
}
