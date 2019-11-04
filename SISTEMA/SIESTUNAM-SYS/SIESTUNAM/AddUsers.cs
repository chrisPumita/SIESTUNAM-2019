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
        public AddUsers(int opc, int id)
        {
            InitializeComponent();
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
                AddVehiculo carroNuevo = new AddVehiculo();
                this.Close();
                carroNuevo.ShowDialog();

            }

            else {
                MessageBox.Show("Se modifico el usuario");
                this.Close();
            }
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
