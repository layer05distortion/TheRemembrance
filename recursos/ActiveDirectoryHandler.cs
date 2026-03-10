//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.DirectoryServices;
//using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;

namespace TheRemembrance.recursos
{
    public class ActiveDirectoryHandler
    {
        static readonly string domainServer = "PLACEHOLDER";
        public static string _depto;

        public bool Login(string userName, string password)
        {
            bool success = false;

            try
            {
                DirectoryEntry entry = new DirectoryEntry(domainServer, userName, password, AuthenticationTypes.Secure);
                object nativeObject = entry.NativeObject;
                success = true;
            }
            catch (DirectoryServicesCOMException)
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos!");
            }
            catch (COMException)
            {
                MessageBox.Show("Por favor, verifique su conexión a internet!");
            }

            return success;
        }
        
        //Originalmente se iba a devolver el nombre de usuario y su departamento
        // Ahora solo es relevante el nombre del usuario...
        // De este metodo no borro los comentarios porque son más especificos que en otros al tratarse de active directory
        public string[] SearchDepartmentOnActiveDirectory(string nombreUsuario)
        {
            nombreUsuario = nombreUsuario.ToLower();
            //string department = string.Empty;
            string[] devolver = new string []{ string.Empty, string.Empty };
            //na.gdx.auto/TORREON/Users/Active Users
            //List<Personal> lista = new List<Personal>();
            DirectoryEntry entry = new DirectoryEntry(domainServer);
            //DirectoryEntry thisOU = entry.Children.Find("OU=TORREON");
            //DirectoryEntry usersOU = thisOU.Children.Find("OU=Users");
            //DirectoryEntry activeUsersOU = usersOU.Children.Find("OU=Active Users");
            //DirectorySearcher search = new DirectorySearcher(activeUsersOU);
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(&(objectClass=user)(sAMAccountName="+nombreUsuario+"))"; //(|(department=Information Technology)(department=Maintenance)))";//Para filtrar solo a sistemas | 02-feb-2024 ya no xd
            search.PropertiesToLoad.AddRange(new string[] { "sAMAccountName", "department", "displayname","localeID" });

            foreach (SearchResult res in search.FindAll())
            {
                
                //var box = res.GetDirectoryEntry();
                ResultPropertyValueCollection nombre = res.Properties["sAMAccountName"];
                ResultPropertyValueCollection area = res.Properties["department"];
                ResultPropertyValueCollection nombreMostrar = res.Properties["displayname"];
                //ResultPropertyValueCollection localid = res.Properties["l"];

                //description
                //ResultPropertyValueCollection correo = res.Properties["mail"];
                //ResultPropertyValueCollection user = res.Properties["sAMAccountName"]; //username
                // ResultPropertyValueCollection puesto = res.Properties["title"]; //Job Title

                string nombreDeAD = nombre.Count > 0 ? nombre[0].ToString() : "";
                string deptoDeAD = area.Count > 0 ? area[0].ToString() : "";
                string nombreMostrarDeAD = nombreMostrar.Count > 0 ? nombreMostrar[0].ToString() : "";
                //string local = localid.Count > 0 ? localid[0].ToString() : "";

                nombreDeAD = nombreDeAD.ToLower();
                //MessageBox.Show(nombreDeAD + " : " + local); //Usado para verificar que la consulta si funcionase!!!

                if (nombreDeAD.Equals(nombreUsuario))
                {
                    //department = deptoDeAD;
                    devolver[0] = deptoDeAD;
                    devolver[1] = nombreMostrarDeAD;
                    break;
                }
            }

            //ES MUY IMPORTANTE LIBERAR ESTOS RECURSOS UNA VEZ QUE HAYA TERMINADO SU USO
            entry.Dispose();
            //thisOU.Dispose();
            //usersOU.Dispose();
            //activeUsersOU.Dispose();
            search.Dispose();

            //lista = lista.OrderBy(o => o.Nombre).ToList(); //Ordenar alfabéticamente usando Linq

            //return department;
            return devolver;
        }
    }
}