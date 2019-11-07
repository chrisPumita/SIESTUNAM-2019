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
                if (!(emp.Sex != 1)) // que es mujer
                    pintaPanel.BackColor = Color.LightPink;
                else
                    pintaPanel.BackColor = Color.LightSkyBlue;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (verificaDatos()) {
                    if (agregaEmp())
                    {
                        MessageBox.Show("Se agrego un nuevo empleado");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Algo salio mal al intentar guardar al usuario");
                }                
            }
            else
            {
                if (verificaDatos())
                {
                    if (UpdateEmpDB(emp))
                        MessageBox.Show("Datos del empleado modificados correctamente :D");
                    else
                        MessageBox.Show("Algo salio mal al intentar modificar datos.");
                    this.Close();
                }
                else
                    MessageBox.Show("Faltan datos por completar");
            }
        }

        bool verificaDatos() {
            bool bandera = false;
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
                if (accion == 1) // NO me interesa el ID porque voy a ingresa nuevo .°. SQL me dara el iD
                    id = 0;
                else
                    id = Convert.ToInt32(txtId.Text);
                //CREACION DE OBJETO
                int noCueta = Convert.ToInt32(txtNoCuenta.Text);

                Empleado tmpEmp = new Empleado(id, noCueta, nombre, app, apm, tel, email, sex, tipo, status, emp.Psw);
                emp = tmpEmp;
                bandera = true;
            }
            else
                MessageBox.Show("Datos incompletos, Reviselos");

            return bandera;
        }

        private bool agregaEmp()
        {
            bool flag = false;
                //insertar en bd
                string querysql = "INSERT INTO `empleado` (" +
                    "`idEmp`, `noCuenta`, `nomEmp`, `apP`, `apM`, `tel`, `email`, `sex`, `tipoCta`, `status`, `psw`, `idEst`)" +
                    " VALUES (NULL, '" + emp.NoCuenta + "', '" + emp.NomEmp + "', '" + emp.ApP + "', '" + emp.ApM + "', '" + emp.Tel + "', '" + emp.Email
                    + "', '" + Convert.ToString(emp.Sex) + "', '" + Convert.ToString(emp.TipoCta) + "', '" + emp.Status + "', '0000', '" + campus.IDEstacionamiento + "')";

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

            return flag;
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

        bool UpdateEmpDB(Empleado empDB)
        {
            bool bandera=false;
            string sSQL = "UPDATE  `empleado` SET " +
            "  `noCuenta` = '" + empDB.NoCuenta + "', " +
            "  `nomEmp` = '" + empDB.NomEmp + "', " +
            "  `apP` = '" + empDB.ApP + "'," +
            "  `apM` = '" + empDB.ApM+ "'," +
            "  `tel` = '" + empDB.Tel + "'," +
            "  `email` = '" + empDB.Email + "'," +
            "  `sex` = '" + empDB.Sex + "'," +
            "  `tipoCta` = '" + empDB.TipoCta + "'," +
            "  `status` = '" + empDB.Status+ "' " +
            "  WHERE `empleado`.`idEmp` = "+empDB.IdEmp+"; ";
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
                bandera = true;
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
            }
            return bandera;
        }
    }
}
