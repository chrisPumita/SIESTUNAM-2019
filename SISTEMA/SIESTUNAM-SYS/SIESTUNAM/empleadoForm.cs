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
    public partial class empleadoForm : Form
    {
        //GLOBALES
        int accion; //1 agregar ; 2 modificar
        Empleado emp;
        estacionamiento campus;

        public empleadoForm(int accion, Empleado emp, estacionamiento estacionamientoCampus)
        {
            InitializeComponent();
            this.emp = emp;
            this.campus = estacionamientoCampus;
            this.accion = accion;
            if (accion == 1)
            {
                lblOpcionTitulo.Text = "Agregar Empleado";
                btnAccion.Text = "Agregar";
            }
            else
            {
                lblOpcionTitulo.Text = "Modificar Empleado";
                btnAccion.Text = "Modificar";
                llenarCampos();
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (agregaEmp())
                {
                    MessageBox.Show("Se agrego un nuevo empleado");
                    this.Close();
                }
                else {
                    MessageBox.Show("Algo salio mal");
                }
            }
        }

        private bool agregaEmp()
        {
            bool flag = false;
            string eid = txtId.Text;
            string enoCuenta = txtNoCuenta.Text;
            string nombre = txtNombre.Text;
            string app = txtApp.Text;
            string apm = txtApm.Text;
            string tel = txtTel.Text;
            string email = txtMail.Text;
            int sex = cboSex.SelectedIndex;
            int tipo = cboTipoUsuario.SelectedIndex;
            int status = checkStatus.Checked ? 1 : 0;
            if (enoCuenta != "" && nombre != "" && app != "" && apm != "" && tel != "" && email != "")
            {
                int id;
                if (accion == 1)
                    id = 0;
                else
                    id = Convert.ToInt32(txtId.Text);
                //CREACION DE OBJETO

                //insertar en bd
                string querysql = "INSERT INTO `empleado` (" +
                    "`idEmp`, `noCuenta`, `nomEmp`, `apP`, `apM`, `tel`, `email`, `sex`, `tipoCta`, `status`, `psw`, `idEst`)" +
                    " VALUES (NULL, '" + enoCuenta + "', '" + nombre + "', '" + app + "', '" + apm + "', '" + tel + "', '" + email
                    + "', '" + Convert.ToString(sex) + "', '" + Convert.ToString(tipo) + "', '" + status + "', '0000', '" + campus.IDEstacionamiento + "')";

                // Prepara la conexión
                Conexion cn = new Conexion();
                MySqlConnection databaseConnection = cn.ConexionNew();
                MySqlCommand commandDatabase = new MySqlCommand(querysql, databaseConnection);
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


            }
            else
                MessageBox.Show("Datos incompletos");

            return flag;
        }

        private void cboTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void llenarCampos() 
        {
            txtId.Text = Convert.ToString(emp.IdEmp);
            txtNoCuenta.Text = Convert.ToString(emp.NoCuenta);
            txtNombre.Text = emp.NomEmp;
            txtApp.Text = emp.ApP;
            txtApm.Text = emp.ApM;
            txtTel.Text = emp.Tel;
            txtMail.Text = emp.Email;
            cboSex.SelectedIndex=emp.Sex;
            cboTipoUsuario.SelectedIndex = emp.TipoCta;
            if (emp.Status==1)
                checkStatus.Checked = true ;
            else
                checkStatus.Checked = false;
        }

    }
}
