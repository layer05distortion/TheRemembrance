using System.Data.Odbc;

namespace TheRemembrance.recursos
{
    public class PlexConnection
    {
        OdbcConnection conn = new OdbcConnection();
        //OdbcConnection conn;
        string userId;
        string passWord;

        public string GetConnectionString()
        {
        string sConnection = "Dsn=PLACEHOLDER;" + "Uid=" + userId + ";" + "Pwd=" + passWord + ";";
        return sConnection;

        }

        
        /*public PlexConnection()
        {

        }*/

        public PlexConnection(string userId, string passWord)
        {
            this.userId = userId;
            this.passWord = passWord;
        }

        public OdbcConnection OpenConnection()
        {
            try
            {
                //OdbcConnection obdcConnection = new OdbcConnection(this.GetConnectionString());+
                conn.ConnectionString = GetConnectionString();
                //if (conn.State.ToString() == "Closed")
                conn.Open();
                return conn;
            } 
            catch(OdbcException oex)
            {
                if (oex.Errors[0].NativeError == 10300)
                {
                    MessageBox.Show("Por favor, verifique que la cadena ODBC de su equipo coincida con la de su plata!");
                    return null;
                }

                if (oex.Errors[0].NativeError == 2469)
                {
                    MessageBox.Show("Verifique su conexión a internet!");
                    return null;
                }

                for (int i = 0; i < 10; i++)
                {
                    MessageBox.Show("index: " + i);
                    MessageBox.Show("msg: " + oex.Errors[i].Message);
                    MessageBox.Show("number: " + oex.Errors[i].NativeError.ToString());
                    MessageBox.Show("from: " + oex.Errors[i].Source);
                    MessageBox.Show("E E: " + oex.Errors[i].SQLState);
                }
                return null;
            }
            catch(Exception e)
            {
                MessageBox.Show("" + e);
                //System.Environment.Exit(0);
                return null;
            }
        }

        public OdbcDataReader ExecuteSelect(string query)
        {
            OdbcConnection conn = OpenConnection();
            try
            {
                OdbcCommand comm = new OdbcCommand(query, conn);
                OdbcDataReader reader = comm.ExecuteReader();

                return reader;

            }
            catch(InvalidOperationException)
            {
                // No pasa nada, sabemos que no se inició por un error de incompatibilidad entre la cadena PLEX y el usuario
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

    }
}
