using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class formEdicionAviones : Form
    {
        public formEdicionAviones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formNuevoAvion open = new formNuevoAvion();
            open.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void formEdicionAviones_Load(object sender, EventArgs e)
        {
            
        }

        public void actualizarGrid()
        {
            
            dataGridView1.DataSource = avion.verAviones();
        }

        private void formEdicionAviones_VisibleChanged(object sender, EventArgs e)
        {
            actualizarGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualizarGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow fila = dataGridView1.CurrentRow;
                int id = ((Int32)fila.Cells[0].Value);
                avion.eliminarAvion(id);
                MessageBox.Show("Avión eliminado de la base de datos.");
            }
            
            catch (Exception)
            {
                MessageBox.Show("Avión no disponible.");
            }    
            
    }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;
            int idAvion = Convert.ToInt32(fila.Cells[0].Value);

            formAsientos asientos = new formAsientos(idAvion);
            asientos.ShowDialog();
        }

        public void actualizarGridCriterio(int criterio)
        {
           dataGridView1.DataSource = avion.verAvionesCriterio(criterio);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese el ID del avion");
            }
            else
            {
                actualizarGridCriterio(Convert.ToInt32( textBox1.Text));
            }

        }
  }
}
