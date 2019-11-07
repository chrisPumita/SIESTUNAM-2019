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
        VEHICULO carro;
        USUARIO usuario;
        Form dialogoUsuario;
        // si accion =  1 Ya existe usuario  0 = NUevo usuario nuevo vehiculo
        int accion;
        public AddVehiculo(Form ventana, USUARIO user, int Accion)
        {
            this.dialogoUsuario = ventana;
            this.usuario = user;
            this.accion = Accion;
            InitializeComponent();
            lblNombreUsuario.Text = user.Nombre + " "+ user.App + " "+ user.Apm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!registro())
                MessageBox.Show("ALgo salio mal, no se ha registrado el usuario");
            this.Close();
            dialogoUsuario.Close();
            MessageBox.Show("Se ha registrado al usuario y su vehiculo");
        }

        private bool registro() 
        {
            bool flag = false;
            //valodo los datos del vehichulo
            if (validarDatos())
            {
                if (accion == 1) // Agregando nuevo usuario y nuevo vehiculo
                {
                    // Agrego al usuario
                    if (agregaUser(this.usuario))
                    {
                        //obtengo el ID registrado
                        int idUserRegistrado = ultimoID(usuario.NoCta);
                        if (idUserRegistrado != 0)
                        {
                            //Registrar el nuevo vehiculo
                            if (agregaVechiculo(idUserRegistrado))
                            {
                                flag = true;
                            }
                            else
                                MessageBox.Show("No se pudo agregar el vehiculo");
                        }
                        else
                            MessageBox.Show("ID no valido");
                    }
                    else
                        MessageBox.Show("Usuario Ya existe");

                    //agrego el nuevo vehiculo asignado al ID del usuario devuelto
                }

                else
                {
                    MessageBox.Show("VAMOS A EDIATR USUARIO");
                    //Lo que se hara sera modificar al usuario, porque ya existe
                }
                // Primero registro el usuario
            }
            else
                MessageBox.Show("Datos de vehiculo incompletos");
            
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
                //VEHICULO(int idAuto, string marca, string modelo, string placas, string color, int tipo, int idUser)
                carro = new VEHICULO(0,marca,modelo,placas,color,tipo,0);
                flag = true;
            }
            //FUnciones que almacenan y conectan con la BD
            return flag;
        }


        private bool agregaUser(USUARIO user)
        {
            bool flag = false;
            // Realizar la conexion a la BD para obtener la informacion de la escuela
            string query = "INSERT INTO `usuario` "+
                " (`idUser`, `noCta`, `nomUser`, `apP`, `apM`, `tel`, `email`, `sex`, `tipoUser`, `status`) "+
                " VALUES (NULL, '" + user.NoCta + "', '" + user.Nombre + "', '"+user.App+"', '"+user.Apm+
                "', '"+user.Tel+"', '"+user.Email+"', '"+user.Sex+"', '"+user.Tipo+"', '1')";
            // Prepara la conexión
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
                flag = true;
            }

            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
            }
            return flag;
        }

        private int ultimoID(int noCUenta) 
        {
            int idObtenido = 0;
            string sql = "SELECT MAX(idUser) AS id FROM usuario WHERE `noCta` ="+noCUenta+"; ";
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(sql, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                //copia del reader
                if (reader.HasRows)
                    while (reader.Read())
                        idObtenido =Convert.ToInt32(reader.GetString("id")); // 0
                // Cerrar la conexión
                databaseConnection.Close();
            }

            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
            }
            return idObtenido;
        }

        private bool agregaVechiculo(int idUser)
        {
            bool flag = false;
            // Realizar la conexion a la BD para obtener la informacion de la escuela
            string query = "INSERT INTO `auto` (`idAuto`, `marca`, `modelo`, `placa`, `color`, `tipoV`, `idUser`) "+
                "VALUES (NULL, '" + carro.Marca + "', '" + carro.Modelo + "', '" + carro.Placas + "', '" + carro.Color + "', '" + carro.Tipo + "', '" + idUser + "')";
            // Prepara la conexión
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
                flag = true;
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
