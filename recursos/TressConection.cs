using Microsoft.Data.SqlClient;
using System.Data;

namespace TheRemembrance.recursos
{

    /*
                            Retornar null es mala practica
    */


    public class TressConection
    {
        SqlConnection conn = new SqlConnection();

        public string GetConectionString()
        {
            //OJO AQUI

            // CONEXIÓN A PRODUCCIÓN, LANZAMIENTO OFICIAL!!!
            string sConnection = @"Server=PLACEHOLDER;data source=PALCEHOLDER;initial catalog=PLACEHOLDER;user id=PLACEHOLDER;password=PLACEHOLDER;Trusted_Connection=False;TrustServerCertificate=True";

            // CONEXIÓN A PRUEBAS, TESTING DE CUALQUIER TIPO!!!
            //string sConnection = @"Server=PLACEHOLDER;data source=PLACEHOLDER;initial catalog=PALCEHOLDER;user id=PALCEHOLDER;password=PLACEHOLDER;Trusted_Connection=False;TrustServerCertificate=True";

            return sConnection;
            //Las deshabilité para evitar confusiones al momento de volver a compilar, para el que sea que vea esto.
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    SqlConnection sqlConnection = new SqlConnection(this.GetConectionString());
                    sqlConnection.Open();
                    this.conn = sqlConnection;
                }
                return conn;
            }
            catch (NullReferenceException)
            {
                //MessageBox.Show("no se");
                // si
                return null;
            }
            catch(SqlException sqlex)
            {
                if(sqlex.Number == 53)
                {
                    MessageBox.Show("Por favor, verifique su conexión a internet!");
                    return null;
                }
                if(sqlex.Number == 4060)
                {
                    MessageBox.Show("Solicite permisos de edición al administrador de sistema");
                    return null;
                }
                MessageBox.Show("" + sqlex);
                MessageBox.Show("" + sqlex.Number);
                //MessageBox.Show("Por favor, revise su conexión a internet!");
                return null;
            }
        }

        public SqlDataReader ExecuteSelect(string query)
        {
            conn = OpenConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandTimeout = 21600;
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                return reader;

            }
            catch(SqlException sqlex)
            {
                if(sqlex.Number == 10060)
                {
                    MessageBox.Show("Verifique su conexión a internet!");
                    return null;
                }
                MessageBox.Show("" + sqlex);
                MessageBox.Show("" + sqlex.Number);
                return null;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Ha ocurrido un error en la consulta");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
                return null;
            }
        }

    }
}