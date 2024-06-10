using System.Data.SqlClient;

namespace CamadaDados
{
    class BDGlobal
    {

        internal static SqlConnection OpenDatabase()
        {
            SqlConnection sqlConnection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Voo;Data Source=DESKTOP-DNSU1J2\\SQLEXPRESS");
            sqlConnection.Open();

            return sqlConnection;
        }



    }
}
