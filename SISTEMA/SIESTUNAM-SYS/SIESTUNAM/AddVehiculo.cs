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
    public partial class AddVehiculo : Form
    {
        Empleado emp;
        USUARIO usuario;

        // si accion =  1 Ya existe usuario  0 = NUevo usuario nuevo vehiculo
        int accion;
        public AddVehiculo(Empleado e, USUARIO user, int Accion)
        {
            this.usuario = user;
            this.accion = Accion;
            InitializeComponent();
            this.emp = e;
            lblNombreUsuario.Text = user.Nombre + " "+ user.App + " "+ user.Apm;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (registro())
                MessageBox.Show("Se ha registrado correctamente al usuario");
            else
                MessageBox.Show("ALgo salio mal, no se ha registrado el usuario");

        }

        private bool registro() 
        {
            bool flag = false;
            //valodo los datos del vehichulo
            if (validarDatos())
            {
                // Primero registro el usuario
            }
            
            return flag;
        }

        private bool validarDatos() 
        {
            bool flag = false;
            int tipo = comboTipoVehiculo.SelectedIndex;
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string placas = txtPlacas.Text;
            string color = txtColor.Text;

            if (marca != "" && modelo != "" && placas != "" && color != "")
            {
                if (accion == 0) // Agregando nuevo usuario y nuevo vehiculo
               { 
                    // Agrego al usuario
                   if (agregaUser(this.usuario))
                   { 
                   
                   }
                    //obtengo el ID registrado

                    //agrego el nuevo vehiculo asignado al ID del usuario devuelto
                }
                //todos los campos ya estan llenos .°. me dispongo a agregar el vechiculo a nuevo obj

            }
            //FUnciones que almacenan y conectan con la BD


            return flag;
        }


        private bool agregaUser(USUARIO user)
        {
            bool flag = false;
            // Realizar la conexion a la BD para obtener la informacion de la escuela
            string query = "";
            // Prepara la conexión
            bool bandera = false;
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                commandDatabase.ExecuteReader();
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
    }
}
