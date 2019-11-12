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
using Microsoft.VisualBasic;


namespace SIESTUNAM
{
    public partial class PRINCIPAL : Form
    {
        Form Formulario;
        Empleado emp;
        estacionamiento fesc;

        public PRINCIPAL(Form Formulario, Empleado emp)
        {
            InitializeComponent();
            this.Formulario = Formulario;
            Formulario.Hide();
            this.emp = emp;
            IniciaConocimiento();
            cargaDatosEscuela();
            imprimeTadosEscuela();
            if (emp.TipoCta != 0) // Es un empleado normal
                menuAdmin.Visible = false;
            if (emp.Sex == 1)
                panel6.BackColor = Color.LightPink;
            else
                panel6.BackColor = Color.CadetBlue;
        }

        private void cargaDatosEscuela()
        {
            int idEscuela = 1;
            string nom;
            int tot;
            int ocu;
            int dis;
            //estacionamiento unam;
            // Realizar la conexion a la BD para obtener la informacion de la escuela
            string query = "SELECT `nomEsc`, `lugaresTot`,`lugaresOc`,`lugaresDis` " +
                " FROM `estacionamiento` WHERE `idEst` = " + idEscuela + " ";
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
                        string[] row = { 
                                           reader.GetString("nomEsc"), // 0
                                           reader.GetString("lugaresTot"), // 1
                                           reader.GetString("lugaresOc"),  // 2
                                           reader.GetString("lugaresDis") // 3
                                       };
                        nom = row[0];
                        tot = Convert.ToInt32(row[1]);
                        ocu = Convert.ToInt32(row[2]);
                        dis = Convert.ToInt32(row[3]);

                        estacionamiento unam = new estacionamiento(idEscuela, nom, tot, ocu, dis);
                        fesc = unam; // se la asigno al obj global de tipo estacionamiento
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

        private void imprimeTadosEscuela()
        {
            lblNameEsc.Text = fesc.NomEscuela;
            lblNameUser.Text = fesc.NomEscuela;
            lblDisponible.Text = Convert.ToString(fesc.Disponibles);
            lblOcupados.Text = Convert.ToString(fesc.Ocupados);
        }

        private void IniciaConocimiento()
        {
            string tipoCuta;
            if (emp.TipoCta == 0)
                tipoCuta = "Administrador";
            else if (emp.TipoCta == 1)
                tipoCuta = "Empleado";
            else if (emp.TipoCta == 3)
                tipoCuta = "DIOS";
            else
                tipoCuta = "NO FOUNT";

            txtUserName.Text = emp.NomEmp + " " + emp.ApP + " " + emp.ApM + " - " + tipoCuta;
        }

        private bool registraVechiculo(string placa) 
        {
            bool flag = false;
            //Verificamos que el vehiculo no tenga una entrada ya registrada antes de registrar otra entrada
            //primero Busca auto
            VEHICULO carroEncontrado = BuscaAuto(placa);
            if (carroEncontrado != null)
            {
                lblDatosVehiculo.Text = carroEncontrado.Marca+" "+carroEncontrado.Modelo +" Color: "+carroEncontrado.Color;
                //encontramos vechiculo pero ahora revisaremos que no tenga ya una entrada registrada.
                PASE_VECHICULO pase = BuscaPaseAuto(carroEncontrado.IdAuto);
                if (pase == null) 
                { 
                    //Todo en orden, se registra nueva entrada
                    if (registraEntradaAuto(carroEncontrado))
                    {
                        MessageBox.Show("PUEDE PASAR");
                        flag = true;
                        //cambiamos imagenes para que se vea chido
                    }
                    else
                        MessageBox.Show("El coche ya tiene ún pase registrado");
                }
            }
            else
                MessageBox.Show("El vechiculo no existe, porfavor registrelo");


            return flag;
        }

        private string fechaHora() {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private bool registraEntradaAuto(VEHICULO carroE) {
            bool flag = false;

            string sSQL = "INSERT INTO `pase_v`"+
                " (`idPase`, `idAuto`, `idEmp`, `idReporte`, `horaE`, `horaS`, `status`) "+
                " VALUES (NULL, '" + carroE.IdAuto + "', '" + emp.IdEmp + "', NULL, '" + fechaHora() + "', NULL, '1') ";
            // Prepara la conexión
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(sSQL, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                commandDatabase.ExecuteReader();
                databaseConnection.Close();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar nuevo registro \r\n"+ ex.Message);
            }
            return flag;
        }

        private VEHICULO BuscaAuto(string placa)
        {
            int idAuto;
            string marca;
            string modelo;
            string placas;
            string color;
            int tipo;
            int idUser;
            VEHICULO carroEntrante = null;
            string query = "SELECT `idAuto`, `marca`, `modelo`, `placa`, `color`, `tipoV`, `idUser` FROM " +
                " `auto` WHERE `placa` = '" + placa + "'  ";
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
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { 
                                           reader.GetString("idAuto"), // 0
                                           reader.GetString("marca"), // 1
                                           reader.GetString("modelo"),  // 2
                                           reader.GetString("placa"), // 3
                                           reader.GetString("color"), // 4
                                           reader.GetString("tipoV"), // 5
                                           reader.GetString("idUser") // 6
                                       };
                        idAuto =Convert.ToInt32(row[0]);
                        marca = row[1];
                        modelo = row[2];
                        placas = row[3];
                        color = row[4];
                        tipo = Convert.ToInt32(row[5]);
                        idUser = Convert.ToInt32(row[6]);

                        carroEntrante = new VEHICULO(idAuto,marca,modelo,placas,color,tipo,idUser);
                    }
                }
                // Cerrar la conexión
                databaseConnection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos de busqueda de vechiculo \r\n" + ex);
            }
            return carroEntrante;
        }


