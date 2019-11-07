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
    public partial class Reportes : Form
    {
        int tipoFiltro; // 1 usuarios // 2 coches // 3 empleados
        List<USUARIO> listaUsuarios = new List<USUARIO>();
        List<VEHICULO> listaVecichulos = new List<VEHICULO>();
        public Reportes(int filtro)
        {
            InitializeComponent();
            this.tipoFiltro = filtro;
            cargarDatos(tipoFiltro);
        }

        private void cargarDatos(int tipo) 
        {
        //Vamos a comenzar a filtrar :)
            switch (tipo)
            { 
                case 1:
                    //Vamos a filtrar usuarios registrados
                    lblReportType.Text = "Reporte de Usuarios";
                    if (!consultaUsuarios())
                        MessageBox.Show("No hay datos registrados con esas condiciones");
                    break;
                case 2:
                    //Vamos a filtrar usuarios registrados
                    lblReportType.Text = "Reporte de vehiculos";
                    if (!consultaVehiculos())
                        MessageBox.Show("No hay datos registrados con esas condiciones");
                    break;
            }
        
        }

        private bool consultaUsuarios() 
        {
            bool flag = false;
            int posicion = 0;
            string sSQL = "SELECT `idUser`,`noCta`,`nomUser`,`apP`,`apM`,`tel`,`email`,`sex`,`tipoUser`,`status` FROM `usuario` ";
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(sSQL, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = {   reader.GetString("idUser"), //0
                                           reader.GetString("noCta"), //1
                                           reader.GetString("nomUser"), //2
                                           reader.GetString("apP"), //3
                                           reader.GetString("apM"), //4
                                           reader.GetString("tel"), //5
                                           reader.GetString("email"),//6
                                           reader.GetString("sex"), //7
                                           reader.GetString("tipoUser"),//8 
                                           reader.GetString("status")}; //9
                        if (row.Length > 0)
                        {
                            int idUser = Convert.ToInt32(row[0]);
                            int noCuenta = Convert.ToInt32(row[1]);
                            string name = row[2];
                            string app = row[3];
                            string apm = row[4];
                            string tel = row[5];
                            string email = row[6];
                            int sex = Convert.ToInt32(row[7]);
                            int tc = Convert.ToInt32(row[8]);
                            int status = Convert.ToInt32(row[9]);
                            USUARIO nvoUser = new USUARIO(idUser, noCuenta, name, app, apm, tel, email, sex, tc, status);
                            agregarToList(listaUsuarios,nvoUser);
                            posicion++;
                            flag = true;
                        }
                        else
                            MessageBox.Show("Error");
                    }
                }
                else
                    MessageBox.Show("El No de Cuenta no existe");
                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
            }
            return flag;
        }

        private bool consultaVehiculos()
        {
            bool flag = false;
            int posicion = 0;
            string sSQL = "SELECT `auto`.`idAuto`,`auto`.`marca`,`auto`.`modelo`,`auto`.`placa`,`auto`.`color`,`auto`.`tipoV`, `auto`.`idUser`,  `usuario`.`nomUser`,`usuario`.`noCta`  FROM `usuario`,`auto` WHERE `auto`.`idUser` = `usuario`.`idUser` ";
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(sSQL, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = {   reader.GetString("idAuto"), //0
                                           reader.GetString("marca"), //1
                                           reader.GetString("modelo"), //2
                                           reader.GetString("placa"), //3
                                           reader.GetString("color"), //4
                                           reader.GetString("idUser"),//5
                                           reader.GetString("tipoV"), //6
                                           reader.GetString("nomUser"),//7
                                           reader.GetString("noCta")
                                       }; //8
                        if (row.Length > 0)
                        {
                            int idAuto = Convert.ToInt32(row[0]);
                            string marca= row[1];
                            string modelo = row[2];
                            string placa = row[3];
                            string color = row[4];
                            int idUser = Convert.ToInt32(row[5]);
                            int tipo =Convert.ToInt32(row[6]);
                            string userName = row[7];
                            int noCta = Convert.ToInt32(row[8]);

                            VEHICULO vehiculo = new VEHICULO(idAuto, marca, modelo, placa, color, tipo, idUser);
                            agregarToList(listaVecichulos, vehiculo);
                            posicion++;
                            flag = true;
                        }
                        else
                            MessageBox.Show("Error");
                    }
                }
                else
                    MessageBox.Show("El No de Cuenta no existe");
                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
            }
            return flag;
        }
        public void agregarToList(List<USUARIO> lista, USUARIO userAdd)
        {
            try
            {
                lista.Add(userAdd);
                CargarDatos(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error de adding " + ex.ToString());
            }
        }

        public void agregarToList(List<VEHICULO> lista, VEHICULO vechiculoAdd)
        {
            try
            {
                lista.Add(vechiculoAdd);
                CargarDatos(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error de adding " + ex.ToString());
            }
        }


        void CargarDatos(List<USUARIO> lista)
        {
            BindingSource ds = new BindingSource(lista, "");
            this.gridDatos.DataSource = ds;
            this.lblCount.Text = "Total : " + lista.Count.ToString() + " registros";
        }

        void CargarDatos(List<VEHICULO> lista)
        {
            BindingSource ds = new BindingSource(lista, "");
            this.gridDatos.DataSource = ds;
            this.lblCount.Text = "Total : " + lista.Count.ToString() + " registros";
        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
