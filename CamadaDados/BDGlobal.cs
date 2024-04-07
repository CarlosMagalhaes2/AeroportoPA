using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CamadaDados
{
    class BDGlobal
    {

        internal static SqlConnection OpenDatabase()
        {
            SqlConnection sqlConnection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=master;Data Source=DESKTOP-3I392D0\\SQLEXPRESS");
            sqlConnection.Open();

            return sqlConnection;
        }



    }
}