        private PASE_VECHICULO BuscaPaseAuto(int idCarro)
        {
            int idPase;
            int idAuto;
            int idEmp;
            int idReporte;
            DateTime horaE;
            DateTime horaS;
            int status;

            PASE_VECHICULO paseFound = null;
            string query = "SELECT `idPase`, `idAuto`, `idEmp`, `idReporte`, `horaE`, `horaS`, `status` FROM "+
                " `pase_v` WHERE `idAuto` = " + idCarro + " AND `horaS` IS NULL AND `status` = 1; ";
            // Prepara la conexión
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            txtPrint.Text = query;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { 
                                           reader.GetString("idPase"), // 0
                                           reader.GetString("idAuto"), // 1
                                           reader.GetString("idEmp"),  // 2
                                           reader.GetString("idReporte"), // 3
                                           reader.GetString("horaE"), // 4
                                           reader.GetString("horaS"), // 5
                                           reader.GetString("status") // 6
                                       };
                        idPase = Convert.ToInt32(row[0]);
                        idAuto = Convert.ToInt32(row[1]);
                        idEmp = Convert.ToInt32(row[2]);
                        horaE = DateTime.Parse(row[4]);
                        status = Convert.ToInt32(row[6]);
                        try
                        {
                            idReporte = Convert.ToInt32(row[3]);
                            horaS = DateTime.Parse(row[5]);
                        }
                        catch (Exception err)
                        {
                            idReporte =0;
                            horaS = DateTime.Parse("2000-11-27 00:00:00");
                        }
                        
                        /*
                            DateTime dateValue = DateTime.Parse(lDat_otp);
                            string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm");
                         */
                        MessageBox.Show(idPase + " " + idAuto + " " + idEmp + " " + horaE + " " + status);
                        if (idReporte != 0)
                            paseFound = new PASE_VECHICULO(idPase,idAuto,idEmp,idReporte,horaE,horaS,status);
                        else
                            paseFound = new PASE_VECHICULO(idPase,idAuto,idEmp,horaE,status);
                    }
                }
                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos de busqueda del pase \r\n" + ex.Message);
            }
            return paseFound;
        }



        private void vehiculoNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegVehiculo_frm reg_vehiculo = new RegVehiculo_frm();
            reg_vehiculo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //buscamos la placa
            if (registraVechiculo(txtPlacaIn.Text))
                MessageBox.Show("Se ha registrado la entrada");
            else
                MessageBox.Show("Error al registrar");
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Formulario.Close();
        }

        private void cerrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Formulario.Show();
        }

        private void agrgarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empleadoForm accionEmp = new empleadoForm(1,this.emp, this.fesc);
            accionEmp.ShowDialog();
        }

        private void modificarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputBox dialogo = new inputBox(1);
            dialogo.ShowDialog();
            Empleado emp =  dialogo.getEmpleado();
            if (emp != null)
            {
                empleadoForm accionEmp = new empleadoForm(2, emp, this.fesc);
                accionEmp.ShowDialog();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputBox dialogo = new inputBox(2);
            dialogo.ShowDialog();
            USUARIO user = dialogo.getUsuario();
            if (user != null)
            {
                AddUsers agregaUsuario = new AddUsers(2, user);
                agregaUsuario.ShowDialog();
            }
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Accion 1 = agregar nuevo // id User
            AddUsers agregaUsuario = new AddUsers(1);
            agregaUsuario.ShowDialog();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes reporteUsuario = new Reportes(1);
            reporteUsuario.Show();
        }

        private void verVehiculosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reportes reporteV = new Reportes(2);
            reporteV.Show();
        }

    }
}
