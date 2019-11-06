using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SIESTUNAM
{
    public partial class inputBox : Form
    {
        Empleado empleadoF;
        USUARIO usuario;
        string value;
        int opc;

        public inputBox(int opc)
        {
            this.opc = opc;
            InitializeComponent();
        }

        public string inputBoxDIalog()
        {
            this.Close();
            return value;
        }

        public Empleado getEmpleado()
        {
            this.Close();
            return empleadoF;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.value = txtInput.Text;
            if (value != "")
                if (opc == 1)
                    buscarEmpleado(value);
                else
                    MessageBox.Show("Buscando usuario");
            else
                MessageBox.Show("Debe escribir No de Cuenta");

                this.Close();
        }

        private void buscarEmpleado(string noCueta)
        {
            // Tu consulta en SQL
            
            string query = "SELECT " +
                "`idEmp`,`noCuenta`,`nomEmp`,`apP`,`apM`,`tel`,`email`,`sex`,`tipoCta`,`status`,`psw`,`idEst` " +
                "FROM `empleado` WHERE `status` = 1 AND `noCuenta` = '" + noCueta + "'  ;";
            // Prepara la conexión
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                //copia del reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*
                         `idEmp`,`noCuenta`,`nomEmp`,`apP`,`apM`,`tel`,`email`,`sex`,`tipoCta`,`status`,`psw`,`idEst`
                         */
                        // string pw = reader.GetString("psw");
                        string[] row = {   reader.GetString("idEmp"), //0
                                           reader.GetString("noCuenta"), //1
                                           reader.GetString("nomEmp"), //2
                                           reader.GetString("apP"), //3
                                           reader.GetString("apM"), //4
                                           reader.GetString("tel"), //5
                                           reader.GetString("email"),//6
                                           reader.GetString("sex"), //7
                                           reader.GetString("tipoCta"),//8 
                                           reader.GetString("status"), //9
                                           reader.GetString("psw"), //10
                                           reader.GetString("idEst") }; //11
                        if (row.Length>0)
                        {
                            //int idEmp, int noCuenta, string name, string app, string apm, string tel, string email, char sex, int tc, bool status, string psw
                            int idEmp = Convert.ToInt32(row[0]);
                            int noCuenta = Convert.ToInt32(row[1]);
                            string name = row[2];
                            string app = row[3];
                            string apm = row[4];
                            string tel = row[5];
                            string email = row[6];
                            int sex = Convert.ToInt32(row[7]);
                            int tc = Convert.ToInt32(row[8]);
                            int status = Convert.ToInt32(row[9]);
                            string psw = row[10];
                            int idEscuela = Convert.ToInt32(row[11]);
                            this.empleadoF = new Empleado(idEmp, noCuenta, name, app, apm, tel, email, sex, tc, status, psw);
                        }
                    }
                }
                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
