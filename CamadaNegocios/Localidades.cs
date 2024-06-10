using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CamadaNegocios
{
    public class Localidades
    {
        #region Propriedades

        private string localidade;

        public string Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

        #endregion

        #region Metodos

        public static List<Localidades> GetLocalidades()
        {
            DataTable dataTable = CamadaDados.Aeroporto.ListarVoos();

            var uniqueLocalChegada = dataTable.AsEnumerable()
                                              .Select(row => row.Field<string>("LocalChegada"))
                                              .Distinct()
                                              .ToList();


            List<Localidades> localidadesList = uniqueLocalChegada.Select(local => new Localidades { Localidade = local }).ToList();

            return localidadesList;
        }

        #endregion
    }
}
