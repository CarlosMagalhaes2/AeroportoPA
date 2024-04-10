using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CamadaDados
{
    public class Aeroporto
    {
        #region Métodos

        public static bool ObterVoo(int vooId, ref string localPartida, ref string localChegada, ref DateTime dataPartida, ref DateTime dataChegada, ref int lotacao, ref int capacidade, ref int tipoEstado, ref int companhiaId, ref string descricao)
        {
            bool ok = false;

            try
            {
                SqlConnection sqlConnection = BDGlobal.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("ObterVoo", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameter = sqlCommand.Parameters.Add("@VooId", SqlDbType.Int);
                sqlParameter.Direction = ParameterDirection.Input;
                sqlParameter.Value = vooId;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        localPartida = sqlDataReader.GetString(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        localChegada = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        dataPartida = sqlDataReader.GetDateTime(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        dataChegada = sqlDataReader.GetDateTime(4);
                    }
                    if (!sqlDataReader.IsDBNull(5))
                    {
                        lotacao = sqlDataReader.GetInt32(5);
                    }
                    if (!sqlDataReader.IsDBNull(6))
                    {
                        capacidade = sqlDataReader.GetInt32(6);
                    }
                    if (!sqlDataReader.IsDBNull(7))
                    {
                        tipoEstado = sqlDataReader.GetInt32(7);
                    }
                    if (!sqlDataReader.IsDBNull(8))
                    {
                        companhiaId = sqlDataReader.GetInt32(8);
                    }
                    if (!sqlDataReader.IsDBNull(9))
                    {
                        descricao = sqlDataReader.GetString(9);
                    }
                    ok = true;
                }

                sqlParameter = null;
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                ok = false;
            }

            return ok;
        }

        public static DataTable ListarVoos()
        {
            DataTable dataTable = null;
            try
            {
                SqlConnection sqlConnection = BDGlobal.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("ListarVoo", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return dataTable;
        }

        public static bool ObterCompanhia(int companhiaId, ref string descricao)
        {
            bool ok = false;

            try
            {
                SqlConnection sqlConnection = BDGlobal.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("ObterCompanhia", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameter = sqlCommand.Parameters.Add("@CompanhiaId", SqlDbType.Int);
                sqlParameter.Direction = ParameterDirection.Input;
                sqlParameter.Value = companhiaId;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        descricao = sqlDataReader.GetString(1);
                    }
                    ok = true;
                }

                sqlParameter = null;
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                ok = false;
            }

            return ok;
        }

        public static DataTable ListarCompanhias()
        {
            DataTable dataTable = null;
            try
            {
                SqlConnection sqlConnection = BDGlobal.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("ListarCompanhias", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                sqlCommand.Dispose();
                sqlConnection.Close();
            }


            catch (Exception ex)
            {

            }
            return dataTable;
        }

        #endregion
    }
}
