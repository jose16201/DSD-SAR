using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAR_Sistema_de_Administracion_de_Redes
{
    public partial class Form3 : Form
    {

        
        EquiposService.EquiposClient obj = new EquiposService.EquiposClient();

        
        public Form3()
        {
            InitializeComponent();
        }
        public void ListarEquipos()
        {
            //DataSet ds = new DataSet();
            dataGridView1.DataSource = obj.ListarEquipos();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sARDataSet.EQUIPOS' table. You can move, or remove it, as needed.
            //this.eQUIPOSTableAdapter.Fill(this.sARDataSet.EQUIPOS);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form4 = new Form6();
          
            form4.Show(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.eQUIPOSTableAdapter.FillBy(this.sARDataSet.EQUIPOS);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();

            form5.Show(); 
        }


        public void ReloadForm()
        {
            
            dataGridView1.Update();
            //and how many controls or settings you want, just add them here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListarEquipos();
            dataGridView1.Update();
            dataGridView1.Refresh();
            ListarEquipos();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string serie = dataGridView1.SelectedCells[0].Value.ToString();
            string modelo = dataGridView1.SelectedCells[1].Value.ToString();
            string caracteristica = dataGridView1.SelectedCells[2].Value.ToString();
            string estado = dataGridView1.SelectedCells[3].Value.ToString();
            string fecha = dataGridView1.SelectedCells[4].Value.ToString();
            Modificar Modificar = new Modificar(serie, modelo, caracteristica, estado, fecha);
            Modificar.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.ListarEquipos();
            
        }

        
    }
}
