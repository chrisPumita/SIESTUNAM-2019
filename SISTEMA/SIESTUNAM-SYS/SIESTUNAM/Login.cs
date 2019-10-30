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
    public partial class Login_frm : Form
    {
        //Variables globales de la clase
        String Sesion;
        MySqlDataReader readerDB;
         Empleado empleadito;


        public Login_frm()
        {
            InitializeComponent();
            CargaEmpleados();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //Verificaciones de clave y usuario etc
            if (verificaSesion(Convert.ToString(CBOEmp.SelectedItem)))
            {
                principal_frm principal = new principal_frm(this, empleadito);
                principal.Show();
            }
            else 
            {
                MessageBox.Show("Datos incorrectos");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargaEmpleados();
        }

        private bool verificaSesion(string nameEmp) 
        {
            // Tu consulta en SQL
            string query = "SELECT `idEmp`, `nomEmp`, `apP`,`apM`,`tipoCta`,`psw` " +
                " FROM `empleado`  WHERE `status` = 1 AND `nomEmp` = '" + nameEmp + "'  ;";
            // Prepara la conexión
            bool bandera = false;
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
                this.readerDB = reader;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /*
                         *  `idEmp`, `nomEmp`, `apP`,`apM`,`tipoCta`,`psw` "
                         * string[] row = { reader.GetString("NAME"), reader.GetString("AP"), reader.GetString(2) };
                         MessageBox.Show( row[0] + row[1] + row[2]);
                         */
                        // string pw = reader.GetString("psw");
                        string[] row = { reader.GetString("idEmp"), reader.GetString("nomEmp"), reader.GetString("apP"), reader.GetString("apM"), reader.GetString("tipoCta"), reader.GetString("psw") };
                        string pw = readerDB.GetString("psw");
                        //Almacene la pw de aqui
                        //Envia int idEmp, string name, string app, string apm

                        if (pw.Equals(txt_psw.Text))
                        {
                            this.empleadito = new Empleado(Convert.ToInt32(row[0]),row[1], row[2], row[3],Convert.ToInt32(row[4]));
                            bandera = true;
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
            return bandera;
        }


        /// INICIO DE FUNCIONES DE LA CLASE
        /// 
        public MySqlDataReader CargaEmpleados()
        {
            // Tu consulta en SQL
            string query = "SELECT `nomEmp` FROM `empleado`  WHERE `status` = 1 ;";
            // Prepara la conexión
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try{
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows){
                  CBOEmp.Items.Clear();
                    while (reader.Read()){
                        /*
                         * string[] row = { reader.GetString("NAME"), reader.GetString("AP"), reader.GetString(2) };
                         MessageBox.Show( row[0] + row[1] + row[2]);
                         */
                        CBOEmp.Items.Add(reader.GetString("nomEmp"));
                    }
                    return reader;
                }
                else{
                    MessageBox.Show("No se encontraron datos.");
                    return reader;
                }
                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
