using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace project
{
    public partial class formNuevoAvion : Form
    {
        public formNuevoAvion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModelo.Text =="")
                {
                    throw new Exception("Ingrese el modelo del avión.");
                }
                else if (txtAsientos.Text=="")
                {
                     throw new Exception("Ingrese el N° de asientos que posee el avión.");
                }
                else
                {
                    
                    avion.guardarAvion(Int32.Parse(txtAsientos.Text),txtModelo.Text);
                    MessageBox.Show("El avión ha sido ingresado con exito.");
                    this.Close();
                }  
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                "Important Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            
        }

        private void formNuevoAvion_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
