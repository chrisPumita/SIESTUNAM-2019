﻿using System;
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
            if (emp.TipoCta != 1) // Es un empleado normal
                menuAdmin.Visible = false;
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
            label4.Text = fesc.NomEscuela;
            lblDisponible.Text = Convert.ToString(fesc.Disponibles);
            lblOcupados.Text = Convert.ToString(fesc.Ocupados);
        }

        private void IniciaConocimiento()
        {
            string tipoCuta;
            if (emp.TipoCta == 1)
                tipoCuta = "Adminisrtador";
            else if (emp.TipoCta == 2)
                tipoCuta = "Empleado";
            else if (emp.TipoCta == 0)
                tipoCuta = "DIOS";
            else
                tipoCuta = "NO FOUNT";

            txtUserName.Text = emp.NomEmp + " " + emp.ApP + " " + emp.ApM + " - " + tipoCuta;
        }

        private void vehiculoNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegVehiculo_frm reg_vehiculo = new RegVehiculo_frm();
            reg_vehiculo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Formulario.Close();
        }



        private void cerrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Formulario.Close();
        }

        private void agrgarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUsers agregaUsuario = new AddUsers(2, 1);
            agregaUsuario.ShowDialog();

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUsers agregaUsuario = new AddUsers(1, 1);
            agregaUsuario.ShowDialog();
        }


    }
}