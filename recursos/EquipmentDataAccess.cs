using System.Data;
using System.Data.Odbc;

namespace TheRemembrance.recursos
{
    public class EquipmentDataAccess
    {
        string userName;
        string passWord;

        public EquipmentDataAccess()
        {

        }

        public EquipmentDataAccess(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        // TRAE INFORMACIÓN DE UN EQUIPO EN PLEX
        public object[] informacionEquipo(string equId, string planta)
        {
            try
            {
                planta = transPlanta(planta);

                PlexConnection pc = new PlexConnection(userName, passWord);
                OdbcDataReader sqlreader;
                object[] infoeq = new object[9];
                string[] col = new string[]
                   {
                "equipment_id", "asset_no", "description", "brand", "model_no", 
                "serial_no", "equipment_key", "last_name", "first_name"
                   };
                sqlreader = pc.ExecuteSelect(@"SELECT E.equipment_id,
                                           E.asset_no,
                                           E.description,
                                           E.brand,
                                           E.model_no,
                                           E.serial_no,
                                           E.equipment_key,
                                           P.last_name,
                                           P.first_name
                                    FROM maintenance_v_equipment_e AS E
                                    LEFT JOIN plexus_control_v_plexus_user as P
                                    ON P.plexus_user_no = E.champion
                                    WHERE E.department_no = 2967
                                    AND E.plexus_customer_no = " + planta + 
                                  " AND E.equipment_id = '" + equId + "'");
                if (sqlreader.HasRows)                
                    while (sqlreader.Read())                    
                        for (int i = 0; i < infoeq.Length; i++)                        
                            infoeq[i] = sqlreader[col[i]].ToString();
                        
                else
                    MessageBox.Show("Por favor, verifique que el equipo pertenezca a la planta y sea un equipo activo!");
                
                sqlreader.Close();
                return infoeq;
            }
            catch (NullReferenceException)
            {
                //Okay, ya se ve más profesional!
                return null;
            }
            catch (Exception ex)
            {
                muestraEx(ex);
                return null;
            }
        }

        // TRANSFORMA LA PLANTA AL CODIGO LEGIBLE EN LA TABLA DE PLEX
        public string transPlanta(string planta)
        {
            switch (planta)
            {
                case "Torreón":
                    planta = "PLACEHOLDER";
                    break;
                case "Gómez Palacio I":
                    planta = "PLACEHOLDER";
                    break;
                case "Gómez Palacio II":
                    planta = "PLACEHOLDER";
                    break;
            }

            return planta;
        }

        public DataTable reparaciones(string nomEqu, string planta)
        {
            try
            {
                planta = transPlanta(planta);
                DataTable dt = new DataTable();
                PlexConnection pc = new PlexConnection(userName, passWord);
                string s = pc.GetConnectionString();
                using (OdbcConnection oc = new OdbcConnection(s))
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT E.Equipment_ID AS EQUIPO,
                           WR.Request_Date AS FECHA_REPARACION,
                           WR.Work_Request_No AS ORDEN_TRABAJO,
                           WR.Description AS PROBLEMA,
                           WR.Work_Note AS SOLUCION
                    FROM Maintenance_v_Equipment_e AS E
                    JOIN maintenance_v_Work_Request_e AS WR
                      ON WR.Equipment_Key = E.Equipment_Key
                    JOIN Maintenance_v_Work_Request_Type_e AS WT
                      ON WR.Work_Request_Type_Key = WT.Work_Request_Type_Key
                     AND WR.Plexus_Customer_No = WT.Plexus_Customer_No
                   AND WT.Work_Request_Type = 'Maintenance'
                    WHERE E.Equipment_ID = '" + nomEqu + "' AND E.plexus_customer_no = " + planta, pc.OpenConnection());

                    da.Fill(dt);
                }
                return dt;
            }
            catch(Exception ex)
            {
                muestraEx(ex);
                return null;
            }
        }

        public DataTable mantenimientos(int anio, string planta)
        {
            planta = transPlanta(planta);
            DataTable dt = new DataTable();

            try
            {
                PlexConnection pc = new PlexConnection(userName, passWord);
                OdbcDataReader r = pc.ExecuteSelect(@"{CALL sproc266298_2805915_2038953(" + anio + ", " + planta + ")}");
                if (r.HasRows)
                    dt.Load(r);
            }
            catch(Exception ex)
            {
                muestraEx(ex);
            }

            return dt;
        }

        private void muestraEx(Exception e)
        {
            MessageBox.Show("" + e);
        }
    }
}
