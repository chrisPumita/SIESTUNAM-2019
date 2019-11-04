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
    public partial class AddVehiculo : Form
    {
        Empleado emp;
        USUARIO usuario;
        public AddVehiculo(Empleado e, USUARIO user)
        {
            this.usuario = user;
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

        }
    }
}
