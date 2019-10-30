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
    public partial class principal_frm : Form
    {
        Form Formulario;
        Empleado emp;

        public principal_frm(Form Formulario, Empleado emp)
        {
            this.Formulario = Formulario;
            InitializeComponent();
            Formulario.Hide();
            this.emp = emp;
            IniciaConocimiento();
        }

        private void IniciaConocimiento() 
        {
            MessageBox.Show("ENTRE");
            /*
            this.idEmp = idEmp;
            this.nomEmp = name;
            this.apP = app;
            this.apM = apm;
             */
            string tipoCuta;
            if (emp.TipoCta == 1)
                tipoCuta = "Adminisrtador";
            else if (emp.TipoCta == 2)
                tipoCuta = "Empleado";
            else if (emp.TipoCta == 0)
                tipoCuta = "DIOS";
            else
                tipoCuta = "NO FOUNT";

            txtUserName.Text = emp.NomEmp + " " + emp.ApP + " " + emp.ApM + " - " + emp.TipoCta+ " "+ tipoCuta;
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
    }
}
