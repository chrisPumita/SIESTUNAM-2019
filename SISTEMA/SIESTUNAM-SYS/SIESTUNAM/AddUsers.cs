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
    public partial class AddUsers : Form
    {
        int opc;
        USUARIO usuarioClass;
        //Opc 1 agregar != 1 Editar
        public AddUsers(int opc, USUARIO usuario)
        {
            InitializeComponent();
            this.usuarioClass = usuario;
            this.opc = opc;
            lblOpcionTitulo.Text = "Modifica al usuario " + usuarioClass.NoCta;
            txtId.Text = Convert.ToString(usuarioClass.IdUser);
            btnAccion.Text = "Actualizar";
            cargaDatos();
        }

        //opc 2 para editar
        public AddUsers(int opc)
        {
            InitializeComponent();
            this.opc = opc;

                lblOpcionTitulo.Text = "Agregar Nuevo Usuario";
                btnAccion.Text = "Siguiente";
                txtId.Visible = false;
                lblId.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (opc == 1) // Voy a ingresar NUevo registro
            {
                if (validaDatosUsuario())
                {
                    //le mando 1 porque voy a agregar nuevo usuario
                    AddVehiculo carroNuevo = new AddVehiculo(this,usuarioClass,1);
                    carroNuevo.ShowDialog();
                }
                else
                    MessageBox.Show("Faltan datos por agregar o el formato no es el correcto");
            }
            else {
                if (validaDatosUsuario())
                {
                    if(updateDB(usuarioClass))
                        MessageBox.Show("Se modifico el usuario");
                }
                
                this.Close();
            }
        }

        private bool validaDatosUsuario() 
        {
            bool flag = false;
            string sid = txtId.Text;
            string snoCueta = txtNoCuenta.Text;
            string nombre = txtNombre.Text;
            string app = txtApp.Text;
            string apm = txtApm.Text;
            string tel = txtTel.Text;
            string email = txtMail.Text;
            int sex = cboSex.SelectedIndex; // 0 HOmbre 1 Mujer
            /*
              0  Estudiante
              1  Profesor
              2  Administrativo
              3  Trabajador
              4  Otro
             */
            int tipo = cboTipoUsuario.SelectedIndex;
            int status = checkStatus.Checked ? 1 : 0;
            /*        public USUARIO(
                         * int id, 
                         * nt cta, 
                         * string nom, 
                         * string ap, 
                         * string am, 
                         * string tel, 
                         * string email, 
                         * int sex, 
                         * int tipo,
                         * int status)
            /*

            USUARIO otroUSer = new USUARIO(opc != 1 ? 0 : Convert.ToInt32(txtId.Text), Convert.ToInt32(txtNoCuenta.Text),
                txtNombre.Text, txtApp.Text, txtApm.Text, txtTel.Text, txtMail.Text, cboSex.SelectedIndex,
                cboTipoUsuario.SelectedIndex, checkStatus.Checked ? 1 : 0);

            */
            if (sid != "" && snoCueta != "" && nombre != "" && app != "" &&
                apm != "" && tel != "" && email != "")
            {
                try
                {
                    int id;
                    if (opc == 1)//
                        id = 0;
                    else
                        id = Convert.ToInt32(txtId.Text);
                    int noCueta = Convert.ToInt32(txtNoCuenta.Text);
                    USUARIO tmpUsuario = new USUARIO(id, noCueta, nombre, app, apm, tel, email, sex, tipo, status);
                    usuarioClass = tmpUsuario;
                    flag = true;
                }
                catch (Exception e) {
                    MessageBox.Show("datos incorrectos " + e);
                    flag = false;
                }
                
            }
            return flag;
        }

        private void cargaDatos() {
            txtNoCuenta.Text = Convert.ToString(usuarioClass.NoCta);
            txtId.Text = Convert.ToString(usuarioClass.IdUser);
            txtNombre.Text = usuarioClass.Nombre;
            txtApp.Text = usuarioClass.App;
            txtApm.Text = usuarioClass.Apm;
            txtTel.Text = usuarioClass.Tel;
            txtMail.Text = usuarioClass.Email;
            cboSex.SelectedIndex = usuarioClass.Sex;
            cboTipoUsuario.SelectedIndex = usuarioClass.Tipo;
            if (usuarioClass.Status == 1)
                checkStatus.Checked = true;
            else
                checkStatus.Checked = false;
        }

        bool updateDB(USUARIO userUpdate) {
            bool flag = false;

            string sSQL = "UPDATE `usuario` SET "+
                " `noCta` = '" + userUpdate.NoCta + "'," +
                " `nomUser` = '" + userUpdate.Nombre + "'," +
                " `apP` = '" + userUpdate.App + "'," +
                " `apM` = '" + userUpdate.Apm + "'," +
                " `tel` = '" + userUpdate.Tel + "', " +
                "`email` = '" + userUpdate.Email + "', " +
                "`sex` = '" + userUpdate.Sex + "', " +
                "`tipoUser` = '" + userUpdate.Tipo + "'," +
                " `status` = '" + userUpdate.Status + "' " +
                "WHERE `usuario`.`idUser` = " + userUpdate.IdUser + "   ";
            // Prepara la conexión
            Conexion cn = new Conexion();
            MySqlConnection databaseConnection = cn.ConexionNew();
            MySqlCommand commandDatabase = new MySqlCommand(sSQL, databaseConnection);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
