using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIESTUNAM
{
    public partial class AddUsers : Form
    {
        int opc;
        int id;
        USUARIO usuarioClass;
        Empleado empleadoClass;
        public AddUsers(int opc, int id, Empleado emp)
        {
            InitializeComponent();
            this.empleadoClass = emp;
            this.opc = opc;

            if (opc != 1) // Defino que se trata de una insercion (nuevo)
            {
                lblOpcionTitulo.Text = "Agregar Nuevo Usuario";
                btnAccion.Text = "Siguiente";
                txtId.Visible = false;
                lblId.Visible = false;
            }
            else 
            {
                this.id = id;
                lblOpcionTitulo.Text = "Modifica al usuario " + id;
                txtId.Text =Convert.ToString(id);
                btnAccion.Text = "Actualizar";
            }
               

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (opc != 1) // Voy a ingresar NUevo registro
            {
                if (validaDatosUsuario())
                {
                    //le mando 1 porque voy a agregar nuevo usuario
                    AddVehiculo carroNuevo = new AddVehiculo(empleadoClass, usuarioClass,1);
                    carroNuevo.ShowDialog();
                }
                else
                    MessageBox.Show("Faltan datos por agregar o el formato no es el correcto");
            }
            else {
                MessageBox.Show("Se modifico el usuario");
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
                    if (opc != 1)//
                        id = 0;
                    else
                        id = Convert.ToInt32(txtId.Text);
                    int noCueta = Convert.ToInt32(txtNoCuenta.Text);
                    USUARIO uss = new USUARIO(id, noCueta, nombre, app, apm, tel, email, sex, tipo, status);
                    usuarioClass = uss;
                    flag = true;
                }
                catch (Exception e) {
                    MessageBox.Show("datos incorrectos " + e);
                    flag = false;
                }
                
            }
            return flag;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
