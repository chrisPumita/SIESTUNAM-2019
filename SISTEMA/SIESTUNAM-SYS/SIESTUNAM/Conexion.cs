using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SIESTUNAM
{
    class Conexion
    {
        static string ip = "localhost";
        static string puerto = "3306";
        //static string ip2 = "127.0.0.1";
        static string userBD = "root";
        static string pw = "";
        static string DataBaseName = "siestunam";

        public MySqlConnection ConexionNew()
        {
              //Link del enlace con MySQL
            string link = "datasource="+ip+";port="+puerto+";username="+userBD+";password="+pw+";database="+DataBaseName+";";
            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(link);
            return databaseConnection;
        }
    }
}
